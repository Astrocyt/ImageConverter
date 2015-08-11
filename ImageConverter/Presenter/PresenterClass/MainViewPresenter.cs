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
        private CancellationTokenSource _abortConverting;
        private ImagesConverter _imagesConverter;

        public long OrginalImagesSize
        {
            get {
                if(_imagesConverter != null)
                    return _imagesConverter.ImagesSize;
                else return 0;
                }
        }

        public long GetConvertedImagesSize
        {
            get { return 0; }
        }
        
        public MainViewPresenter(IMainView mainView)
        {
            this._view = mainView;
        }

        public void AbortConverting()
        {
            _abortConverting.Cancel();
        }

        public void StartConverting()
        {
            this._abortConverting = new CancellationTokenSource();
            CancellationToken cancelTask = _abortConverting.Token;
            Task.Factory.StartNew(()=>
            {
                    _imagesConverter.ConvertAll(_view.ConvertProperties,cancelTask);
            });
        }

        public void LoadImages(string path, bool deepSearch)
        {
           this._imagesConverter = new ImagesConverter(path,deepSearch);
           this._view.ActualizeLoadedImages(_imagesConverter.ImagesLoaded);
           AssingEvents();
        }

        private void AssingEvents()
        {
            this._imagesConverter.ConvertingProgressChanged += 
                new ImagesConverter.ProgressChangeDelegate(_view.ActualizeConvertingProgress);
            this._imagesConverter.ConvertingComplete += 
                new ImagesConverter.ConvertingCompletedDelegate(_view.ConvertingComplete);
        }

    }
}
