using XstReader.Exporter;

namespace XstReader.App
{
    public partial class ExportOptionsForm : Form
    {
        internal static bool IsFirstTime { get; private set;  } = true;

        private XstExportOptions? _Options = null;
        public XstExportOptions Options
        {
            get => _Options ??= new XstExportOptions();
            set
            {
                FolderPatternTextBox.Text = value.FolderDirectoryPattern;
                FolderSubfoldersCheckBox.Checked = value.IncludeSubfolders;
                MessagePatternTextBox.Text = value.MessageFilePattern;
                MessageDetailsCheckBox.Checked = value.ShowDetails;
                MessageDescPropertiesCheckBox.Checked = value.ShowPropertiesDescriptions;
                MessageEmbedAttCheckBox.Checked = value.EmbedAttachmentsInFile;
                MessageExportAttCheckBox.Checked = value.ExportAttachments;
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
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            Options.IncludeSubfolders = FolderSubfoldersCheckBox.Checked;
            Options.FolderDirectoryPattern = FolderPatternTextBox.Text;
            Options.MessageFilePattern = MessagePatternTextBox.Text;
            Options.ShowDetails = MessageDetailsCheckBox.Checked;
            Options.ShowPropertiesDescriptions = MessageDescPropertiesCheckBox.Checked;
            Options.EmbedAttachmentsInFile = MessageEmbedAttCheckBox.Checked;
            Options.ExportAttachments = MessageExportAttCheckBox.Checked;
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
