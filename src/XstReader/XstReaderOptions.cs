// Project site: https://github.com/iluvadev/XstReader
//
// Based on the great work of Dijji. 
// Original project: https://github.com/dijji/XstReader
//
// Issues: https://github.com/iluvadev/XstReader/issues
// License (Ms-PL): https://github.com/iluvadev/XstReader/blob/master/license.md
//
// Copyright (c) 2021, iluvadev, and released under Ms-PL License.

using System.Xml;
using System.Xml.Serialization;
using XstReader.Exporter;

namespace XstReader.App
{
    public class XstReaderOptions
    {
        public XstReaderViewOptions ViewOptions { get; set; } = new XstReaderViewOptions();
        public XstExportOptions ExportOptions { get; set; } = new XstExportOptions();

        public static void SaveToFile(string fileName, XstReaderOptions options)
        {
            var serializer = new XmlSerializer(options.GetType());
            using (var writer = XmlWriter.Create(fileName))
                serializer.Serialize(writer, options);
        }

        public static XstReaderOptions LoadFromFile(string fileName)
        {
            XstReaderOptions options;
            var serializer = new XmlSerializer(typeof(XstReaderOptions));
            using (var reader = XmlReader.Create(fileName))
                options = (XstReaderOptions?)serializer.Deserialize(reader) ?? new XstReaderOptions();
            return options;
        }
    }
}
