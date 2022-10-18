namespace XstReader.Exporter.Helpers
{
    internal static class IOHelper
    {
        public static string GetDirNameWithoutCollisions(string proposedPath)
        {
            var folderPath = proposedPath;
            int i = 1;
            while (Directory.Exists(folderPath))
                folderPath = $"{proposedPath}({i++})";

            return folderPath;
        }

        public static string GetFileNameWithoutCollisions(string proposedFileName)
        {
            string extension = Path.GetExtension(proposedFileName);
            string fileNameBase = Path.Combine(Path.GetDirectoryName(proposedFileName) ?? "", Path.GetFileNameWithoutExtension(proposedFileName));
            string fileName = fileNameBase + extension;
            int i = 1;
            while (File.Exists(fileName))
                fileName = $"{fileNameBase}({i++}){extension}";

            return fileName;
        }
    }
}
