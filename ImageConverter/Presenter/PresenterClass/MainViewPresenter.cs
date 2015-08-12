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
    
        public MainViewPresenter(IMainView mainView)
        {
            this._view = mainView;
            ImagesConverter converter = ImagesConverter.GetInstance();
            converter.ConvertingComplete += ConvertingComplete;
            converter.ConvertingProgressChanged += ConvertingProgressChanged;
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
            ImagesConverter converter = ImagesConverter.GetInstance();
            string[] paths = converter.GetAllImagesPaths(path,deepSearch);
            ImageInfo[] info = ImageInfo.CreateImageInfoFromPaths(paths);
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
