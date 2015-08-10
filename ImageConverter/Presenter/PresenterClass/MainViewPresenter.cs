using ImageConverter.Model;
using ImageConverter.Presenter.PresenterInterface;
using ImageConverter.View.ViewInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


namespace ImageConverter.Presenter.PresenterClass
{
    class MainViewPresenter : IMainViewPresenter
    {
        public event ProgressChangeDelegate ProgressChanged;
        public event ConvertingCompletedDelegate ConvertingComplete;

        private IMainView _view;
        private ImageInfo[] _loadedImages;
        private CancellationTokenSource _abortConverting;
        private string[] ImagesExtensions
        {
            get
            {
                return
                    (from e in typeof(ImageFormat).GetProperties() select e.Name.ToLower())
                .Concat(new string[] { "jpg" }).Except(new string[] { "guid" }).ToArray<string>();
            }
        }
        
        public MainViewPresenter(IMainView mainView)
        {
            this._view = mainView;
        }

        public long OrginalImagesSize
        {
            get { return _loadedImages.Sum(l => l.sizeBeforeConversion); }
        }

        public long GetConvertedImagesSize
        {
           get {return 0; }
        }

        public void AbortConverting()
        {
            _abortConverting.Cancel();
        }

        public void StartConverting()
        {
            this._abortConverting = new CancellationTokenSource();
            CancellationToken cancelTask = _abortConverting.Token;
            
            Task.Factory.StartNew(()=>{
                
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                for (int i = 0; i < _loadedImages.Length &&
                    !cancelTask.IsCancellationRequested; i++)
                {
                    ConvertAndSaveImage(_loadedImages[i]);
                    
                    if(ProgressChanged != null)
                        ProgressChanged((double)i/_loadedImages.Length);
                }
                if(ConvertingComplete != null)
                    ConvertingComplete();
            });
        }

        public void LoadImages(string path, bool deepSearch)
        {
            ImageInfo[] images;
            string[] findedFiles;
            
            if(!deepSearch)
                findedFiles = Directory.GetFiles(path);
            else findedFiles = Directory.GetFiles(path,"*",SearchOption.AllDirectories);

            findedFiles = FindOnlyPicturesFiles(findedFiles);   
            images = new ImageInfo[findedFiles.Length];
            
            for (int i = 0; i < images.Length; i++)
            {
                images[i].imagePath = findedFiles[i];
                images[i].sizeBeforeConversion = new FileInfo(findedFiles[i]).Length;
                images[i].sizeAfterConversion = 0;
            }

            this._loadedImages = images;
            _view.ActualizeLoadedImages(images);
        }


        private string[] FindOnlyPicturesFiles(string[] fTable)
        {
            return (from f in fTable
                    where ImagesExtensions.Contains(Path.GetExtension(f).TrimStart('.'))
                    select f).ToArray<string>();
        }
        private void ConvertAndSaveImage(ImageInfo orgImage)
        {
            //wtf ?
             byte[] data;
            Image i;
            using(FileStream fs = new FileStream(orgImage.imagePath,FileMode.Open))
            {
                data = new BinaryReader(fs).ReadBytes((int)fs.Length);
                i = Image.FromStream(new MemoryStream(data));
            }
            //-- ? --
            //Image loadedImage = Bitmap.FromFile(orgImage.imagePath);
            Image loadedImage = new Bitmap(new Bitmap((Image)i.Clone()));
            Image imageReadyToSave;
            string savePath = string.Format("{0}\\{1}.{2}",
                _view.ConvertProperties.destonationPath,
                Path.GetFileNameWithoutExtension(orgImage.imagePath),
                _view.ConvertProperties.imageFormat.ToString().ToLower());
            
            if(_view.ConvertProperties.ratioMode)
            {
                imageReadyToSave = ConvertToRatio(loadedImage); 
            }
            else
            {
                imageReadyToSave = ConvertToSize(loadedImage);
            }

            imageReadyToSave.Save(savePath, _view.ConvertProperties.imageFormat);
        }
        private Image ConvertToRatio(Image img)
        {
           double ratio = 1/(double)_view.ConvertProperties.ratio;
           int width = (int)(img.Width * ratio);
           int height = (int)(img.Height * ratio);
           Image converted  = new Bitmap(width,height);
           DrawImgtoBitmap(ref converted,img); 
           return converted;
        }
        private Image ConvertToSize(Image img)
        {
            Image converted = new Bitmap(_view.ConvertProperties.width,
                _view.ConvertProperties.height);
            DrawImgtoBitmap(ref converted,img);
            return converted;
        }
        private void DrawImgtoBitmap(ref Image bitmap,Image sourceImage)
        {
            
            using(Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = _view.ConvertProperties.interpolationMode;
                g.SmoothingMode = _view.ConvertProperties.smoothinMode;
                g.CompositingQuality = _view.ConvertProperties.compositionQuality;

                //bitmap = new Bitmap(bitmap.Width,bitmap.Height,g);
                g.DrawImage(sourceImage,0,0,bitmap.Width,bitmap.Height);
            }
        }

    }
}
