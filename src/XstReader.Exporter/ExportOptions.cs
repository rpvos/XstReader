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
    public class ExportOptions
    {
        public ExportHtmlOptions SingleHtmlOptions { get; set; } = new ExportHtmlOptions();

        public string FolderDirectoryPattern { get; set; } = "_$yyyy$MM$dd.$HH$mm$ss-$folder";
        public bool IncludeSubfolders { get; set; } = true;

        public string MessageFilePattern { get; set; } = "$yyyy$MM$dd.$HH$mm$ss-$subject";

        public bool ExportMessagesAsSingleHtml { get; set; } = true;
        public bool ExportMessagesAsMsg { get; set; } = false;

        public bool ExportAttachmentsWithMessage { get; set; } = false;

        public bool ExportHiddenAttachments { get; set; } = false;


        public ExportOptions Clone()
            => new ExportOptions
            {
                SingleHtmlOptions = SingleHtmlOptions.Clone(),
                FolderDirectoryPattern = FolderDirectoryPattern,
                MessageFilePattern = MessageFilePattern,
                IncludeSubfolders = IncludeSubfolders,
                ExportMessagesAsSingleHtml = ExportMessagesAsSingleHtml,
                ExportMessagesAsMsg = ExportMessagesAsMsg,
                ExportAttachmentsWithMessage = ExportAttachmentsWithMessage,
                ExportHiddenAttachments = ExportHiddenAttachments,
            };
    }
}
