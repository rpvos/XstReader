using XstReader.Exporter;

namespace XstReader.App
{
    public partial class ExportOptionsForm : Form
    {
        internal static bool IsFirstTime { get; private set; } = true;

        private ExportOptions? _Options = null;
        public ExportOptions Options
        {
            get => _Options ??= new ExportOptions();
            set
            {
                FolderPatternTextBox.Text = value.FolderDirectoryPattern;
                FolderSubfoldersCheckBox.Checked = value.IncludeSubfolders;
                MessagePatternTextBox.Text = value.MessageFilePattern;
                MessageExportHtmlCheckBox.Checked = value.ExportMessagesAsSingleHtml;
                MessageExportMsgCheckBox.Checked = value.ExportMessagesAsMsg;
                MessageExportOriginalCheckBox.Checked = value.ExportMessagesAsOriginal;

                MessageDetailsCheckBox.Checked = value.SingleHtmlOptions.ShowDetails;
                MessageDescPropertiesCheckBox.Checked = value.SingleHtmlOptions.ShowPropertiesDescriptions;
                MessageEmbedAttCheckBox.Checked = value.SingleHtmlOptions.EmbedAttachmentsInFile;

                MessageExportAttCheckBox.Checked = value.ExportAttachmentsWithMessage;
                AttributeExportHiddenCheckBox.Checked = value.ExportHiddenAttachments;
                _Options = value;
            }
        }

        public ExportOptionsForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Options = XstReaderEnvironment.Options.ExportOptions;
            UserOkButton.Click += OkButton_Click;
            UserCancelButton.Click += CancelButton_Click;

            MessageSingleHtmlPanel.Enabled = MessageExportHtmlCheckBox.Checked;
            MessageExportHtmlCheckBox.CheckedChanged += (s, e) 
                => MessageSingleHtmlPanel.Enabled = MessageExportHtmlCheckBox.Checked;
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            Options.IncludeSubfolders = FolderSubfoldersCheckBox.Checked;
            Options.FolderDirectoryPattern = FolderPatternTextBox.Text;
            Options.MessageFilePattern = MessagePatternTextBox.Text;

            Options.ExportMessagesAsSingleHtml = MessageExportHtmlCheckBox.Checked;
            Options.ExportMessagesAsMsg = MessageExportMsgCheckBox.Checked;
            Options.ExportMessagesAsOriginal = MessageExportOriginalCheckBox.Checked;

            Options.SingleHtmlOptions.ShowDetails = MessageDetailsCheckBox.Checked;
            Options.SingleHtmlOptions.ShowPropertiesDescriptions = MessageDescPropertiesCheckBox.Checked;
            Options.SingleHtmlOptions.EmbedAttachmentsInFile = MessageEmbedAttCheckBox.Checked;

            Options.ExportAttachmentsWithMessage = MessageExportAttCheckBox.Checked;
            Options.ExportHiddenAttachments = AttributeExportHiddenCheckBox.Checked;

            DialogResult = DialogResult.OK;
            IsFirstTime = false;

            Close();
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
