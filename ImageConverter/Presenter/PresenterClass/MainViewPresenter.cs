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
        private IMainView _view;
        private string[] _loadedImages;
        private ImageSearcher _imageSearcher;
        private ImagesConverter _imagesConverter;
    
        public MainViewPresenter(IMainView mainView)
        {
            this._view = mainView;
            
            _imageSearcher = new ImageSearcher();
            _imagesConverter = ImagesConverter.GetInstance();
            _imagesConverter.ConvertingComplete += ConvertingComplete;
            _imagesConverter.ConvertingProgressChanged += ConvertingProgressChanged;
        }

        public void AbortConverting()
        {
            ImagesConverter.GetInstance().AbortAsyncConverting();
        }

        public void StartConverting()
        {
            ImagesConverter.GetInstance().ConvertAllAsync(_view.ConvertProperties,_loadedImages);
        }

        public void LoadImages(string path, bool deepSearch)
        {
            string[] paths = _imageSearcher.GetImagesPaths(path,deepSearch);
            ImageInfo[] info = _imageSearcher.GetImagesInfo(paths);
            this._loadedImages = paths;
            this._view.ActualizeLoadedImages(info);
        }
        
        private void ConvertingProgressChanged(double percentComplete)
        {
            _view.ActualizeConvertingProgress(percentComplete);
        }
        
        private void ConvertingComplete()
        {
            _view.ConvertingComplete();
        }
    }
}
