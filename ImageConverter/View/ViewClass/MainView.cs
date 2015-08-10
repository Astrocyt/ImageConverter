using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;
using ImageConverter.Model;
using ImageConverter.Presenter.PresenterInterface;
using ImageConverter.View.ViewInterface;

namespace ImageConverter
{
    public partial class MainView : Form,IMainView
    {
        ImageConvertProperties _convertProperties;
        
        public MainView()
        {
            InitializeComponent();
            this._convertProperties = new ImageConvertProperties();
            InitializeDefaultComponentsProperties();
        }

        private void SourceFileDialog(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            
            if(result == DialogResult.OK)
            {
                this.sourceTextBox.Text = dialog.SelectedPath;    
                _presenter.LoadImages(dialog.SelectedPath,deepSearchCheckBox.Checked);
            }
        }

        private void DestonationFileDialog(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.destonationTextBox.Text = dialog.SelectedPath;
            }
        }

        private void InitializeDefaultComponentsProperties()
        {
            //controls properties
            this.ratioRadioButton.Checked = true;
            this.ratioRadioButton.Text = "Ratio 1:" + ratioConvertTrackBar.Value.ToString();
            this.imageNewWidthTextBox.Text = imageNewHeightTextBox.Text = "0";
            this.compositionQualityComboBox.Items.AddRange(Enum.GetNames(typeof(CompositingQuality)));
            this.interpolationComboBox.Items.AddRange(Enum.GetNames(typeof(InterpolationMode)));
            this.smoothingModeComboBox.Items.AddRange(Enum.GetNames(typeof(SmoothingMode)));
            this.convertFormatComboBox.Items.AddRange((from p in typeof(ImageFormat).GetProperties() where p.Name!="Guid" select p.Name).ToArray<string>());
            this.compositionQualityComboBox.SelectedIndex =
                this.interpolationComboBox.SelectedIndex = 
                this.smoothingModeComboBox.SelectedIndex = 
                this.convertFormatComboBox.SelectedIndex = 0;
            this.abortConvertingButton.Enabled = false;
            //ConverProperties object 
            this._convertProperties.ratio = ratioConvertTrackBar.Value;
            this._convertProperties.ratioMode = true;
            this._convertProperties.width = int.Parse(imageNewHeightTextBox.Text);
            this._convertProperties.height = int.Parse(imageNewWidthTextBox.Text);
            this._convertProperties.imageFormat = (ImageFormat)(typeof(ImageFormat).
                InvokeMember(convertFormatComboBox.SelectedItem.ToString(), BindingFlags.GetProperty, null, typeof(ImageFormat), null));
            this._convertProperties.smoothinMode = (SmoothingMode)Enum.Parse(typeof(SmoothingMode),smoothingModeComboBox.SelectedItem.ToString());
            this._convertProperties.interpolationMode = (InterpolationMode)Enum.Parse(typeof(InterpolationMode),interpolationComboBox.SelectedItem.ToString());
           // this._convertProperties.
        }

        private void RatioConversionMode(object sender, EventArgs e)
        {
            imageNewHeightTextBox.Enabled = imageNewWidthTextBox.Enabled =
               !(sender as RadioButton).Checked;
            ratioConvertTrackBar.Enabled = (sender as RadioButton).Checked;
        }
        
        private void AllToSizeConversionMode(object sender, EventArgs e)
        {
            imageNewHeightTextBox.Enabled = imageNewWidthTextBox.Enabled =
                (sender as RadioButton).Checked;
            ratioConvertTrackBar.Enabled = !(sender as RadioButton).Checked;
        }

        #region Interface IMainView implemetation
        
        private IMainViewPresenter _presenter;

        public ImageConvertProperties ConvertProperties
        { 
            get { return _convertProperties; }
        }

        public void AttachPresenter(IMainViewPresenter presenter)
        {
           this._presenter= presenter;
           this._presenter.ProgressChanged += new ProgressChangeDelegate(ActualizeConvertingProgress);
           this._presenter.ConvertingComplete += new ConvertingCompletedDelegate(ConvertingComplete);
        }

        public void ActualizeLoadedImages(ImageInfo[] images)
        {
            this.imagesInfoListView.Items.Clear();
            ListViewItem listItem;
            
            foreach (var img in images)
            {
                listItem = new ListViewItem(System.IO.Path.GetFileNameWithoutExtension(img.imagePath));
                listItem.SubItems.Add(img.sizeBeforeConversion.ToString());
                listItem.SubItems.Add(img.sizeAfterConversion.ToString());
                imagesInfoListView.Items.Add(listItem);
            }

            UpdateSizesLabels();
        }

        public void ActualizeConvertingProgress(double successPercent)
        {
            this.Invoke((MethodInvoker)(()=>{
                this.convertingProgess.Value = (int)(successPercent * 100);
            }));        
        }

        #endregion

        private void ChangeRatioValue(object sender, EventArgs e)
        {
            int value = (sender as TrackBar).Value;
            this.ratioRadioButton.Text = string.Format("Ratio 1:{0} ({1:N2})",value,1/(double)value);
            //converted size label = _presenter.GetConverteSize...
        }

        private void StartConverting(object sender, EventArgs e)
        {
            ActualizeConvertProperties();
            _presenter.StartConverting();
            (sender as Button).Enabled = false;
            abortConvertingButton.Enabled = true;
        }

        private void AbortConverting(object sender, EventArgs e)
        {
            _presenter.AbortConverting();
            (sender as Button).Enabled = false;
            startConvertingButton.Enabled = true;
        }

        private void ActualizeConvertProperties()
        {
            this._convertProperties.height = int.Parse(imageNewHeightTextBox.Text);
            this._convertProperties.width = int.Parse(imageNewWidthTextBox.Text);
            this._convertProperties.sourcePath = sourceTextBox.Text;
            this._convertProperties.destonationPath = destonationTextBox.Text;
            this._convertProperties.ratioMode = ratioRadioButton.Checked;
            this._convertProperties.ratio = ratioConvertTrackBar.Value;
            this._convertProperties.imageFormat = (ImageFormat)typeof(ImageFormat)
                .InvokeMember(convertFormatComboBox.Text, BindingFlags.GetProperty, null, typeof(ImageFormat), null);
            this._convertProperties.interpolationMode = (InterpolationMode)Enum.Parse(typeof(InterpolationMode),
                interpolationComboBox.SelectedItem.ToString());
            this._convertProperties.smoothinMode = (SmoothingMode)Enum.Parse(typeof(SmoothingMode),
                smoothingModeComboBox.Text.ToString());
        }

        private void ConvertingComplete()
        {
            this.Invoke((MethodInvoker)(()=>{
                this.ActualizeConvertingProgress(0);
                this.abortConvertingButton.Enabled = false;
                this.startConvertingButton.Enabled = true;
            }));
        }

        private void ChangeToDeepSearch(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(sourceTextBox.Text))
                _presenter.LoadImages(sourceTextBox.Text,(sender as CheckBox).Checked);
        }

        private void UpdateSizesLabels()
        {
            fullSizeBeforeLabel.Text = string.Format("Actual size: {0:N2} Mbit",
                (double)_presenter.OrginalImagesSize/Math.Pow(1000,2));
            sizeAfterConversionLabel.Text = string.Format("After (around): {0:N2} Mbit",_presenter.GetConvertedImagesSize);
        }
    }
}
