namespace XstReader.App
{
    partial class ExportOptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportOptionsForm));
            this.BottomPanel = new Krypton.Toolkit.KryptonPanel();
            this.UserCancelButton = new System.Windows.Forms.Button();
            this.UserOkButton = new System.Windows.Forms.Button();
            this.MainPanel = new Krypton.Toolkit.KryptonPanel();
            this.AttributePanel = new Krypton.Toolkit.KryptonPanel();
            this.AttributeExportHiddenCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.AttributeKryptonLabel = new Krypton.Toolkit.KryptonLabel();
            this.MessagePanel = new Krypton.Toolkit.KryptonPanel();
            this.MessageEmbedAttCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.MessageDescPropertiesCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.MessageDetailsCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.MessagePatternTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.MessageKryptonLabel = new Krypton.Toolkit.KryptonLabel();
            this.FolderPanel = new Krypton.Toolkit.KryptonPanel();
            this.FolderSubfoldersCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.FolderPatternTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.FoldersKryptonLabel = new Krypton.Toolkit.KryptonLabel();
            this.HelpPanel = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.FormatLabel = new Krypton.Toolkit.KryptonLabel();
            this.MessageExportAttCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.BottomPanel)).BeginInit();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttributePanel)).BeginInit();
            this.AttributePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessagePanel)).BeginInit();
            this.MessagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FolderPanel)).BeginInit();
            this.FolderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpPanel)).BeginInit();
            this.HelpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.UserCancelButton);
            this.BottomPanel.Controls.Add(this.UserOkButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 454);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(675, 43);
            this.BottomPanel.TabIndex = 5;
            // 
            // CancelButton
            // 
            this.UserCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserCancelButton.Location = new System.Drawing.Point(0, 6);
            this.UserCancelButton.Name = "CancelButton";
            this.UserCancelButton.Size = new System.Drawing.Size(87, 31);
            this.UserCancelButton.TabIndex = 1;
            this.UserCancelButton.Text = "Cancel";
            this.UserCancelButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.UserOkButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UserOkButton.Location = new System.Drawing.Point(588, 9);
            this.UserOkButton.Name = "OkButton";
            this.UserOkButton.Size = new System.Drawing.Size(87, 31);
            this.UserOkButton.TabIndex = 0;
            this.UserOkButton.Text = "OK";
            this.UserOkButton.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.AttributePanel);
            this.MainPanel.Controls.Add(this.MessagePanel);
            this.MainPanel.Controls.Add(this.FolderPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MainPanel.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.MainPanel.Size = new System.Drawing.Size(391, 454);
            this.MainPanel.TabIndex = 6;
            // 
            // AttributePanel
            // 
            this.AttributePanel.Controls.Add(this.AttributeExportHiddenCheckBox);
            this.AttributePanel.Controls.Add(this.AttributeKryptonLabel);
            this.AttributePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttributePanel.Location = new System.Drawing.Point(5, 365);
            this.AttributePanel.Name = "AttributePanel";
            this.AttributePanel.Padding = new System.Windows.Forms.Padding(10);
            this.AttributePanel.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.TabOneNote;
            this.AttributePanel.Size = new System.Drawing.Size(381, 84);
            this.AttributePanel.TabIndex = 2;
            // 
            // AttributeExportHiddenCheckBox
            // 
            this.AttributeExportHiddenCheckBox.AutoSize = false;
            this.AttributeExportHiddenCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.AttributeExportHiddenCheckBox.Location = new System.Drawing.Point(10, 43);
            this.AttributeExportHiddenCheckBox.Name = "AttributeExportHiddenCheckBox";
            this.AttributeExportHiddenCheckBox.Size = new System.Drawing.Size(361, 25);
            this.AttributeExportHiddenCheckBox.TabIndex = 0;
            this.AttributeExportHiddenCheckBox.Values.Text = "Export Hidden Attachments";
            // 
            // AttributeKryptonLabel
            // 
            this.AttributeKryptonLabel.AutoSize = false;
            this.AttributeKryptonLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AttributeKryptonLabel.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
            this.AttributeKryptonLabel.Location = new System.Drawing.Point(10, 10);
            this.AttributeKryptonLabel.Name = "AttributeKryptonLabel";
            this.AttributeKryptonLabel.Size = new System.Drawing.Size(361, 33);
            this.AttributeKryptonLabel.TabIndex = 3;
            this.AttributeKryptonLabel.Values.Text = "Export Attributes:";
            // 
            // MessagePanel
            // 
            this.MessagePanel.Controls.Add(this.MessageExportAttCheckBox);
            this.MessagePanel.Controls.Add(this.MessageEmbedAttCheckBox);
            this.MessagePanel.Controls.Add(this.MessageDescPropertiesCheckBox);
            this.MessagePanel.Controls.Add(this.MessageDetailsCheckBox);
            this.MessagePanel.Controls.Add(this.kryptonLabel2);
            this.MessagePanel.Controls.Add(this.MessagePatternTextBox);
            this.MessagePanel.Controls.Add(this.kryptonLabel3);
            this.MessagePanel.Controls.Add(this.MessageKryptonLabel);
            this.MessagePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessagePanel.Location = new System.Drawing.Point(5, 131);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Padding = new System.Windows.Forms.Padding(10);
            this.MessagePanel.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.TabOneNote;
            this.MessagePanel.Size = new System.Drawing.Size(381, 234);
            this.MessagePanel.TabIndex = 1;
            // 
            // MessageEmbedAttCheckBox
            // 
            this.MessageEmbedAttCheckBox.AutoSize = false;
            this.MessageEmbedAttCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageEmbedAttCheckBox.Location = new System.Drawing.Point(10, 166);
            this.MessageEmbedAttCheckBox.Name = "MessageEmbedAttCheckBox";
            this.MessageEmbedAttCheckBox.Size = new System.Drawing.Size(361, 25);
            this.MessageEmbedAttCheckBox.TabIndex = 3;
            this.MessageEmbedAttCheckBox.Values.Text = "Embed Attachments inside Html file";
            // 
            // MessageDescPropertiesCheckBox
            // 
            this.MessageDescPropertiesCheckBox.AutoSize = false;
            this.MessageDescPropertiesCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageDescPropertiesCheckBox.Location = new System.Drawing.Point(10, 141);
            this.MessageDescPropertiesCheckBox.Name = "MessageDescPropertiesCheckBox";
            this.MessageDescPropertiesCheckBox.Size = new System.Drawing.Size(361, 25);
            this.MessageDescPropertiesCheckBox.TabIndex = 2;
            this.MessageDescPropertiesCheckBox.Values.Text = "Show Description of used Properties";
            // 
            // MessageDetailsCheckBox
            // 
            this.MessageDetailsCheckBox.AutoSize = false;
            this.MessageDetailsCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageDetailsCheckBox.Location = new System.Drawing.Point(10, 116);
            this.MessageDetailsCheckBox.Name = "MessageDetailsCheckBox";
            this.MessageDetailsCheckBox.Size = new System.Drawing.Size(361, 25);
            this.MessageDetailsCheckBox.TabIndex = 1;
            this.MessageDetailsCheckBox.Values.Text = "Show Details section";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.AutoSize = false;
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(10, 86);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(361, 30);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Export as single Html file:";
            // 
            // MessagePatternTextBox
            // 
            this.MessagePatternTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessagePatternTextBox.Location = new System.Drawing.Point(10, 63);
            this.MessagePatternTextBox.Name = "MessagePatternTextBox";
            this.MessagePatternTextBox.Size = new System.Drawing.Size(361, 23);
            this.MessagePatternTextBox.TabIndex = 5;
            this.MessagePatternTextBox.Text = "$yyyy$MM$dd$HH$mm$ss-$subject";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.AutoSize = false;
            this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonLabel3.Location = new System.Drawing.Point(10, 43);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(361, 20);
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "File name pattern for Messages:";
            // 
            // MessageKryptonLabel
            // 
            this.MessageKryptonLabel.AutoSize = false;
            this.MessageKryptonLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageKryptonLabel.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
            this.MessageKryptonLabel.Location = new System.Drawing.Point(10, 10);
            this.MessageKryptonLabel.Name = "MessageKryptonLabel";
            this.MessageKryptonLabel.Size = new System.Drawing.Size(361, 33);
            this.MessageKryptonLabel.TabIndex = 2;
            this.MessageKryptonLabel.Values.Text = "Messages:";
            // 
            // FolderPanel
            // 
            this.FolderPanel.Controls.Add(this.FolderSubfoldersCheckBox);
            this.FolderPanel.Controls.Add(this.FolderPatternTextBox);
            this.FolderPanel.Controls.Add(this.kryptonLabel1);
            this.FolderPanel.Controls.Add(this.FoldersKryptonLabel);
            this.FolderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FolderPanel.Location = new System.Drawing.Point(5, 5);
            this.FolderPanel.Name = "FolderPanel";
            this.FolderPanel.Padding = new System.Windows.Forms.Padding(10);
            this.FolderPanel.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.TabOneNote;
            this.FolderPanel.Size = new System.Drawing.Size(381, 126);
            this.FolderPanel.TabIndex = 0;
            // 
            // FolderSubfoldersCheckBox
            // 
            this.FolderSubfoldersCheckBox.AutoSize = false;
            this.FolderSubfoldersCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.FolderSubfoldersCheckBox.Location = new System.Drawing.Point(10, 86);
            this.FolderSubfoldersCheckBox.Name = "FolderSubfoldersCheckBox";
            this.FolderSubfoldersCheckBox.Size = new System.Drawing.Size(361, 35);
            this.FolderSubfoldersCheckBox.TabIndex = 1;
            this.FolderSubfoldersCheckBox.Values.Text = "Export all subfolders";
            // 
            // FolderPatternTextBox
            // 
            this.FolderPatternTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.FolderPatternTextBox.Location = new System.Drawing.Point(10, 63);
            this.FolderPatternTextBox.Name = "FolderPatternTextBox";
            this.FolderPatternTextBox.Size = new System.Drawing.Size(361, 23);
            this.FolderPatternTextBox.TabIndex = 0;
            this.FolderPatternTextBox.Text = "_$yyyy$MM$dd$HH$mm$ss-$folder";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = false;
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonLabel1.Location = new System.Drawing.Point(10, 43);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(361, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Directory name pattern for Folders:";
            // 
            // FoldersKryptonLabel
            // 
            this.FoldersKryptonLabel.AutoSize = false;
            this.FoldersKryptonLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FoldersKryptonLabel.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
            this.FoldersKryptonLabel.Location = new System.Drawing.Point(10, 10);
            this.FoldersKryptonLabel.Name = "FoldersKryptonLabel";
            this.FoldersKryptonLabel.Size = new System.Drawing.Size(361, 33);
            this.FoldersKryptonLabel.TabIndex = 1;
            this.FoldersKryptonLabel.Values.Text = "Export Folders:";
            // 
            // HelpPanel
            // 
            this.HelpPanel.Controls.Add(this.kryptonLabel4);
            this.HelpPanel.Controls.Add(this.FormatLabel);
            this.HelpPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.HelpPanel.Location = new System.Drawing.Point(391, 0);
            this.HelpPanel.Name = "HelpPanel";
            this.HelpPanel.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.HelpPanel.Size = new System.Drawing.Size(284, 454);
            this.HelpPanel.TabIndex = 3;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.AutoSize = false;
            this.kryptonLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonLabel4.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(0, 33);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(284, 184);
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = resources.GetString("kryptonLabel4.Values.Text");
            // 
            // FormatLabel
            // 
            this.FormatLabel.AutoSize = false;
            this.FormatLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormatLabel.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
            this.FormatLabel.Location = new System.Drawing.Point(0, 0);
            this.FormatLabel.Name = "FormatLabel";
            this.FormatLabel.Size = new System.Drawing.Size(284, 33);
            this.FormatLabel.TabIndex = 2;
            this.FormatLabel.Values.Text = "Format patterns:";
            // 
            // MessageExportAttCheckBox
            // 
            this.MessageExportAttCheckBox.AutoSize = false;
            this.MessageExportAttCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageExportAttCheckBox.Location = new System.Drawing.Point(10, 191);
            this.MessageExportAttCheckBox.Name = "MessageExportAttCheckBox";
            this.MessageExportAttCheckBox.Size = new System.Drawing.Size(361, 25);
            this.MessageExportAttCheckBox.TabIndex = 7;
            this.MessageExportAttCheckBox.Values.Text = "Export Attachments as files";
            // 
            // ExportOptionsForm
            // 
            this.AcceptButton = this.UserOkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 497);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.HelpPanel);
            this.Controls.Add(this.BottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(100, 200);
            this.Name = "ExportOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Export Options";
            ((System.ComponentModel.ISupportInitialize)(this.BottomPanel)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttributePanel)).EndInit();
            this.AttributePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MessagePanel)).EndInit();
            this.MessagePanel.ResumeLayout(false);
            this.MessagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FolderPanel)).EndInit();
            this.FolderPanel.ResumeLayout(false);
            this.FolderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpPanel)).EndInit();
            this.HelpPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel BottomPanel;
        private Button UserCancelButton;
        private Button UserOkButton;
        private Krypton.Toolkit.KryptonPanel MainPanel;
        private Krypton.Toolkit.KryptonLabel FoldersKryptonLabel;
        private Krypton.Toolkit.KryptonLabel MessageKryptonLabel;
        private Krypton.Toolkit.KryptonLabel AttributeKryptonLabel;
        private Krypton.Toolkit.KryptonPanel FolderPanel;
        private Krypton.Toolkit.KryptonPanel MessagePanel;
        private Krypton.Toolkit.KryptonPanel AttributePanel;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonCheckBox AttributeExportHiddenCheckBox;
        private Krypton.Toolkit.KryptonTextBox FolderPatternTextBox;
        private Krypton.Toolkit.KryptonCheckBox MessageDescPropertiesCheckBox;
        private Krypton.Toolkit.KryptonCheckBox MessageDetailsCheckBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonCheckBox MessageEmbedAttCheckBox;
        private Krypton.Toolkit.KryptonCheckBox FolderSubfoldersCheckBox;
        private Krypton.Toolkit.KryptonPanel HelpPanel;
        private Krypton.Toolkit.KryptonTextBox MessagePatternTextBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel FormatLabel;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonCheckBox MessageExportAttCheckBox;
    }
}