namespace ImageConverter
{
    partial class MainView
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
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.destonationTextBox = new System.Windows.Forms.TextBox();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.destonationLabel = new System.Windows.Forms.Label();
            this.destinationShowDialogButton = new System.Windows.Forms.Button();
            this.sourceShowDialogButton = new System.Windows.Forms.Button();
            this.pathControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.deepSearchCheckBox = new System.Windows.Forms.CheckBox();
            this.imagesInfoListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeAfterColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imagesInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sizeAfterConversionLabel = new System.Windows.Forms.Label();
            this.fullSizeBeforeLabel = new System.Windows.Forms.Label();
            this.conversionOptionsGroupbox = new System.Windows.Forms.GroupBox();
            this.convertingProgess = new System.Windows.Forms.ProgressBar();
            this.convertFormatComboBox = new System.Windows.Forms.ComboBox();
            this.abortConvertingButton = new System.Windows.Forms.Button();
            this.startConvertingButton = new System.Windows.Forms.Button();
            this.newSizeGroupBox = new System.Windows.Forms.GroupBox();
            this.ratioConvertTrackBar = new System.Windows.Forms.TrackBar();
            this.ratioRadioButton = new System.Windows.Forms.RadioButton();
            this.allToSizeRadioButton = new System.Windows.Forms.RadioButton();
            this.imgHeightLabel = new System.Windows.Forms.Label();
            this.imageNewHeightTextBox = new System.Windows.Forms.TextBox();
            this.imgWidthLabel = new System.Windows.Forms.Label();
            this.imageNewWidthTextBox = new System.Windows.Forms.TextBox();
            this.smoothingModeComboBox = new System.Windows.Forms.ComboBox();
            this.interpolationComboBox = new System.Windows.Forms.ComboBox();
            this.compositionQualityComboBox = new System.Windows.Forms.ComboBox();
            this.pathControlsGroupBox.SuspendLayout();
            this.imagesInfoGroupBox.SuspendLayout();
            this.conversionOptionsGroupbox.SuspendLayout();
            this.newSizeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratioConvertTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(72, 19);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(273, 20);
            this.sourceTextBox.TabIndex = 0;
            // 
            // destonationTextBox
            // 
            this.destonationTextBox.Location = new System.Drawing.Point(72, 45);
            this.destonationTextBox.Name = "destonationTextBox";
            this.destonationTextBox.Size = new System.Drawing.Size(273, 20);
            this.destonationTextBox.TabIndex = 1;
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(6, 22);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(41, 13);
            this.sourceLabel.TabIndex = 2;
            this.sourceLabel.Text = "Source";
            // 
            // destonationLabel
            // 
            this.destonationLabel.AutoSize = true;
            this.destonationLabel.Location = new System.Drawing.Point(6, 48);
            this.destonationLabel.Name = "destonationLabel";
            this.destonationLabel.Size = new System.Drawing.Size(60, 13);
            this.destonationLabel.TabIndex = 3;
            this.destonationLabel.Text = "Destination";
            // 
            // destinationShowDialogButton
            // 
            this.destinationShowDialogButton.Location = new System.Drawing.Point(351, 45);
            this.destinationShowDialogButton.Name = "destinationShowDialogButton";
            this.destinationShowDialogButton.Size = new System.Drawing.Size(35, 20);
            this.destinationShowDialogButton.TabIndex = 4;
            this.destinationShowDialogButton.TabStop = false;
            this.destinationShowDialogButton.Text = "...";
            this.destinationShowDialogButton.UseVisualStyleBackColor = true;
            this.destinationShowDialogButton.Click += new System.EventHandler(this.DestonationFileDialog);
            // 
            // sourceShowDialogButton
            // 
            this.sourceShowDialogButton.Location = new System.Drawing.Point(351, 19);
            this.sourceShowDialogButton.Name = "sourceShowDialogButton";
            this.sourceShowDialogButton.Size = new System.Drawing.Size(35, 20);
            this.sourceShowDialogButton.TabIndex = 5;
            this.sourceShowDialogButton.TabStop = false;
            this.sourceShowDialogButton.Text = "...";
            this.sourceShowDialogButton.UseVisualStyleBackColor = true;
            this.sourceShowDialogButton.Click += new System.EventHandler(this.SourceFileDialog);
            // 
            // pathControlsGroupBox
            // 
            this.pathControlsGroupBox.Controls.Add(this.deepSearchCheckBox);
            this.pathControlsGroupBox.Controls.Add(this.sourceLabel);
            this.pathControlsGroupBox.Controls.Add(this.sourceTextBox);
            this.pathControlsGroupBox.Controls.Add(this.sourceShowDialogButton);
            this.pathControlsGroupBox.Controls.Add(this.destonationTextBox);
            this.pathControlsGroupBox.Controls.Add(this.destinationShowDialogButton);
            this.pathControlsGroupBox.Controls.Add(this.destonationLabel);
            this.pathControlsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.pathControlsGroupBox.Name = "pathControlsGroupBox";
            this.pathControlsGroupBox.Size = new System.Drawing.Size(392, 95);
            this.pathControlsGroupBox.TabIndex = 7;
            this.pathControlsGroupBox.TabStop = false;
            this.pathControlsGroupBox.Text = "Paths";
            // 
            // deepSearchCheckBox
            // 
            this.deepSearchCheckBox.AutoSize = true;
            this.deepSearchCheckBox.Location = new System.Drawing.Point(9, 71);
            this.deepSearchCheckBox.Name = "deepSearchCheckBox";
            this.deepSearchCheckBox.Size = new System.Drawing.Size(87, 17);
            this.deepSearchCheckBox.TabIndex = 6;
            this.deepSearchCheckBox.TabStop = false;
            this.deepSearchCheckBox.Text = "Deep search";
            this.deepSearchCheckBox.UseVisualStyleBackColor = true;
            this.deepSearchCheckBox.CheckedChanged += new System.EventHandler(this.ChangeToDeepSearch);
            // 
            // imagesInfoListView
            // 
            this.imagesInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.sizeColumnHeader,
            this.sizeAfterColumnHeader});
            this.imagesInfoListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.imagesInfoListView.Location = new System.Drawing.Point(9, 19);
            this.imagesInfoListView.Name = "imagesInfoListView";
            this.imagesInfoListView.Size = new System.Drawing.Size(245, 334);
            this.imagesInfoListView.TabIndex = 8;
            this.imagesInfoListView.UseCompatibleStateImageBehavior = false;
            this.imagesInfoListView.View = System.Windows.Forms.View.Details;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 120;
            // 
            // sizeColumnHeader
            // 
            this.sizeColumnHeader.Text = "Size now";
            this.sizeColumnHeader.Width = 61;
            // 
            // sizeAfterColumnHeader
            // 
            this.sizeAfterColumnHeader.Text = "Size after";
            this.sizeAfterColumnHeader.Width = 58;
            // 
            // imagesInfoGroupBox
            // 
            this.imagesInfoGroupBox.Controls.Add(this.groupBox1);
            this.imagesInfoGroupBox.Controls.Add(this.sizeAfterConversionLabel);
            this.imagesInfoGroupBox.Controls.Add(this.fullSizeBeforeLabel);
            this.imagesInfoGroupBox.Controls.Add(this.imagesInfoListView);
            this.imagesInfoGroupBox.Location = new System.Drawing.Point(12, 113);
            this.imagesInfoGroupBox.Name = "imagesInfoGroupBox";
            this.imagesInfoGroupBox.Size = new System.Drawing.Size(260, 379);
            this.imagesInfoGroupBox.TabIndex = 9;
            this.imagesInfoGroupBox.TabStop = false;
            this.imagesInfoGroupBox.Text = "Images informations";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(266, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 208);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // sizeAfterConversionLabel
            // 
            this.sizeAfterConversionLabel.AutoSize = true;
            this.sizeAfterConversionLabel.Location = new System.Drawing.Point(125, 356);
            this.sizeAfterConversionLabel.Name = "sizeAfterConversionLabel";
            this.sizeAfterConversionLabel.Size = new System.Drawing.Size(83, 13);
            this.sizeAfterConversionLabel.TabIndex = 10;
            this.sizeAfterConversionLabel.Text = "After (around): 0";
            // 
            // fullSizeBeforeLabel
            // 
            this.fullSizeBeforeLabel.AutoSize = true;
            this.fullSizeBeforeLabel.Location = new System.Drawing.Point(6, 356);
            this.fullSizeBeforeLabel.Name = "fullSizeBeforeLabel";
            this.fullSizeBeforeLabel.Size = new System.Drawing.Size(70, 13);
            this.fullSizeBeforeLabel.TabIndex = 9;
            this.fullSizeBeforeLabel.Text = "Actual size: 0";
            // 
            // conversionOptionsGroupbox
            // 
            this.conversionOptionsGroupbox.Controls.Add(this.convertingProgess);
            this.conversionOptionsGroupbox.Controls.Add(this.convertFormatComboBox);
            this.conversionOptionsGroupbox.Controls.Add(this.abortConvertingButton);
            this.conversionOptionsGroupbox.Controls.Add(this.startConvertingButton);
            this.conversionOptionsGroupbox.Controls.Add(this.newSizeGroupBox);
            this.conversionOptionsGroupbox.Controls.Add(this.smoothingModeComboBox);
            this.conversionOptionsGroupbox.Controls.Add(this.interpolationComboBox);
            this.conversionOptionsGroupbox.Controls.Add(this.compositionQualityComboBox);
            this.conversionOptionsGroupbox.Location = new System.Drawing.Point(278, 113);
            this.conversionOptionsGroupbox.Name = "conversionOptionsGroupbox";
            this.conversionOptionsGroupbox.Size = new System.Drawing.Size(126, 379);
            this.conversionOptionsGroupbox.TabIndex = 10;
            this.conversionOptionsGroupbox.TabStop = false;
            this.conversionOptionsGroupbox.Text = "Conversion";
            // 
            // convertingProgess
            // 
            this.convertingProgess.Location = new System.Drawing.Point(5, 353);
            this.convertingProgess.Name = "convertingProgess";
            this.convertingProgess.Size = new System.Drawing.Size(115, 16);
            this.convertingProgess.TabIndex = 15;
            // 
            // convertFormatComboBox
            // 
            this.convertFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.convertFormatComboBox.FormattingEnabled = true;
            this.convertFormatComboBox.Location = new System.Drawing.Point(5, 100);
            this.convertFormatComboBox.Name = "convertFormatComboBox";
            this.convertFormatComboBox.Size = new System.Drawing.Size(115, 21);
            this.convertFormatComboBox.TabIndex = 3;
            // 
            // abortConvertingButton
            // 
            this.abortConvertingButton.Location = new System.Drawing.Point(6, 314);
            this.abortConvertingButton.Name = "abortConvertingButton";
            this.abortConvertingButton.Size = new System.Drawing.Size(45, 33);
            this.abortConvertingButton.TabIndex = 13;
            this.abortConvertingButton.TabStop = false;
            this.abortConvertingButton.Text = "Abort";
            this.abortConvertingButton.UseVisualStyleBackColor = true;
            this.abortConvertingButton.Click += new System.EventHandler(this.AbortConverting);
            // 
            // startConvertingButton
            // 
            this.startConvertingButton.Location = new System.Drawing.Point(53, 314);
            this.startConvertingButton.Name = "startConvertingButton";
            this.startConvertingButton.Size = new System.Drawing.Size(67, 33);
            this.startConvertingButton.TabIndex = 12;
            this.startConvertingButton.TabStop = false;
            this.startConvertingButton.Text = "Convert";
            this.startConvertingButton.UseVisualStyleBackColor = true;
            this.startConvertingButton.Click += new System.EventHandler(this.StartConverting);
            // 
            // newSizeGroupBox
            // 
            this.newSizeGroupBox.Controls.Add(this.ratioConvertTrackBar);
            this.newSizeGroupBox.Controls.Add(this.ratioRadioButton);
            this.newSizeGroupBox.Controls.Add(this.allToSizeRadioButton);
            this.newSizeGroupBox.Controls.Add(this.imgHeightLabel);
            this.newSizeGroupBox.Controls.Add(this.imageNewHeightTextBox);
            this.newSizeGroupBox.Controls.Add(this.imgWidthLabel);
            this.newSizeGroupBox.Controls.Add(this.imageNewWidthTextBox);
            this.newSizeGroupBox.Location = new System.Drawing.Point(7, 126);
            this.newSizeGroupBox.Name = "newSizeGroupBox";
            this.newSizeGroupBox.Size = new System.Drawing.Size(114, 182);
            this.newSizeGroupBox.TabIndex = 11;
            this.newSizeGroupBox.TabStop = false;
            this.newSizeGroupBox.Text = "New size";
            // 
            // ratioConvertTrackBar
            // 
            this.ratioConvertTrackBar.LargeChange = 1;
            this.ratioConvertTrackBar.Location = new System.Drawing.Point(4, 128);
            this.ratioConvertTrackBar.Minimum = 1;
            this.ratioConvertTrackBar.Name = "ratioConvertTrackBar";
            this.ratioConvertTrackBar.Size = new System.Drawing.Size(104, 45);
            this.ratioConvertTrackBar.TabIndex = 9;
            this.ratioConvertTrackBar.TabStop = false;
            this.ratioConvertTrackBar.Value = 1;
            this.ratioConvertTrackBar.ValueChanged += new System.EventHandler(this.ChangeRatioValue);
            // 
            // ratioRadioButton
            // 
            this.ratioRadioButton.AutoSize = true;
            this.ratioRadioButton.Location = new System.Drawing.Point(5, 105);
            this.ratioRadioButton.Name = "ratioRadioButton";
            this.ratioRadioButton.Size = new System.Drawing.Size(50, 17);
            this.ratioRadioButton.TabIndex = 8;
            this.ratioRadioButton.Text = "Ratio";
            this.ratioRadioButton.UseVisualStyleBackColor = true;
            this.ratioRadioButton.CheckedChanged += new System.EventHandler(this.RatioConversionMode);
            // 
            // allToSizeRadioButton
            // 
            this.allToSizeRadioButton.AutoSize = true;
            this.allToSizeRadioButton.Location = new System.Drawing.Point(6, 27);
            this.allToSizeRadioButton.Name = "allToSizeRadioButton";
            this.allToSizeRadioButton.Size = new System.Drawing.Size(69, 17);
            this.allToSizeRadioButton.TabIndex = 3;
            this.allToSizeRadioButton.TabStop = true;
            this.allToSizeRadioButton.Text = "All to size";
            this.allToSizeRadioButton.UseVisualStyleBackColor = true;
            this.allToSizeRadioButton.CheckedChanged += new System.EventHandler(this.AllToSizeConversionMode);
            // 
            // imgHeightLabel
            // 
            this.imgHeightLabel.AutoSize = true;
            this.imgHeightLabel.Location = new System.Drawing.Point(6, 79);
            this.imgHeightLabel.Name = "imgHeightLabel";
            this.imgHeightLabel.Size = new System.Drawing.Size(38, 13);
            this.imgHeightLabel.TabIndex = 7;
            this.imgHeightLabel.Text = "Height";
            // 
            // imageNewHeightTextBox
            // 
            this.imageNewHeightTextBox.Location = new System.Drawing.Point(53, 76);
            this.imageNewHeightTextBox.Name = "imageNewHeightTextBox";
            this.imageNewHeightTextBox.Size = new System.Drawing.Size(55, 20);
            this.imageNewHeightTextBox.TabIndex = 5;
            // 
            // imgWidthLabel
            // 
            this.imgWidthLabel.AutoSize = true;
            this.imgWidthLabel.Location = new System.Drawing.Point(6, 53);
            this.imgWidthLabel.Name = "imgWidthLabel";
            this.imgWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.imgWidthLabel.TabIndex = 6;
            this.imgWidthLabel.Text = "Width";
            // 
            // imageNewWidthTextBox
            // 
            this.imageNewWidthTextBox.Location = new System.Drawing.Point(53, 50);
            this.imageNewWidthTextBox.Name = "imageNewWidthTextBox";
            this.imageNewWidthTextBox.Size = new System.Drawing.Size(55, 20);
            this.imageNewWidthTextBox.TabIndex = 4;
            // 
            // smoothingModeComboBox
            // 
            this.smoothingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smoothingModeComboBox.FormattingEnabled = true;
            this.smoothingModeComboBox.Location = new System.Drawing.Point(5, 73);
            this.smoothingModeComboBox.Name = "smoothingModeComboBox";
            this.smoothingModeComboBox.Size = new System.Drawing.Size(115, 21);
            this.smoothingModeComboBox.TabIndex = 2;
            // 
            // interpolationComboBox
            // 
            this.interpolationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationComboBox.FormattingEnabled = true;
            this.interpolationComboBox.Location = new System.Drawing.Point(5, 46);
            this.interpolationComboBox.Name = "interpolationComboBox";
            this.interpolationComboBox.Size = new System.Drawing.Size(115, 21);
            this.interpolationComboBox.TabIndex = 1;
            // 
            // compositionQualityComboBox
            // 
            this.compositionQualityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compositionQualityComboBox.FormattingEnabled = true;
            this.compositionQualityComboBox.Location = new System.Drawing.Point(5, 19);
            this.compositionQualityComboBox.Name = "compositionQualityComboBox";
            this.compositionQualityComboBox.Size = new System.Drawing.Size(115, 21);
            this.compositionQualityComboBox.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 500);
            this.Controls.Add(this.conversionOptionsGroupbox);
            this.Controls.Add(this.imagesInfoGroupBox);
            this.Controls.Add(this.pathControlsGroupBox);
            this.Name = "MainView";
            this.Text = "Image Converter v0.1";
            this.pathControlsGroupBox.ResumeLayout(false);
            this.pathControlsGroupBox.PerformLayout();
            this.imagesInfoGroupBox.ResumeLayout(false);
            this.imagesInfoGroupBox.PerformLayout();
            this.conversionOptionsGroupbox.ResumeLayout(false);
            this.newSizeGroupBox.ResumeLayout(false);
            this.newSizeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratioConvertTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TextBox destonationTextBox;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label destonationLabel;
        private System.Windows.Forms.Button destinationShowDialogButton;
        private System.Windows.Forms.Button sourceShowDialogButton;
        private System.Windows.Forms.GroupBox pathControlsGroupBox;
        private System.Windows.Forms.CheckBox deepSearchCheckBox;
        private System.Windows.Forms.ListView imagesInfoListView;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader sizeColumnHeader;
        private System.Windows.Forms.ColumnHeader sizeAfterColumnHeader;
        private System.Windows.Forms.GroupBox imagesInfoGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label sizeAfterConversionLabel;
        private System.Windows.Forms.Label fullSizeBeforeLabel;
        private System.Windows.Forms.GroupBox conversionOptionsGroupbox;
        private System.Windows.Forms.Button abortConvertingButton;
        private System.Windows.Forms.Button startConvertingButton;
        private System.Windows.Forms.GroupBox newSizeGroupBox;
        private System.Windows.Forms.TrackBar ratioConvertTrackBar;
        private System.Windows.Forms.RadioButton ratioRadioButton;
        private System.Windows.Forms.RadioButton allToSizeRadioButton;
        private System.Windows.Forms.Label imgHeightLabel;
        private System.Windows.Forms.TextBox imageNewHeightTextBox;
        private System.Windows.Forms.Label imgWidthLabel;
        private System.Windows.Forms.TextBox imageNewWidthTextBox;
        private System.Windows.Forms.ComboBox smoothingModeComboBox;
        private System.Windows.Forms.ComboBox interpolationComboBox;
        private System.Windows.Forms.ComboBox compositionQualityComboBox;
        private System.Windows.Forms.ComboBox convertFormatComboBox;
        private System.Windows.Forms.ProgressBar convertingProgess;
    }
}

