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
    public static class XstFolderExtensions
    {
        public static string GetNameWithPattern(this XstFolder folder, string pattern)
        {
            string name = pattern.AppyPatternTo(folder.GetDate(), folder.DisplayName, "");
            if (string.IsNullOrEmpty(name))
                name = folder.DisplayName;

            return name;
        }

        public static string GetDirnameForExport(this XstFolder? folder, XstExportOptions options)
            => folder?.GetNameWithPattern(options.FolderDirectoryPattern).ReplaceInvalidFileNameChars("_") ?? "folder";

    }
}
