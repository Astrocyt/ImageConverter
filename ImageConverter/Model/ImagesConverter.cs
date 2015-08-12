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

        public void ConvertAllAsync(ImageConvertProperties convertProperties,string[] imagesPaths)
        {
            CancellationToken cancelTask = _abortOperationTokenSource.Token;
            Task.Factory.StartNew(()=>{
                for (int i = 0; i < imagesPaths.Length && !cancelTask.IsCancellationRequested; i++)
                {
                    ConvertImage(imagesPaths[i],convertProperties);
                    if(ConvertingProgressChanged != null)
                        ConvertingProgressChanged(i/(double)imagesPaths.Length);
                }
                if(ConvertingComplete != null)
                    ConvertingComplete();
            });
        }

        public string[] GetAllImagesPaths(string path,bool deepSearch)
        {
            if(Directory.Exists(path))
            {
                string[] imagesPaths;
                SearchOption searchType = deepSearch ? 
                    SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                
                imagesPaths = Directory.GetFiles(path,"*",searchType);
                imagesPaths = FindOnlyPicturesFiles(imagesPaths);

                return imagesPaths;
            }
            else return new string[]{};
        }
        
        public void ConvertImage(string imagePath,ImageConvertProperties properties)
        {
            Image loadedImage = LoadImage(imagePath);
            Image convertedImage;
            int width,height;
            
            string savePath = string.Format("{0}\\{1}.{2}",
                properties.destonationPath,
                Path.GetFileNameWithoutExtension(imagePath),
                properties.imageFormat.ToString().ToLower());

            if (properties.ratioMode)
            {
                double ratio = 1/(double)properties.ratio;
                width = (int)(loadedImage.Width * ratio);
                height = (int)(loadedImage.Height * ratio);
            }
            else
            {
                width = properties.width;
                height = properties.height;
            }
            convertedImage = new Bitmap(width, height);
            DrawImgtoBitmap(ref convertedImage,loadedImage,properties);
            convertedImage.Save(savePath,properties.imageFormat);
        }

        public void AbortAsyncConverting()
        {
            _abortOperationTokenSource.Cancel();
            _abortOperationTokenSource = new CancellationTokenSource();
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
       
        private void DrawImgtoBitmap(ref Image bitmap, Image sourceImage, ImageConvertProperties properties)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = properties.interpolationMode;
                g.SmoothingMode =  properties.smoothingMode;
                g.CompositingQuality = properties.compositionQuality;
                g.DrawImage(sourceImage, 0, 0, bitmap.Width, bitmap.Height);
            }
        }

        private string[] FindOnlyPicturesFiles(string[] fTable)
        {
            return (from f in fTable
                    where ImagesExtensions.Contains(Path.GetExtension(f).TrimStart('.'))
                    select f).ToArray<string>();
        }
    }   
}
