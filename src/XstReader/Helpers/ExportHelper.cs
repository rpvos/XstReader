// Project site: https://github.com/iluvadev/XstReader
//
// Based on the great work of Dijji. 
// Original project: https://github.com/dijji/XstReader
//
// Issues: https://github.com/iluvadev/XstReader/issues
// License (Ms-PL): https://github.com/iluvadev/XstReader/blob/master/license.md
//
// Copyright (c) 2021, iluvadev, and released under Ms-PL License.

using XstReader.Exporter;

namespace XstReader.App.Helpers
{
    public static class ExportHelper
    {
        private static SaveFileDialog SaveFileDialog = new();
        private static FolderBrowserDialog FolderBrowserDialog = new() { ShowNewFolderButton = true };

        private static ExporterAttachments attachmentExporter = new();

        public static bool ConfigureExport()
            => ExportOptionsForm.IsFirstTime ? new ExportOptionsForm().ShowDialog() == DialogResult.OK : true;

        public static bool AskDirectoryPath(ref string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
                FolderBrowserDialog.SelectedPath = path;

            if (FolderBrowserDialog.ShowDialog() != DialogResult.OK)
                return false;
            path = FolderBrowserDialog.SelectedPath;
            return true;
        }

        public static bool AskFileName(ref string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
                SaveFileDialog.FileName = fileName;

            if (SaveFileDialog.ShowDialog() != DialogResult.OK)
                return false;
            fileName = SaveFileDialog.FileName;
            return true;
        }

        public static bool ExportAttachmentsToDirectory(XstFolder? folder, string path)
        {
            if (folder == null)
                return false;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            bool ret = true;
            foreach (var message in folder.Messages.OrderBy(m => m.LastModificationTime))
            {
                if (!ExportAttachmentsToDirectory(message, path))
                    ret = false;
            }

            if (XstReaderEnvironment.Options.ExportOptions.IncludeSubfolders)
            {
                foreach (var subFolder in folder.Folders)
                {
                    var subfolderPathBase = Path.Combine(path, subFolder.GetDirnameForExport(XstReaderEnvironment.Options.ExportOptions));
                    var subfolderPath = subfolderPathBase;
                    int i = 1;
                    while (Directory.Exists(subfolderPath))
                        subfolderPath = $"{subfolderPathBase}({i++})";
                    if (!ExportAttachmentsToDirectory(subFolder, subfolderPath))
                        ret = false;
                }
            }
            return ret;
        }

        public static bool ExportAttachmentsToDirectory(XstMessage? message, string path)
        {
            if (message == null)
                return false;

            var attachmentsToExport = attachmentExporter.GetAttachmentsToExport(message, XstReaderEnvironment.Options.ExportOptions);
            if (!(attachmentsToExport?.Any() ?? false))
                return false;

            var subfolderPath = attachmentExporter.CreateDirForAttachments(message, path, XstReaderEnvironment.Options.ExportOptions);
            bool ret = true;
            foreach (var attachment in attachmentsToExport)
            {
                string fileName = attachmentExporter.ExportAttachmentToDirectory(attachment, subfolderPath);
                if (string.IsNullOrEmpty(fileName))
                    ret = false;
            }

            return ret;
        }

        public static bool ExportFolderToHtmlFiles(XstFolder? folder)
        {
            if (folder == null)
                return false;

            if (FolderBrowserDialog.ShowDialog() != DialogResult.OK)
                return false;

            return ExportFolderToHtmlFiles(folder, FolderBrowserDialog.SelectedPath);
        }
        public static bool ExportFolderToHtmlFiles(XstFolder? folder, string path)
        {
            if (folder == null)
                return false;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            bool ret = true;
            foreach (var message in folder.Messages.OrderBy(m => m.Date ?? DateTime.MinValue))
            {
                string fileNameBase = Path.Combine(path, message.GetFilenameForExport(XstReaderEnvironment.Options.ExportOptions));
                string fileName = fileNameBase + ".html";
                int i = 1;
                while (File.Exists(fileName))
                    fileName = $"{fileNameBase}({i++}).html";
                if (!ExportMessageToHtmlFile(message, fileName))
                    ret = false;
            }
            if (XstReaderEnvironment.Options.ExportOptions.IncludeSubfolders)
            {
                foreach (var subFolder in folder.Folders)
                {
                    var subfolderPathBase = Path.Combine(path, subFolder.GetDirnameForExport(XstReaderEnvironment.Options.ExportOptions));
                    var subfolderPath = subfolderPathBase;
                    int i = 1;
                    while (Directory.Exists(subfolderPath))
                        subfolderPath = $"{subfolderPathBase}({i++})";
                    if (!ExportFolderToHtmlFiles(subFolder, subfolderPath))
                        ret = false;
                }
            }
            return ret;
        }

        public static bool ExportMessageToHtmlFile(XstMessage? message, bool openFile)
        {
            string path = string.Empty;
            if (message != null && ConfigureExport() && AskDirectoryPath(ref path))
                return ExportMessageToHtmlFile(message, path, openFile);

            return false;
        }

        public static bool ExportMessageToHtmlFile(XstMessage? message, string path, bool openFile)
        {
            string fileNameBase = Path.Combine(path, message.GetFilenameForExport(XstReaderEnvironment.Options.ExportOptions));
            string fileName = fileNameBase + ".html";
            int i = 1;
            while (File.Exists(fileName))
                fileName = $"{fileNameBase}({i++}).html";

            bool ret = ExportMessageToHtmlFile(message, fileName);
            if (ret && openFile)
                SystemHelper.OpenWith(SaveFileDialog.FileName);

            return ret;
        }

        private static bool ExportMessageToHtmlFile(XstMessage? message, string fileName)
        {
            if (message == null)
                return false;

            try
            {
                File.WriteAllText(fileName, message.RenderAsHtml(false));
                if (message.Date.HasValue)
                    File.SetLastWriteTime(fileName, message.Date.Value);
                if (XstReaderEnvironment.Options.ExportOptions.ExportAttachments)
                {
                    var path = Path.GetDirectoryName(fileName);
                    if (!string.IsNullOrEmpty(path))
                        ExportAttachmentsToDirectory(message, path);
                }


            }
            catch { return false; }
            return true;
        }
    }
}
