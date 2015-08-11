using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;

namespace ImageConverter.Model
{
    public class ImagesConverter
    {
        public delegate void ProgressChangeDelegate(double completePercent);
        public delegate void ConvertingCompletedDelegate();

        public event ProgressChangeDelegate ConvertingProgressChanged;
        public event ConvertingCompletedDelegate ConvertingComplete;
        
        public ImageInfo[] ImagesLoaded {get; private set;}
        public long ImagesSize 
        {get {return ImagesLoaded.Sum(i => i.sizeBeforeConversion);}} 
        
        public string[] ImagesExtensions
        {
            get
            {
                return
                    (from e in typeof(ImageFormat).GetProperties() select e.Name.ToLower())
                .Concat(new string[] { "jpg" }).Except(new string[] { "guid" }).ToArray<string>();
            }
        }
        
        public ImagesConverter(ImageInfo[] imagesToConvert)
        {
            this.ImagesLoaded = imagesToConvert;
        }
        public ImagesConverter(string path,bool deepSearch)
        {
            string[] findedFiles;
            string[] imagesPaths;
            
            if(deepSearch)
                findedFiles = Directory.GetFiles(path,"*",SearchOption.AllDirectories);
            else findedFiles = Directory.GetFiles(path);

            imagesPaths = FindOnlyPicturesFiles(findedFiles);
            this.ImagesLoaded = ConvertPathsToImageInfo(imagesPaths);
        }

        
        public void ConvertAll(ImageConvertProperties convertProperties)
        {
           
        }
        public void ConvertAll(ImageConvertProperties convertProperties,CancellationToken cancelToken)
        {
            for (int i = 0; i < ImagesLoaded.Length &&
                !cancelToken.IsCancellationRequested; i++)
            {
                ConvertAndSaveImage(ImagesLoaded[i], convertProperties);

                if (ConvertingProgressChanged != null)
                    ConvertingProgressChanged((double)i / ImagesLoaded.Length);
            }

            if (ConvertingComplete != null)
                ConvertingComplete();
        }

        public void AddImage(string path)
        {
            ImagesLoaded.Concat(ConvertPathsToImageInfo(new string[]{path}));
        }
        public void AddImages(string[] paths)
        {
            ImagesLoaded.Concat(ConvertPathsToImageInfo(paths));
        }
        public void AddImage(ImageInfo image)
        { ImagesLoaded.Concat(new ImageInfo[]{image}); }
        public void AddImages(ImageInfo[] images)
        { ImagesLoaded.Concat(images); }

        private ImageInfo[] ConvertPathsToImageInfo(string[] paths)
        {
            ImageInfo[] imgInfo = new ImageInfo[paths.Length];

            for (int i = 0; i < paths.Length; i++)
            {
                imgInfo[i].imagePath = paths[i];
                imgInfo[i].sizeBeforeConversion = new FileInfo(paths[i]).Length;
            }
            return imgInfo;
        }
        private string[] FindOnlyPicturesFiles(string[] fTable)
        {
            return (from f in fTable
                    where ImagesExtensions.Contains(Path.GetExtension(f).TrimStart('.'))
                    select f).ToArray<string>();
        }
        //Converting img to ImageConvertProperties methods
        private void ConvertAndSaveImage(ImageInfo orgImage,ImageConvertProperties properties)
        {
            //wtf ?
            byte[] data;
            Image i;
            using (FileStream fs = new FileStream(orgImage.imagePath, FileMode.Open))
            {
                data = new BinaryReader(fs).ReadBytes((int)fs.Length);
                i = Image.FromStream(new MemoryStream(data));
            }
            //-- ? --
            //Image loadedImage = Bitmap.FromFile(orgImage.imagePath);
            Image loadedImage = new Bitmap(new Bitmap((Image)i.Clone()));
            Image imageReadyToSave;
            
            string savePath = string.Format("{0}\\{1}.{2}",
                properties.destonationPath,
                Path.GetFileNameWithoutExtension(orgImage.imagePath),
                properties.imageFormat.ToString().ToLower());

            if (properties.ratioMode)
            {
                imageReadyToSave = ConvertToRatio(loadedImage,properties);
            }
            else
            {
                imageReadyToSave = ConvertToSize(loadedImage,properties);
            }

            imageReadyToSave.Save(savePath, properties.imageFormat);
        }
        private Image ConvertToRatio(Image img,ImageConvertProperties properties)
        {
            double convertRatio = 1 / (double)properties.ratio;
            int width = (int)(img.Width * convertRatio);
            int height = (int)(img.Height * convertRatio);
            Image converted = new Bitmap(width, height);
            DrawImgtoBitmap(ref converted, img,properties);
            return converted;
        }
        private Image ConvertToSize(Image img,ImageConvertProperties properties)
        {
            Image converted = new Bitmap(properties.width, properties.height);
            DrawImgtoBitmap(ref converted, img,properties);
            return converted;
        }
        private void DrawImgtoBitmap(ref Image bitmap, Image sourceImage, ImageConvertProperties properties)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = properties.interpolationMode;
                g.SmoothingMode =  properties.smoothinMode;
                g.CompositingQuality = properties.compositionQuality;

                //bitmap = new Bitmap(bitmap.Width,bitmap.Height,g);
                g.DrawImage(sourceImage, 0, 0, bitmap.Width, bitmap.Height);
            }
        }
    }   
}
