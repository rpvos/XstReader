using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XstReader.Exporter.MsgKit.Helpers
{
    internal static class FilePath
    {
        /// <summary>
        ///     This method will convert a long filename to a short dos 8.3 one
        /// </summary>
        /// <param name="fileName">The long filename</param>
        /// <returns></returns>
        public static string? GetShortFileName(string fileName)
        {
            var name = Path.GetFileNameWithoutExtension(fileName);
            var extension = Path.GetExtension(fileName);

            if (name != null)
                name = (name.Length > 8 ? name.Substring(0, 6) + "~1" : name).ToUpperInvariant();

            if (extension != null)
                name += "." +
                        (extension.Length > 3 ? extension.Substring(1, 3) : extension.TrimStart('.')).ToUpperInvariant();

            return name;
        }
    }
}
