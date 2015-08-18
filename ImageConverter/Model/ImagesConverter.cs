using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;

namespace ImageConverter.Model
{
    public class ImagesConverter
    {

        #region Event & Delegates
        public delegate void ProgressChangeDelegate(double completePercent);
        public delegate void ConvertingCompletedDelegate();

        public event ProgressChangeDelegate ConvertingProgressChanged;
        public event ConvertingCompletedDelegate ConvertingComplete;
        #endregion

        private CancellationTokenSource _abortOperationTokenSource;
        private static ImagesConverter _imageConverterInstance;

        public string[] ImagesExtensions
        {
            get
            {
                return
                    (from e in typeof(ImageFormat).GetProperties() select e.Name.ToLower())
                .Concat(new string[] { "jpg" }).Except(new string[] { "guid" }).ToArray<string>();
            }
        }
        
        private ImagesConverter()
        {
            this._abortOperationTokenSource = new CancellationTokenSource();
        }
        
        public static ImagesConverter GetInstance()
        {
            if(_imageConverterInstance == null)
            {
                _imageConverterInstance = new ImagesConverter();
            }
            return _imageConverterInstance;
        }

        public void ConvertAllAsync(ImageConvertProperties convertProperties,string[] imagesPaths,string[] savePaths)
        {
            CancellationToken cancelTask = _abortOperationTokenSource.Token;
            
            Task.Factory.StartNew(()=>{
                for (int i = 0; i < imagesPaths.Length && !cancelTask.IsCancellationRequested; i++)
                {   
                    ProcessImage(imagesPaths[i],savePaths[i],convertProperties);

                    if(ConvertingProgressChanged != null)
                        ConvertingProgressChanged(i/(double)imagesPaths.Length);
                }
                if(ConvertingComplete != null)
                    ConvertingComplete();
            });
        }

        public void AbortAsyncConverting()
        {
            _abortOperationTokenSource.Cancel();
            _abortOperationTokenSource = new CancellationTokenSource();
        }

        private void ProcessImage(string source,string destonation, ImageConvertProperties convertProperties)
        {
            Image loadedImage = LoadImage(source);
            Image convertedImage = ConvertImage(loadedImage, convertProperties);
            string savePath = CreateSavePath(destonation,
                convertProperties.imageFormat);

            SaveImage(convertedImage, savePath);
        }

        private Image LoadImage(string path)
        {
            byte[] data;
            Image i;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                data = new BinaryReader(fs).ReadBytes((int)fs.Length);
                i = Image.FromStream(new MemoryStream(data));
                fs.Dispose();
            }
            Image imgLoaded = new Bitmap(new Bitmap(i));
            i.Dispose();
            return imgLoaded;
        }

        private void SaveImage(Image imageToSave,string savePath)
        {
            if(!File.Exists(savePath))
            {
                imageToSave.Save(savePath);
            }
            else 
            {
                throw new IOException("File with same name alredy exist !");
            }
            
        }
       
        private Image ConvertImage(Image sourceImage, ImageConvertProperties properties)
        {
            Image converted;
            Size size = properties.SizingMode.GetNewSize(sourceImage.Width,sourceImage.Height);

            converted = new Bitmap(size.Width,size.Height);
            using (Graphics g = Graphics.FromImage(converted))
            {
                g.InterpolationMode = properties.interpolationMode;
                g.SmoothingMode =  properties.smoothingMode;
                g.CompositingQuality = properties.compositionQuality;
                g.DrawImage(sourceImage, 0, 0, size.Width, size.Height);
            }
            return converted;
        }

        private string CreateSavePath(string savePath, ImageFormat format)
        {
            return string.Format("{0}.{1}",savePath,format.ToString());
        }
    }   
}
