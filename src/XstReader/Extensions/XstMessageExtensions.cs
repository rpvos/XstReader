using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XstReader.Exporter;

namespace XstReader.App
{
    internal static class XstMessageExtensions
    {
        internal static string RenderAsHtml(this XstMessage? message)
        {
            if (message == null)
                return string.Empty;

            var options = new ExportHtmlOptions
            {
                EmbedAttachmentsInFile = false,
                ShowDetails = false
            };
            var exporter = new MessageToSingleHtml(options);

            return exporter.Render(message);
        }

    }
}
