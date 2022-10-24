// Project site: https://github.com/iluvadev/XstReader
//
// Based on the great work of Dijji. 
// Original project: https://github.com/dijji/XstReader
//
// Issues: https://github.com/iluvadev/XstReader/issues
// License (Ms-PL): https://github.com/iluvadev/XstReader/blob/master/license.md
//
// Copyright (c) 2021, iluvadev, and released under Ms-PL License.

using System.Diagnostics;
using XstReader.Exporter;

namespace XstReader.App.Helpers
{
    public static class ExportHelper
    {
        private static readonly SaveFileDialog SaveFileDialog = new();
        private static readonly FolderBrowserDialog FolderBrowserDialog = new() { ShowNewFolderButton = true };

        private static bool ConfigureExport()
            => !ExportOptionsForm.IsFirstTime || new ExportOptionsForm().ShowDialog() == DialogResult.OK;

        private static bool AskDirectoryPath(ref string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
                FolderBrowserDialog.SelectedPath = path;

            if (FolderBrowserDialog.ShowDialog() != DialogResult.OK)
                return false;
            path = FolderBrowserDialog.SelectedPath;
            return true;
        }

        private static bool AskFileName(ref string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
                SaveFileDialog.FileName = fileName;

            if (SaveFileDialog.ShowDialog() != DialogResult.OK)
                return false;
            fileName = SaveFileDialog.FileName;
            return true;
        }

        public static bool ExportMessages<T>(T? elem) where T : XstElement
        {
            string path = "";

            if (elem != null && ConfigureExport() && AskDirectoryPath(ref path))
            {
                using (var frm = new WaitingForm($"Exporting Messages from {elem.DisplayName}"))
                {
                    var exporter = new XstExporter(XstReaderEnvironment.Options.ExportOptions, frm.ReportExportProgress);
                    Action? saveMessagesAct = null;
                    if (elem is XstFile file)
                        saveMessagesAct = () => exporter.SaveMessages(file, path);
                    else if (elem is XstFolder folder)
                        saveMessagesAct = () => exporter.SaveMessages(folder, path);
                    else if (elem is XstMessage message)
                        saveMessagesAct = () => exporter.SaveMessage(message, path);

                    if (saveMessagesAct != null)
                    {
                        frm.Start(saveMessagesAct);
                        frm.ShowDialog();
                        try { Process.Start(new ProcessStartInfo() { FileName = path, UseShellExecute = true }); }
                        catch { }
                    }
                }
            }
            return false;
        }

        public static bool ExportAttachments<T>(T? elem) where T : XstElement
        {
            string path = "";

            if (elem != null && ConfigureExport() && AskDirectoryPath(ref path))
            {
                using (var frm = new WaitingForm($"Exporting Messages from {elem.DisplayName}"))
                {
                    var exporter = new XstExporter(XstReaderEnvironment.Options.ExportOptions, frm.ReportExportProgress);
                    Action? saveMessagesAct = null;
                    if (elem is XstFile file)
                        saveMessagesAct = () => exporter.SaveAttachments(file, path);
                    else if (elem is XstFolder folder)
                        saveMessagesAct = () => exporter.SaveAttachments(folder, path);
                    else if (elem is XstMessage message)
                        saveMessagesAct = () => exporter.SaveAttachments(message, path);

                    if (saveMessagesAct != null)
                    {
                        frm.Start(saveMessagesAct);
                        frm.ShowDialog();
                        try { Process.Start(new ProcessStartInfo() { FileName = path, UseShellExecute = true }); }
                        catch { }
                    }
                }
            }
            return false;
        }
    }
}
