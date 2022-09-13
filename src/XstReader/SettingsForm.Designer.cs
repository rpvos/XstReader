namespace XstReader.App
{
    partial class SettingsForm
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
            this.ConfigTabControl = new System.Windows.Forms.TabControl();
            this.VisualizationTabPage = new System.Windows.Forms.TabPage();
            this.VisualizationPropertyGridSettings = new Krypton.Toolkit.KryptonPropertyGrid();
            this.VisualizationKryptonLabel = new Krypton.Toolkit.KryptonLabel();
            this.HtmlTabPage = new System.Windows.Forms.TabPage();
            this.HtmlPropertyGridSettings = new Krypton.Toolkit.KryptonPropertyGrid();
            this.HtmlKryptonLabel = new Krypton.Toolkit.KryptonLabel();
            this.ConfigTabControl.SuspendLayout();
            this.VisualizationTabPage.SuspendLayout();
            this.HtmlTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigTabControl
            // 
            this.ConfigTabControl.Controls.Add(this.VisualizationTabPage);
            this.ConfigTabControl.Controls.Add(this.HtmlTabPage);
            this.ConfigTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigTabControl.Location = new System.Drawing.Point(0, 0);
            this.ConfigTabControl.Name = "ConfigTabControl";
            this.ConfigTabControl.SelectedIndex = 0;
            this.ConfigTabControl.Size = new System.Drawing.Size(331, 296);
            this.ConfigTabControl.TabIndex = 4;
            // 
            // VisualizationTabPage
            // 
            this.VisualizationTabPage.Controls.Add(this.VisualizationPropertyGridSettings);
            this.VisualizationTabPage.Controls.Add(this.VisualizationKryptonLabel);
            this.VisualizationTabPage.Location = new System.Drawing.Point(4, 24);
            this.VisualizationTabPage.Name = "VisualizationTabPage";
            this.VisualizationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.VisualizationTabPage.Size = new System.Drawing.Size(323, 268);
            this.VisualizationTabPage.TabIndex = 0;
            this.VisualizationTabPage.Text = "Visualization";
            this.VisualizationTabPage.UseVisualStyleBackColor = true;
            // 
            // VisualizationPropertyGridSettings
            // 
            this.VisualizationPropertyGridSettings.CategoryForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.VisualizationPropertyGridSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisualizationPropertyGridSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VisualizationPropertyGridSettings.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.VisualizationPropertyGridSettings.HelpForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.VisualizationPropertyGridSettings.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(196)))), ((int)(((byte)(216)))));
            this.VisualizationPropertyGridSettings.Location = new System.Drawing.Point(3, 23);
            this.VisualizationPropertyGridSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VisualizationPropertyGridSettings.Name = "VisualizationPropertyGridSettings";
            this.VisualizationPropertyGridSettings.Size = new System.Drawing.Size(317, 242);
            this.VisualizationPropertyGridSettings.TabIndex = 3;
            this.VisualizationPropertyGridSettings.ToolbarVisible = false;
            // 
            // VisualizationKryptonLabel
            // 
            this.VisualizationKryptonLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.VisualizationKryptonLabel.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.VisualizationKryptonLabel.Location = new System.Drawing.Point(3, 3);
            this.VisualizationKryptonLabel.Name = "VisualizationKryptonLabel";
            this.VisualizationKryptonLabel.Size = new System.Drawing.Size(317, 20);
            this.VisualizationKryptonLabel.TabIndex = 4;
            this.VisualizationKryptonLabel.Values.Text = "Visualization in application";
            // 
            // HtmlTabPage
            // 
            this.HtmlTabPage.Controls.Add(this.HtmlPropertyGridSettings);
            this.HtmlTabPage.Controls.Add(this.HtmlKryptonLabel);
            this.HtmlTabPage.Location = new System.Drawing.Point(4, 24);
            this.HtmlTabPage.Name = "HtmlTabPage";
            this.HtmlTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HtmlTabPage.Size = new System.Drawing.Size(323, 268);
            this.HtmlTabPage.TabIndex = 1;
            this.HtmlTabPage.Text = "Html export";
            this.HtmlTabPage.UseVisualStyleBackColor = true;
            // 
            // HtmlPropertyGridSettings
            // 
            this.HtmlPropertyGridSettings.CategoryForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.HtmlPropertyGridSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HtmlPropertyGridSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HtmlPropertyGridSettings.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.HtmlPropertyGridSettings.HelpForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.HtmlPropertyGridSettings.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(196)))), ((int)(((byte)(216)))));
            this.HtmlPropertyGridSettings.Location = new System.Drawing.Point(3, 23);
            this.HtmlPropertyGridSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HtmlPropertyGridSettings.Name = "HtmlPropertyGridSettings";
            this.HtmlPropertyGridSettings.Size = new System.Drawing.Size(317, 242);
            this.HtmlPropertyGridSettings.TabIndex = 6;
            this.HtmlPropertyGridSettings.ToolbarVisible = false;
            // 
            // HtmlKryptonLabel
            // 
            this.HtmlKryptonLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HtmlKryptonLabel.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.HtmlKryptonLabel.Location = new System.Drawing.Point(3, 3);
            this.HtmlKryptonLabel.Name = "HtmlKryptonLabel";
            this.HtmlKryptonLabel.Size = new System.Drawing.Size(317, 20);
            this.HtmlKryptonLabel.TabIndex = 5;
            this.HtmlKryptonLabel.Values.Text = "Html export options";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 296);
            this.Controls.Add(this.ConfigTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SettingsForm";
            this.Text = "XstReader Settings";
            this.ConfigTabControl.ResumeLayout(false);
            this.VisualizationTabPage.ResumeLayout(false);
            this.VisualizationTabPage.PerformLayout();
            this.HtmlTabPage.ResumeLayout(false);
            this.HtmlTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl ConfigTabControl;
        private TabPage VisualizationTabPage;
        private Krypton.Toolkit.KryptonPropertyGrid VisualizationPropertyGridSettings;
        private Krypton.Toolkit.KryptonLabel VisualizationKryptonLabel;
        private TabPage HtmlTabPage;
        private Krypton.Toolkit.KryptonPropertyGrid HtmlPropertyGridSettings;
        private Krypton.Toolkit.KryptonLabel HtmlKryptonLabel;
    }
}