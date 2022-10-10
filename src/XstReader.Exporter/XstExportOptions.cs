// Project site: https://github.com/iluvadev/XstReader
//
// Based on the great work of Dijji. 
// Original project: https://github.com/dijji/XstReader
//
// Issues: https://github.com/iluvadev/XstReader/issues
// License (Ms-PL): https://github.com/iluvadev/XstReader/blob/master/license.md
//
// Copyright (c) 2021, iluvadev, and released under Ms-PL License.

using System.ComponentModel;

namespace XstReader.Exporter
{
    public class XstExportOptions
    {
        //IEPA!!
        //TODO:
        // Els Attachments exportats SEMPRE aniran en subcarpeta amb nom del missatge
        // Si no EmbedAttachmentsInFile, s'exportaran els Attachments (link)
        // Desar opcions

        public string FolderDirectoryPattern { get; set; } = "_$yyyy$MM$dd.$HH$mm$ss-$folder";
        public bool IncludeSubfolders { get; set; } = true;

        public string MessageFilePattern { get; set; } = "$yyyy$MM$dd.$HH$mm$ss-$subject";
        public bool ShowHeadersInMessages { get; set; } = true;
        public bool ShowDetails { get; set; } = true;
        public bool ShowPropertiesDescriptions { get; set; } = true;
        public bool EmbedAttachmentsInFile { get; set; } = true;
        public bool ExportAttachments { get; set; } = true;

        public bool ExportHiddenAttachments { get; set; } = false;


        public XstExportOptions Clone()
            => new XstExportOptions
            {
                FolderDirectoryPattern = FolderDirectoryPattern,
                IncludeSubfolders = IncludeSubfolders,
                MessageFilePattern = MessageFilePattern,
                ShowHeadersInMessages = ShowHeadersInMessages,
                ShowDetails = ShowDetails,
                ShowPropertiesDescriptions = ShowPropertiesDescriptions,
                EmbedAttachmentsInFile = EmbedAttachmentsInFile,
                ExportAttachments = ExportAttachments,
                ExportHiddenAttachments = ExportHiddenAttachments,
            };
    }
}
