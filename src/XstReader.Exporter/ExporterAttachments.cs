// Project site: https://github.com/iluvadev/XstReader
//
// Based on the great work of Dijji. 
// Original project: https://github.com/dijji/XstReader
//
// Issues: https://github.com/iluvadev/XstReader/issues
// License (Ms-PL): https://github.com/iluvadev/XstReader/blob/master/license.md
//
// Copyright (c) 2021, iluvadev, and released under Ms-PL License.

namespace XstReader.Exporter
{
    public class ExporterAttachments
    {
        public IEnumerable<XstAttachment>? GetAttachmentsToExport(XstMessage? message, XstExportOptions options)
            => message?.Attachments?.Where(a => a.IsFile && (!a.IsHidden || options.ExportHiddenAttachments))
                                    .OrderBy(a => a.LastModificationTime);

        public string CreateDirForAttachments(XstMessage? message, string path, XstExportOptions options)
        {
            if (message == null)
                return "";
            if (!(GetAttachmentsToExport(message, options)?.Any() ?? false))
                return "";

            var subfolderPathBase = Path.Combine(path, message.GetFilenameForExport(options));
            var subfolderPath = subfolderPathBase;
            int i = 1;
            while (Directory.Exists(subfolderPath))
                subfolderPath = $"{subfolderPathBase}({i++})";

            if (!Directory.Exists(subfolderPath))
                Directory.CreateDirectory(subfolderPath);

            if (Directory.Exists(subfolderPath))
                Directory.SetLastWriteTime(subfolderPath, message.Date ?? DateTime.Now);

            return subfolderPath;
        }

        public string ExportAttachmentToDirectory(XstAttachment? attachment, string path)
        {
            if (attachment == null)
                return "";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string extension = Path.GetExtension(attachment.FileNameForSaving);
            string fileNameBase = Path.Combine(path, Path.GetFileNameWithoutExtension(attachment.FileNameForSaving));
            string fileName = fileNameBase + extension;
            int i = 1;
            while (File.Exists(fileName))
                fileName = $"{fileNameBase}({i++}){extension}";
            try { attachment.SaveToFile(fileName); }
            catch { fileName = ""; }

            return fileName;
        }
    }
}
