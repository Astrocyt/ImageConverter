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
            this.compositionQualityComboBox.Items.AddRange(ImageConvertProperties.AvalilableCompositionQuality);
            this.interpolationComboBox.Items.AddRange(ImageConvertProperties.AvailableInterpolationModes);
            this.smoothingModeComboBox.Items.AddRange(ImageConvertProperties.AvailableSmoothingModes);
            this.convertFormatComboBox.Items.AddRange(ImageConvertProperties.AvailableImageFormats);
            this.compositionQualityComboBox.SelectedIndex =
                this.interpolationComboBox.SelectedIndex = 
                this.smoothingModeComboBox.SelectedIndex = 
                this.convertFormatComboBox.SelectedIndex = 0;
            this.abortConvertingButton.Enabled = false;
            
            ActualizeConvertProperties();
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
            get 
            { 
                ActualizeConvertProperties();
                return _convertProperties; 
            }
        }

        public void AttachPresenter(IMainViewPresenter presenter)
        {
           this._presenter= presenter;
        }

        public void ActualizeLoadedImages(ImageInfo[] images)
        {
            this.imagesInfoListView.Items.Clear();
            ListViewItem listItem;
            
            foreach (var img in images)
            {
                listItem = new ListViewItem(img.Name);
                listItem.SubItems.Add(img.Size.ToString());
                listItem.SubItems.Add(img.Extension);
                imagesInfoListView.Items.Add(listItem);
            }

            this.fullSizeBeforeLabel.Text = string.Format("Actual size: {0:N3}",images.Sum(i=>i.Size)/(1024*1024));
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
            this._convertProperties.ImageFormat = convertFormatComboBox.SelectedItem.ToString();
            this._convertProperties.InterpolationMode = interpolationComboBox.SelectedItem.ToString();
            this._convertProperties.SmoothingMode = smoothingModeComboBox.SelectedItem.ToString();
        }

        public void ConvertingComplete()
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

        private void LoadImagesFromPath(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            _presenter.LoadImages(tb.Text, deepSearchCheckBox.Checked);
            if (imagesInfoListView.Items.Count > 0)
            {
                this.sourceLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                this.sourceLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
