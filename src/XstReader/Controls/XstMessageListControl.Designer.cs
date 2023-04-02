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
            components = new System.ComponentModel.Container();
            ObjectListView = new BrightIdeasSoftware.ObjectListView();
            HeaderPanel = new Krypton.Toolkit.KryptonPanel();
            SearchTextBox = new Krypton.Toolkit.KryptonTextBox();
            SearchTextButton = new Krypton.Toolkit.ButtonSpecAny();
            SearchTextCancelButton = new Krypton.Toolkit.ButtonSpecAny();
            TimerSearchText = new System.Windows.Forms.Timer(components);
            ErrorLabel = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)ObjectListView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HeaderPanel).BeginInit();
            HeaderPanel.SuspendLayout();
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
            ObjectListView.Location = new Point(0, 32);
            ObjectListView.MultiSelect = false;
            ObjectListView.Name = "ObjectListView";
            ObjectListView.ShowGroups = false;
            ObjectListView.ShowItemToolTips = true;
            ObjectListView.Size = new Size(633, 372);
            ObjectListView.TabIndex = 0;
            ObjectListView.UseFilterIndicator = true;
            ObjectListView.UseFiltering = true;
            ObjectListView.View = View.Details;
            // 
            // HeaderPanel
            // 
            HeaderPanel.Controls.Add(SearchTextBox);
            HeaderPanel.Dock = DockStyle.Top;
            HeaderPanel.Location = new Point(0, 0);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.ControlGroupBox;
            HeaderPanel.Size = new Size(633, 32);
            HeaderPanel.TabIndex = 1;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Anchor = AnchorStyles.Left;
            SearchTextBox.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecAny[] { SearchTextButton, SearchTextCancelButton });
            SearchTextBox.Location = new Point(5, 5);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(300, 24);
            SearchTextBox.TabIndex = 0;
            // 
            // SearchTextButton
            // 
            SearchTextButton.Image = Properties.Resources.magnify_18;
            SearchTextButton.UniqueName = "1a634cb36357467a847069f7b81a5559";
            // 
            // SearchTextCancelButton
            // 
            SearchTextCancelButton.Image = Properties.Resources.close_circle_outline_16;
            SearchTextCancelButton.UniqueName = "af041d7b1aac4bada07043a284a2bc48";
            // 
            // TimerSearchText
            // 
            TimerSearchText.Interval = 500;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = false;
            ErrorLabel.Dock = DockStyle.Fill;
            ErrorLabel.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            ErrorLabel.Location = new Point(0, 0);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(633, 404);
            ErrorLabel.StateNormal.ShortText.Color1 = Color.Red;
            ErrorLabel.TabIndex = 4;
            ErrorLabel.Values.ExtraText = "This is the error description";
            ErrorLabel.Values.Text = "Error";
            ErrorLabel.Visible = false;
            // 
            // XstMessageListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ObjectListView);
            Controls.Add(HeaderPanel);
            Controls.Add(ErrorLabel);
            MinimumSize = new Size(200, 100);
            Name = "XstMessageListControl";
            Size = new Size(633, 404);
            ((System.ComponentModel.ISupportInitialize)ObjectListView).EndInit();
            ((System.ComponentModel.ISupportInitialize)HeaderPanel).EndInit();
            HeaderPanel.ResumeLayout(false);
            HeaderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private BrightIdeasSoftware.ObjectListView ObjectListView;
        private Krypton.Toolkit.KryptonPanel HeaderPanel;
        private Krypton.Toolkit.KryptonTextBox SearchTextBox;
        private Krypton.Toolkit.ButtonSpecAny SearchTextButton;
        private System.Windows.Forms.Timer TimerSearchText;
        private Krypton.Toolkit.ButtonSpecAny SearchTextCancelButton;
        private Krypton.Toolkit.KryptonLabel ErrorLabel;
    }
}
