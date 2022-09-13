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
using XstReader.Exporter;

namespace XstReader.App
{
    internal class XstReaderOptions
    {
        public XstReaderViewOptions ViewOptions { get; set; } = new XstReaderViewOptions();

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public XstExportOptions HtmlExportOptions { get; set; } = new XstExportOptions();

        public XstAttachmentExportOptions AttachmentExportOptions { get; set; } = new XstAttachmentExportOptions();
    }
}
