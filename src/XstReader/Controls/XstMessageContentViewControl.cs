﻿using Krypton.Docking;
using XstReader.App.Common;

namespace XstReader.App.Controls
{
    public partial class XstMessageContentViewControl : UserControl,
                                                        IXstDataSourcedControl<XstMessage>,
                                                        IXstElementDoubleClickable<XstElement>
    {
        private XstRecipientListControl RecipientListControl { get; } = new XstRecipientListControl() { Name = "Recipients List" };
        private XstAttachmentListControl AttachmentListControl { get; } = new XstAttachmentListControl() { Name = "Attachments List" };


        public XstMessageContentViewControl()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            if (DesignMode) return;

            RecipientListControl.SelectedItemChanged += (s, e) => RaiseSelectedItemChanged(e.Element);
            RecipientListControl.GotFocus += (s, e) => RaiseSelectedItemChanged();
            RecipientListControl.DoubleClickItem += (s, e) => RaiseDoubleClickItem(e.Element);

            AttachmentListControl.SelectedItemChanged += (s, e) => RaiseSelectedItemChanged(e.Element);
            AttachmentListControl.GotFocus += (s, e) => RaiseSelectedItemChanged();
            AttachmentListControl.DoubleClickItem += (s, e) => RaiseDoubleClickItem(e.Element);

            ExportPdfToolStripButton.Enabled = false;
            ExportPdfToolStripButton.Click += (s, e) => ExportToPdf();

            WebView2.CoreWebView2InitializationCompleted += (s, e) =>
            {
                if (ToDoWhenInitialized?.Any() ?? false)
                    ToDoWhenInitialized.ForEach(a => a?.Invoke());
                ToDoWhenInitialized?.Clear();

                IsCoreViewInitialized = true;
            };
            WebView2.EnsureCoreWebView2Async();
        }

        private bool IsCoreViewInitialized { get; set; } = false;
        private List<Action> ToDoWhenInitialized { get; set; } = new List<Action>();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            OnLoad();
        }

        private void OnLoad()
        {
            KryptonDockingManager.ManageControl(MainKryptonPanel);
            KryptonDockingManager.AddXstDockSpaceInStack(DockingEdge.Top, RecipientListControl, AttachmentListControl);
        }

        public event EventHandler<XstElementEventArgs>? SelectedItemChanged;

        private void RaiseSelectedItemChanged() => RaiseSelectedItemChanged(GetSelectedItem());
        private void RaiseSelectedItemChanged(XstElement? element) => SelectedItemChanged?.Invoke(this, new XstElementEventArgs(element));

        public event EventHandler<XstElementEventArgs>? DoubleClickItem;
        private void RaiseDoubleClickItem(XstElement? element) => DoubleClickItem?.Invoke(this, new XstElementEventArgs(element));

        private XstMessage? _DataSource;
        public XstMessage? GetDataSource()
            => _DataSource;

        public void SetDataSource(XstMessage? dataSource)
        {
            CleanTempFile();
            _DataSource = dataSource;

            ExportPdfToolStripButton.Enabled = _DataSource != null;

            RecipientListControl.SetDataSource(dataSource?.Recipients.Items);
            AttachmentListControl.SetDataSource(dataSource?.Attachments);

            var htmlText = _DataSource?.GetHtmlVisualization() ?? "";
            ExecuteWhenCoreViewInitialized(() =>
            {
                try
                {
                    if (htmlText.Length < 1500000)
                        WebView2.NavigateToString(htmlText);
                    else
                        WebView2.Source = new Uri(SetTempFileContent(htmlText));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error showing message");
                }
            });
        }

        private void ExecuteWhenCoreViewInitialized(Action action)
        {
            if (action == null)
                return;

            if (!IsCoreViewInitialized)
                ToDoWhenInitialized.Add(action);
            else
                action.Invoke();
        }

        private void ExportToPdf()
        {
            if (_DataSource == null)
                return;

            SaveFileDialog.FileName = _DataSource.DisplayName + ".pdf";

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                WebView2.CoreWebView2.PrintToPdfAsync(SaveFileDialog.FileName);
        }

        public XstElement? GetSelectedItem()
        {
            if (RecipientListControl.Focused)
                return RecipientListControl.GetSelectedItem();
            if (AttachmentListControl.Focused)
                return AttachmentListControl.GetSelectedItem();

            return _DataSource;
        }

        public void SetSelectedItem(XstElement? item)
        { }

        private string? _TempFileName = null;
        private void CleanTempFile()
        {
            if (_TempFileName != null && File.Exists(_TempFileName))
                try { File.Delete(_TempFileName); }
                catch { }
            _TempFileName = null;
        }
        private string SetTempFileContent(string text)
        {
            _TempFileName = Path.GetTempFileName() + ".html";
            File.WriteAllText(_TempFileName, text);

            return _TempFileName;
        }
        public void ClearContents()
        {
            RecipientListControl.ClearContents();
            AttachmentListControl.ClearContents();

            GetDataSource()?.ClearContents();
            SetDataSource(null);
        }
    }
}
