namespace XstReader.App.Controls
{
    partial class XstAttachmentListControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ObjectListView = new BrightIdeasSoftware.ObjectListView();
            KryptonToolStrip = new Krypton.Toolkit.KryptonToolStrip();
            SaveToolStripButton = new ToolStripButton();
            SaveAllToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            OpenInAppToolStripButton = new ToolStripButton();
            OpenWithToolStripMenuItem = new ToolStripButton();
            ShowHiddenToolStripButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            SaveFileDialog = new SaveFileDialog();
            FolderBrowserDialog = new FolderBrowserDialog();
            ErrorLabel = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)ObjectListView).BeginInit();
            KryptonToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ObjectListView
            // 
            ObjectListView.AllowColumnReorder = true;
            ObjectListView.Dock = DockStyle.Fill;
            ObjectListView.EmptyListMsg = "";
            ObjectListView.FullRowSelect = true;
            ObjectListView.GridLines = true;
            ObjectListView.IncludeColumnHeadersInCopy = true;
            ObjectListView.Location = new Point(0, 27);
            ObjectListView.MultiSelect = false;
            ObjectListView.Name = "ObjectListView";
            ObjectListView.ShowGroups = false;
            ObjectListView.ShowItemToolTips = true;
            ObjectListView.Size = new Size(507, 191);
            ObjectListView.TabIndex = 1;
            ObjectListView.UseFilterIndicator = true;
            ObjectListView.UseFiltering = true;
            ObjectListView.View = View.Details;
            // 
            // KryptonToolStrip
            // 
            KryptonToolStrip.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            KryptonToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            KryptonToolStrip.ImageScalingSize = new Size(20, 20);
            KryptonToolStrip.Items.AddRange(new ToolStripItem[] { SaveToolStripButton, SaveAllToolStripButton, toolStripSeparator1, OpenInAppToolStripButton, OpenWithToolStripMenuItem, ShowHiddenToolStripButton, toolStripSeparator2 });
            KryptonToolStrip.Location = new Point(0, 0);
            KryptonToolStrip.Name = "KryptonToolStrip";
            KryptonToolStrip.Size = new Size(507, 27);
            KryptonToolStrip.TabIndex = 2;
            KryptonToolStrip.Text = "AttachmentsToolStrip";
            // 
            // SaveToolStripButton
            // 
            SaveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            SaveToolStripButton.Image = Properties.Resources.content_save_outline;
            SaveToolStripButton.ImageTransparentColor = Color.Magenta;
            SaveToolStripButton.Name = "SaveToolStripButton";
            SaveToolStripButton.Size = new Size(24, 24);
            SaveToolStripButton.Text = "Save as..";
            SaveToolStripButton.ToolTipText = "Save selected Attachment as...";
            // 
            // SaveAllToolStripButton
            // 
            SaveAllToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            SaveAllToolStripButton.Image = Properties.Resources.content_save_all_outline;
            SaveAllToolStripButton.ImageTransparentColor = Color.Magenta;
            SaveAllToolStripButton.Name = "SaveAllToolStripButton";
            SaveAllToolStripButton.Size = new Size(24, 24);
            SaveAllToolStripButton.Text = "Save all";
            SaveAllToolStripButton.ToolTipText = "Save all Attachments";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // OpenInAppToolStripButton
            // 
            OpenInAppToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            OpenInAppToolStripButton.Image = Properties.Resources.open_in_app;
            OpenInAppToolStripButton.ImageTransparentColor = Color.Magenta;
            OpenInAppToolStripButton.Name = "OpenInAppToolStripButton";
            OpenInAppToolStripButton.Size = new Size(24, 24);
            OpenInAppToolStripButton.Text = "Open in XstReader";
            // 
            // OpenWithToolStripMenuItem
            // 
            OpenWithToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            OpenWithToolStripMenuItem.Image = Properties.Resources.open_in_new;
            OpenWithToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            OpenWithToolStripMenuItem.Name = "OpenWithToolStripMenuItem";
            OpenWithToolStripMenuItem.Size = new Size(24, 24);
            OpenWithToolStripMenuItem.Text = "Open with...";
            // 
            // ShowHiddenToolStripButton
            // 
            ShowHiddenToolStripButton.Alignment = ToolStripItemAlignment.Right;
            ShowHiddenToolStripButton.Checked = true;
            ShowHiddenToolStripButton.CheckOnClick = true;
            ShowHiddenToolStripButton.CheckState = CheckState.Checked;
            ShowHiddenToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ShowHiddenToolStripButton.Image = Properties.Resources.file_hidden;
            ShowHiddenToolStripButton.ImageTransparentColor = Color.Magenta;
            ShowHiddenToolStripButton.Name = "ShowHiddenToolStripButton";
            ShowHiddenToolStripButton.Size = new Size(24, 24);
            ShowHiddenToolStripButton.Text = "Show hidden";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = false;
            ErrorLabel.Dock = DockStyle.Fill;
            ErrorLabel.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            ErrorLabel.Location = new Point(0, 0);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(507, 218);
            ErrorLabel.StateNormal.ShortText.Color1 = Color.Red;
            ErrorLabel.TabIndex = 3;
            ErrorLabel.Values.ExtraText = "This is the error description";
            ErrorLabel.Values.Text = "Error";
            ErrorLabel.Visible = false;
            // 
            // XstAttachmentListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ObjectListView);
            Controls.Add(KryptonToolStrip);
            Controls.Add(ErrorLabel);
            MinimumSize = new Size(200, 100);
            Name = "XstAttachmentListControl";
            Size = new Size(507, 218);
            ((System.ComponentModel.ISupportInitialize)ObjectListView).EndInit();
            KryptonToolStrip.ResumeLayout(false);
            KryptonToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BrightIdeasSoftware.ObjectListView ObjectListView;
        private Krypton.Toolkit.KryptonToolStrip KryptonToolStrip;
        private ToolStripButton SaveToolStripButton;
        private ToolStripButton SaveAllToolStripButton;
        private SaveFileDialog SaveFileDialog;
        private FolderBrowserDialog FolderBrowserDialog;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton OpenInAppToolStripButton;
        private ToolStripButton OpenWithToolStripMenuItem;
        private ToolStripButton ShowHiddenToolStripButton;
        private ToolStripSeparator toolStripSeparator2;
        private Krypton.Toolkit.KryptonLabel ErrorLabel;
    }
}
