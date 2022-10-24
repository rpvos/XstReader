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
    public partial class WaitingForm : Form
    {

        public WaitingForm()
        {
            InitializeComponent();
            Initialize();
        }
        public WaitingForm(string description) : this()
        {
            TitleLabel.Text = description;
        }

        private Action? Action { get; set; }

        //Action<ExportProgress>

        private void Initialize()
        {
            Cursor.Current = Cursors.WaitCursor;
            DescriptionLabel.Text = "";

            BackgroundWorker.RunWorkerCompleted += (s, e) => { try { Close(); } catch { } };
            BackgroundWorker.DoWork += (s, e) => Action?.Invoke();
            BackgroundWorker.ProgressChanged += (s, e) => BackgroundWorkerProgressChanged(e.UserState as ExportProgress);
        }

        private void BackgroundWorkerProgressChanged(ExportProgress? exportProgress)
        {
            if (exportProgress == null) 
                return;

            DescriptionLabel.Text = exportProgress.CurrentStepDescription;

            ProgressBar.Style = ProgressBarStyle.Continuous;
            ProgressBar.Maximum = exportProgress.Maximum;
            ProgressBar.Value = exportProgress.Value;
        }
        public void Start(Action action)
        {
            Action = action;
            BackgroundWorker.RunWorkerAsync();
        }

        public void Start(string description, Action action)
        {
            TitleLabel.Text = description;
            Start(action);
        }

        public void ReportExportProgress(ExportProgress exportProgress)
        {
            BackgroundWorker.ReportProgress(exportProgress.Percentage, exportProgress);
        }

        public static void Execute(string description, Action action)
        {
            using (var frm = new WaitingForm())
            {
                frm.Start(description, action);
                frm.ShowDialog();
            }
        }
    }
}
