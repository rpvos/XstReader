// Project site: https://github.com/iluvadev/XstReader
//
// Based on the great work of Dijji. 
// Original project: https://github.com/dijji/XstReader
//
// Issues: https://github.com/iluvadev/XstReader/issues
// License (Ms-PL): https://github.com/iluvadev/XstReader/blob/master/license.md
//
// Copyright (c) 2021, iluvadev, and released under Ms-PL License.

using XstReader.Exporter;

namespace XstReader.App
{
    public partial class ExportAttachmentOptionsForm : Form
    {
        private XstAttachmentExportOptions? _Options = null;
        public XstAttachmentExportOptions Options
        {
            get => _Options ??= new XstAttachmentExportOptions();
            set
            {
                _Options = value;
                IncludeHiddenCheckBox.Checked = value.IncludeHidden;
                InFoldersCheckBox.Checked = value.EachMessageInFolder;
            }
        }

        public ExportAttachmentOptionsForm()
        {
            InitializeComponent();
            Options = new XstAttachmentExportOptions();
        }

        public ExportAttachmentOptionsForm(XstAttachmentExportOptions options) : this()
        {
            Options = options;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Options.IncludeHidden = IncludeHiddenCheckBox.Checked;
            Options.EachMessageInFolder = InFoldersCheckBox.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
