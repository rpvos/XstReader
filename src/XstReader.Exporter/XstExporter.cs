using XstReader.Exporter.Helpers;
using XstReader.Exporter.MsgKit;

namespace XstReader.Exporter
{
    public class XstExporter
    {
        private ExportOptions? _ExportOptions = null;
        public ExportOptions ExportOptions
        {
            get => _ExportOptions ??= new();
            set
            {
                _ExportOptions = value;
                _MessageToSingleHtml = null;
            }
        }

        public ExportProgress ExportProgress { get; private init; }

        private MessageToSingleHtml? _MessageToSingleHtml = null;
        private MessageToSingleHtml MessageToSingleHtml => _MessageToSingleHtml ??= new(ExportOptions.SingleHtmlOptions);

        #region Ctor
        public XstExporter(ExportOptions exportOptions)
        {
            ExportOptions = exportOptions;
            ExportProgress = new();
        }
        public XstExporter(ExportOptions exportOptions, Action<ExportProgress> reportProgressAction)
        {
            ExportOptions = exportOptions;
            ExportProgress = new(reportProgressAction);
        }
        #endregion Ctor

        private string CreateDirForMessage(XstMessage message, string path)
        {
            var folderPath = IOHelper.GetDirNameWithoutCollisions(Path.Combine(path, message.GetFilenameForSaving(ExportOptions)));

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            if (Directory.Exists(folderPath))
                Directory.SetLastWriteTime(folderPath, message.Date ?? DateTime.Now);

            return folderPath;
        }
        private string CreateDirForFolder(XstFolder folder, string path)
        {
            var folderPath = IOHelper.GetDirNameWithoutCollisions(Path.Combine(path, folder.GetDirnameForSaving(ExportOptions)));

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            if (Directory.Exists(folderPath))
                Directory.SetLastWriteTime(folderPath, folder.LastModificationTime ?? DateTime.Now);

            return folderPath;
        }

        #region Attachments
        private IEnumerable<string> SaveAttachmentToDirectory(XstAttachment? attachment, string path)
        {
            if (attachment == null)
                return Enumerable.Empty<string>();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (attachment.IsEmail)
                return SaveMessage(attachment.AttachedEmailMessage, path);

            string fileName = IOHelper.GetFileNameWithoutCollisions(Path.Combine(path, attachment.FileNameForSaving));
            return SaveAttachmentToFile(attachment, fileName);
        }
        public IEnumerable<string> SaveAttachmentToFile(XstAttachment attachment, string fileName)
        {
            try
            {
                try { attachment.SaveToFile(fileName); }
                catch { return Enumerable.Empty<string>(); }

                return new List<string> { fileName };
            }
            finally { ExportProgress.Step($"Processed Attachment {attachment}"); }
        }
        private IEnumerable<string> SaveAttachmentsToDirectory(IEnumerable<XstAttachment> attachments, string path)
        {
            var fileNames = new List<string>();
            foreach (var attachment in attachments.OrderBy(a => a.LastModificationTime))
                fileNames.AddRangeIfNotNullOrEmpty(SaveAttachmentToDirectory(attachment, path));

            return fileNames;
        }
        public IEnumerable<string> SaveAttachments(XstMessage? message, string path)
        {
            try
            {
                if (message == null)
                    return Enumerable.Empty<string>();

                var attachmentsToExport = message.Attachments.Where(a => a.IsFile && (!a.IsHidden || ExportOptions.ExportHiddenAttachments));
                if (!(attachmentsToExport?.Any() ?? false))
                    return Enumerable.Empty<string>();

                ExportProgress.IncrementMaximum(attachmentsToExport.Count());

                var subfolderPath = CreateDirForMessage(message, path);
                var fileNames = SaveAttachmentsToDirectory(attachmentsToExport, subfolderPath);
                if (!fileNames.Any())
                    try { Directory.Delete(subfolderPath); }
                    catch { }

                return fileNames;
            }
            finally { ExportProgress.Step($"Processed Attachments of Message {message}"); }
        }
        public IEnumerable<string> SaveAttachments(XstFolder? folder, string path)
        {
            try
            {
                if (folder == null)
                    return Enumerable.Empty<string>();

                var fileNames = new List<string>();

                ExportProgress.IncrementMaximum(folder.Messages.Count());
                ExportProgress.IncrementMaximum(ExportOptions.IncludeSubfolders, folder.Folders.Count());

                foreach (var message in folder.Messages.OrderBy(m => m.LastModificationTime))
                    fileNames.AddRangeIfNotNullOrEmpty(SaveAttachments(message, path));

                if (ExportOptions.IncludeSubfolders)
                {
                    foreach (var subFolder in folder.Folders.OrderBy(f => f.LastModificationTime))
                    {
                        var subfolderPath = CreateDirForFolder(subFolder, path);
                        var exportedAttachments = SaveAttachments(subFolder, subfolderPath);
                        if (!exportedAttachments.Any())
                            try { Directory.Delete(subfolderPath); }
                            catch { }
                        fileNames.AddRangeIfNotNullOrEmpty(exportedAttachments);
                    }
                }
                return fileNames;
            }
            finally { ExportProgress.Step($"Processed Attachments of Folder {folder}"); }
        }
        public IEnumerable<string> SaveAttachments(XstFile? xstFile, string path)
        {
            try
            {
                if (xstFile == null)
                    return Enumerable.Empty<string>();

                ExportProgress.IncrementMaximum();

                var fileNames = new List<string>();

                string rootFolderPath = CreateDirForFolder(xstFile.RootFolder, path);
                fileNames.AddRangeIfNotNullOrEmpty(SaveAttachments(xstFile.RootFolder, rootFolderPath));

                if (!fileNames.Any())
                    try { Directory.Delete(rootFolderPath); }
                    catch { }

                return fileNames;
            }
            finally { ExportProgress.Step($"Processed Attachments of File {xstFile}"); }
        }
        #endregion Attachments

        #region Messages
        public string SaveMessageOriginalToFile(XstMessage? message, string fileName)
        {
            try
            {
                if (message?.Body == null)
                    return "";

                File.WriteAllText(fileName, message.Body.Text);
                if (!File.Exists(fileName))
                    return "";

                if (message.Date.HasValue)
                    File.SetLastWriteTime(fileName, message.Date.Value);
                return fileName;
            }
            finally { ExportProgress.Step($"Processed Message {message} as original format"); }
        }

        public string SaveMessageMsgToFile(XstMessage? message, string fileName)
        {
            try
            {
                if (message == null)
                    return "";

                (new MessageXst(message)).Save(fileName);
                if (!File.Exists(fileName))
                    return "";

                if (message.Date.HasValue)
                    File.SetLastWriteTime(fileName, message.Date.Value);
                return fileName;
            }
            finally { ExportProgress.Step($"Processed Message {message} as MSG"); }
        }

        public string SaveMessageSingleHtmlToFile(XstMessage? message, string fileName)
        {
            try
            {
                if (message == null)
                    return "";

                try
                {
                    File.WriteAllText(fileName, MessageToSingleHtml.Render(message));
                    if (!File.Exists(fileName))
                        return "";

                    if (message.Date.HasValue)
                        File.SetLastWriteTime(fileName, message.Date.Value);
                }
                catch { return ""; }

                return fileName;
            }
            finally { ExportProgress.Step($"Processed Message {message} as Single HTML"); }
        }

        public IEnumerable<string> SaveMessage(XstMessage? message, string path)
        {
            try
            {
                if (message == null)
                    return Enumerable.Empty<string>();

                var fileNames = new List<string>();

                ExportProgress.IncrementMaximum(ExportOptions.ExportMessagesAsOriginal);
                ExportProgress.IncrementMaximum(ExportOptions.ExportMessagesAsMsg);
                ExportProgress.IncrementMaximum(ExportOptions.ExportMessagesAsSingleHtml);
                ExportProgress.IncrementMaximum(ExportOptions.ExportAttachmentsWithMessage);

                if(ExportOptions.ExportMessagesAsOriginal)
                {
                    string fileName = IOHelper.GetFileNameWithoutCollisions(Path.Combine(path, message.GetFilenameForSavingOriginal(ExportOptions)));
                    fileNames.AddIfNotNullOrEmpty(SaveMessageOriginalToFile(message, fileName));
                }
                if (ExportOptions.ExportMessagesAsMsg)
                {
                    string fileName = IOHelper.GetFileNameWithoutCollisions(Path.Combine(path, message.GetFilenameForSaving(ExportOptions) + ".msg"));
                    fileNames.AddIfNotNullOrEmpty(SaveMessageMsgToFile(message, fileName));
                }
                if (ExportOptions.ExportMessagesAsSingleHtml)
                {
                    string fileName = IOHelper.GetFileNameWithoutCollisions(Path.Combine(path, message.GetFilenameForSaving(ExportOptions) + ".html"));
                    fileNames.AddIfNotNullOrEmpty(SaveMessageSingleHtmlToFile(message, fileName));
                }
                if (ExportOptions.ExportAttachmentsWithMessage)
                {
                    fileNames.AddRangeIfNotNullOrEmpty(SaveAttachments(message, path));
                }

                return fileNames;
            }
            finally { ExportProgress.Step($"Processed Message {message}"); }
        }

        public IEnumerable<string> SaveMessages(XstFolder? folder, string path)
        {
            try
            {
                if (folder == null)
                    return Enumerable.Empty<string>();

                var fileNames = new List<string>();

                ExportProgress.IncrementMaximum(folder.Messages.Count());
                ExportProgress.IncrementMaximum(ExportOptions.IncludeSubfolders, folder.Folders.Count());

                foreach (var message in folder.Messages.OrderBy(m => m.LastModificationTime))
                    fileNames.AddRangeIfNotNullOrEmpty(SaveMessage(message, path));

                if (ExportOptions.IncludeSubfolders)
                {
                    foreach (var subFolder in folder.Folders.OrderBy(f => f.LastModificationTime))
                    {
                        var subfolderPath = CreateDirForFolder(subFolder, path);
                        var savedFiles = SaveMessages(subFolder, subfolderPath);
                        if (!savedFiles.Any())
                            try { Directory.Delete(subfolderPath); }
                            catch { }
                        fileNames.AddRangeIfNotNullOrEmpty(savedFiles);
                    }
                }
                return fileNames;
            }
            finally { ExportProgress.Step($"Processed Folder {folder}"); }
        }
        public IEnumerable<string> SaveMessages(XstFile? xstFile, string path)
        {
            try
            {
                if (xstFile == null)
                    return Enumerable.Empty<string>();

                var fileNames = new List<string>();

                ExportProgress.IncrementMaximum();

                string rootFolderPath = CreateDirForFolder(xstFile.RootFolder, path);
                fileNames.AddRangeIfNotNullOrEmpty(SaveMessages(xstFile.RootFolder, rootFolderPath));

                if (!fileNames.Any())
                    try { Directory.Delete(rootFolderPath); }
                    catch { }

                return fileNames;
            }
            finally { ExportProgress.Step($"Processed File {xstFile}"); }
        }
        #endregion Messages

    }
}
