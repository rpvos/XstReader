namespace XstReader.App
{
    partial class ExportAttachmentOptionsForm
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
            this.TitleKryptonLabel = new Krypton.Toolkit.KryptonLabel();
            this.IncludeHiddenCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.MainPanel = new Krypton.Toolkit.KryptonPanel();
            this.InFoldersCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.BottomPanel = new Krypton.Toolkit.KryptonPanel();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomPanel)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleKryptonLabel
            // 
            this.TitleKryptonLabel.AutoSize = false;
            this.TitleKryptonLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleKryptonLabel.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            this.TitleKryptonLabel.Location = new System.Drawing.Point(5, 5);
            this.TitleKryptonLabel.Name = "TitleKryptonLabel";
            this.TitleKryptonLabel.Size = new System.Drawing.Size(258, 57);
            this.TitleKryptonLabel.TabIndex = 0;
            this.TitleKryptonLabel.Values.Text = "Export Attachment Options";
            // 
            // IncludeHiddenCheckBox
            // 
            this.IncludeHiddenCheckBox.AutoSize = false;
            this.IncludeHiddenCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.IncludeHiddenCheckBox.Location = new System.Drawing.Point(5, 62);
            this.IncludeHiddenCheckBox.Name = "IncludeHiddenCheckBox";
            this.IncludeHiddenCheckBox.Size = new System.Drawing.Size(258, 39);
            this.IncludeHiddenCheckBox.TabIndex = 1;
            this.IncludeHiddenCheckBox.Values.Text = "Include Hidden Attachments";
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.InFoldersCheckBox);
            this.MainPanel.Controls.Add(this.IncludeHiddenCheckBox);
            this.MainPanel.Controls.Add(this.TitleKryptonLabel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MainPanel.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.MainPanel.Size = new System.Drawing.Size(268, 158);
            this.MainPanel.TabIndex = 2;
            // 
            // InFoldersCheckBox
            // 
            this.InFoldersCheckBox.AutoSize = false;
            this.InFoldersCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.InFoldersCheckBox.Location = new System.Drawing.Point(5, 101);
            this.InFoldersCheckBox.Name = "InFoldersCheckBox";
            this.InFoldersCheckBox.Size = new System.Drawing.Size(258, 39);
            this.InFoldersCheckBox.TabIndex = 2;
            this.InFoldersCheckBox.Values.Text = "Each mail in a folder";
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.CancelButton);
            this.BottomPanel.Controls.Add(this.OkButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 158);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(268, 43);
            this.BottomPanel.TabIndex = 3;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(181, 6);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(87, 31);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(0, 6);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(87, 31);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ExportAttachmentOptionsForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(268, 201);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.BottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExportAttachmentOptionsForm";
            this.Text = "Attachments Options";
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BottomPanel)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel TitleKryptonLabel;
        private Krypton.Toolkit.KryptonCheckBox IncludeHiddenCheckBox;
        private Krypton.Toolkit.KryptonPanel MainPanel;
        private Krypton.Toolkit.KryptonCheckBox InFoldersCheckBox;
        private Krypton.Toolkit.KryptonPanel BottomPanel;
        private Button CancelButton;
        private Button OkButton;
    }
}