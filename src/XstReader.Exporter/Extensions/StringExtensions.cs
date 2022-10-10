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
    internal static class StringExtensions
    {
        public static string AppyPatternTo(this string pattern, DateTime date, string folder, string subject)
        {
            return pattern.Replace("$yyyy", date.ToString("yyyy"))
                          .Replace("$MM", date.ToString("MM"))
                          .Replace("$dd", date.ToString("dd"))
                          .Replace("$HH", date.ToString("HH"))
                          .Replace("$mm", date.ToString("mm"))
                          .Replace("$ss", date.ToString("ss"))
                          .Replace("$folder", folder)
                          .Replace("$subject", subject)
                          .Trim();
        }
    }
}
