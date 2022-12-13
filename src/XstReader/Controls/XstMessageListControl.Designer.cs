namespace XstReader.App.Controls
{
    partial class XstMessageListControl
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
            this.components = new System.ComponentModel.Container();
            this.ObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.HeaderPanel = new Krypton.Toolkit.KryptonPanel();
            this.SearchTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.SearchTextButton = new Krypton.Toolkit.ButtonSpecAny();
            this.SearchTextCancelButton = new Krypton.Toolkit.ButtonSpecAny();
            this.TimerSearchText = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ObjectListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPanel)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ObjectListView
            // 
            this.ObjectListView.AllowColumnReorder = true;
            this.ObjectListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectListView.EmptyListMsg = "";
            this.ObjectListView.FullRowSelect = true;
            this.ObjectListView.GridLines = true;
            this.ObjectListView.IncludeColumnHeadersInCopy = true;
            this.ObjectListView.Location = new System.Drawing.Point(0, 32);
            this.ObjectListView.MultiSelect = false;
            this.ObjectListView.Name = "ObjectListView";
            this.ObjectListView.ShowGroups = false;
            this.ObjectListView.ShowItemToolTips = true;
            this.ObjectListView.Size = new System.Drawing.Size(633, 372);
            this.ObjectListView.TabIndex = 0;
            this.ObjectListView.UseFilterIndicator = true;
            this.ObjectListView.UseFiltering = true;
            this.ObjectListView.View = System.Windows.Forms.View.Details;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.SearchTextBox);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.ControlGroupBox;
            this.HeaderPanel.Size = new System.Drawing.Size(633, 32);
            this.HeaderPanel.TabIndex = 1;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchTextBox.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecAny[] {
            this.SearchTextButton,
            this.SearchTextCancelButton});
            this.SearchTextBox.Location = new System.Drawing.Point(5, 5);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(300, 23);
            this.SearchTextBox.TabIndex = 0;
            // 
            // SearchTextButton
            // 
            this.SearchTextButton.Image = global::XstReader.App.Properties.Resources.magnify_18;
            this.SearchTextButton.UniqueName = "1a634cb36357467a847069f7b81a5559";
            // 
            // SearchTextCancelButton
            // 
            this.SearchTextCancelButton.Image = global::XstReader.App.Properties.Resources.close_circle_outline_16;
            this.SearchTextCancelButton.UniqueName = "af041d7b1aac4bada07043a284a2bc48";
            // 
            // TimerSearchText
            // 
            this.TimerSearchText.Interval = 500;
            // 
            // XstMessageListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ObjectListView);
            this.Controls.Add(this.HeaderPanel);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "XstMessageListControl";
            this.Size = new System.Drawing.Size(633, 404);
            ((System.ComponentModel.ISupportInitialize)(this.ObjectListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPanel)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView ObjectListView;
        private Krypton.Toolkit.KryptonPanel HeaderPanel;
        private Krypton.Toolkit.KryptonTextBox SearchTextBox;
        private Krypton.Toolkit.ButtonSpecAny SearchTextButton;
        private System.Windows.Forms.Timer TimerSearchText;
        private Krypton.Toolkit.ButtonSpecAny SearchTextCancelButton;
    }
}
