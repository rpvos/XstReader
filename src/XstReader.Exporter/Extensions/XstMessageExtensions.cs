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
    public static class XstMessageExtensions
    {
        public static string GetNameWithPattern(this XstMessage message, string pattern)
        {
            string name = pattern.AppyPatternTo(message.GetDate(), message.ParentFolder.DisplayName, message.Subject);
            if (string.IsNullOrEmpty(name))
                name = message.Subject;

            return name;
        }

        public static string GetFilenameForSaving(this XstMessage? message, ExportOptions options)
            => message?.GetNameWithPattern(options.MessageFilePattern).ReplaceInvalidFileNameChars("_") ?? "message";

        public static string GetFilenameForSavingOriginal(this XstMessage? message, ExportOptions options)
        {
            var fileName = GetFilenameForSaving(message, options);
            switch (message?.Body?.Format)
            {
                case XstMessageBodyFormat.Html: return fileName + ".html";
                case XstMessageBodyFormat.PlainText: return fileName + ".txt";
                case XstMessageBodyFormat.Rtf: return fileName + ".rtf";
            }
            return fileName;
        }

    }
}
