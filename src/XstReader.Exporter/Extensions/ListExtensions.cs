using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XstReader.Exporter
{
    internal static class ListExtensions
    {
        public static void AddIfNotNullOrEmpty(this List<string> list, string str)
        {
            if(!string.IsNullOrEmpty(str))
                list.Add(str);
        }

        public static void AddRangeIfNotNullOrEmpty(this List<string> list, IEnumerable<string> lstStr)
        {
            list.AddRange(lstStr.Where(s=> !string.IsNullOrEmpty(s)));
        }

    }
}
