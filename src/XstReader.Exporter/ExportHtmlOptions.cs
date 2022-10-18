// Project site: https://github.com/iluvadev/XstReader
//
// Based on the great work of Dijji. 
// Original project: https://github.com/dijji/XstReader
//
// Issues: https://github.com/iluvadev/XstReader/issues
// License (Ms-PL): https://github.com/iluvadev/XstReader/blob/master/license.md
//
// Copyright (c) 2021, iluvadev, and released under Ms-PL License.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XstReader.Exporter
{
    public class ExportHtmlOptions
    {
        public bool ShowHeadersInMessages { get; set; } = true;
        public bool ShowDetails { get; set; } = true;
        public bool ShowPropertiesDescriptions { get; set; } = true;
        public bool EmbedAttachmentsInFile { get; set; } = true;


        public ExportHtmlOptions Clone()
           => new()
           {
               ShowHeadersInMessages = ShowHeadersInMessages,
               ShowDetails = ShowDetails,
               ShowPropertiesDescriptions = ShowPropertiesDescriptions,
               EmbedAttachmentsInFile = EmbedAttachmentsInFile,
           };
    }
}
