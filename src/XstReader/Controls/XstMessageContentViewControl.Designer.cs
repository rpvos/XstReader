namespace XstReader.App.Controls
{
    partial class XstMessageContentViewControl
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
            MainKryptonPanel = new Krypton.Toolkit.KryptonPanel();
            MainTabControl = new TabControl();
            MessageTabPage = new TabPage();
            KryptonWebBrowser = new Krypton.Toolkit.KryptonWebBrowser();
            TransportHeadersTabPage = new TabPage();
            TransportHeadersTextBox = new Krypton.Toolkit.KryptonTextBox();
            KryptonDockingManager = new Krypton.Docking.KryptonDockingManager();
            KryptonToolStrip = new Krypton.Toolkit.KryptonToolStrip();
            ExportToolStripButton = new ToolStripButton();
            PrintToolStripButton = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)MainKryptonPanel).BeginInit();
            MainKryptonPanel.SuspendLayout();
            MainTabControl.SuspendLayout();
            MessageTabPage.SuspendLayout();
            TransportHeadersTabPage.SuspendLayout();
            KryptonToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainKryptonPanel
            // 
            MainKryptonPanel.Controls.Add(MainTabControl);
            MainKryptonPanel.Dock = DockStyle.Fill;
            MainKryptonPanel.Location = new Point(0, 31);
            MainKryptonPanel.Name = "MainKryptonPanel";
            MainKryptonPanel.Size = new Size(435, 426);
            MainKryptonPanel.TabIndex = 1;
            // 
            // MainTabControl
            // 
            MainTabControl.Controls.Add(MessageTabPage);
            MainTabControl.Controls.Add(TransportHeadersTabPage);
            MainTabControl.Dock = DockStyle.Fill;
            MainTabControl.Location = new Point(0, 0);
            MainTabControl.Name = "MainTabControl";
            MainTabControl.SelectedIndex = 0;
            MainTabControl.Size = new Size(435, 426);
            MainTabControl.TabIndex = 4;
            // 
            // MessageTabPage
            // 
            MessageTabPage.Controls.Add(KryptonWebBrowser);
            MessageTabPage.Location = new Point(4, 24);
            MessageTabPage.Name = "MessageTabPage";
            MessageTabPage.Padding = new Padding(3);
            MessageTabPage.Size = new Size(427, 398);
            MessageTabPage.TabIndex = 0;
            MessageTabPage.Text = "Message";
            MessageTabPage.UseVisualStyleBackColor = true;
            // 
            // KryptonWebBrowser
            // 
            KryptonWebBrowser.Dock = DockStyle.Fill;
            KryptonWebBrowser.Location = new Point(3, 3);
            KryptonWebBrowser.Name = "KryptonWebBrowser";
            KryptonWebBrowser.Size = new Size(421, 392);
            KryptonWebBrowser.TabIndex = 3;
            // 
            // TransportHeadersTabPage
            // 
            TransportHeadersTabPage.Controls.Add(TransportHeadersTextBox);
            TransportHeadersTabPage.Location = new Point(4, 24);
            TransportHeadersTabPage.Name = "TransportHeadersTabPage";
            TransportHeadersTabPage.Padding = new Padding(3);
            TransportHeadersTabPage.Size = new Size(427, 398);
            TransportHeadersTabPage.TabIndex = 1;
            TransportHeadersTabPage.Text = "Transport Headers";
            TransportHeadersTabPage.UseVisualStyleBackColor = true;
            // 
            // TransportHeadersTextBox
            // 
            TransportHeadersTextBox.Dock = DockStyle.Fill;
            TransportHeadersTextBox.Location = new Point(3, 3);
            TransportHeadersTextBox.Multiline = true;
            TransportHeadersTextBox.Name = "TransportHeadersTextBox";
            TransportHeadersTextBox.ReadOnly = true;
            TransportHeadersTextBox.ScrollBars = ScrollBars.Both;
            TransportHeadersTextBox.Size = new Size(421, 392);
            TransportHeadersTextBox.TabIndex = 0;
            // 
            // KryptonToolStrip
            // 
            KryptonToolStrip.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            KryptonToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            KryptonToolStrip.ImageScalingSize = new Size(24, 24);
            KryptonToolStrip.Items.AddRange(new ToolStripItem[] { ExportToolStripButton, PrintToolStripButton });
            KryptonToolStrip.Location = new Point(0, 0);
            KryptonToolStrip.Name = "KryptonToolStrip";
            KryptonToolStrip.Size = new Size(435, 31);
            KryptonToolStrip.TabIndex = 2;
            KryptonToolStrip.Text = "kryptonToolStrip1";
            // 
            // ExportToolStripButton
            // 
            ExportToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ExportToolStripButton.Image = Properties.Resources.content_save;
            ExportToolStripButton.ImageTransparentColor = Color.Magenta;
            ExportToolStripButton.Name = "ExportToolStripButton";
            ExportToolStripButton.Size = new Size(28, 28);
            ExportToolStripButton.Text = "Export message";
            ExportToolStripButton.ToolTipText = "Export Message";
            // 
            // PrintToolStripButton
            // 
            PrintToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            PrintToolStripButton.Image = Properties.Resources.printer;
            PrintToolStripButton.ImageTransparentColor = Color.Magenta;
            PrintToolStripButton.Name = "PrintToolStripButton";
            PrintToolStripButton.Size = new Size(28, 28);
            PrintToolStripButton.Text = "Print...";
            // 
            // XstMessageContentViewControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(MainKryptonPanel);
            Controls.Add(KryptonToolStrip);
            Name = "XstMessageContentViewControl";
            Size = new Size(435, 457);
            ((System.ComponentModel.ISupportInitialize)MainKryptonPanel).EndInit();
            MainKryptonPanel.ResumeLayout(false);
            MainTabControl.ResumeLayout(false);
            MessageTabPage.ResumeLayout(false);
            TransportHeadersTabPage.ResumeLayout(false);
            TransportHeadersTabPage.PerformLayout();
            KryptonToolStrip.ResumeLayout(false);
            KryptonToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel MainKryptonPanel;
        private Krypton.Docking.KryptonDockingManager KryptonDockingManager;
        private Krypton.Toolkit.KryptonToolStrip KryptonToolStrip;
        private Krypton.Toolkit.KryptonWebBrowser KryptonWebBrowser;
        private ToolStripButton PrintToolStripButton;
        private ToolStripButton ExportToolStripButton;
        private TabControl MainTabControl;
        private TabPage MessageTabPage;
        private TabPage TransportHeadersTabPage;
        private Krypton.Toolkit.KryptonTextBox TransportHeadersTextBox;
    }
}
