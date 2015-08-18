using ImageConverter.Model;
using ImageConverter.Presenter.PresenterInterface;
using ImageConverter.View.ViewInterface;
using ImageConverter.View.ViewClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ImageConverter.Presenter.PresenterClass
{
    class MainViewPresenter : IMainViewPresenter
    {
        private IMainView _view;
        private string[] _loadedImages;
        private string _saveDirectory;
        private ImageSearcher _imageSearcher;
        private ImagesConverter _imagesConverter;
        private FileNameValidation _fileNameValidation;
        private FileNameConflictSolver _nameSolver;
    
        public string SaveDirectory {set{_saveDirectory = value;}}

        public MainViewPresenter(IMainView mainView)
        {
            this._view = mainView;
            
            _imageSearcher = new ImageSearcher();
            _imagesConverter = ImagesConverter.GetInstance();
            _fileNameValidation = new FileNameValidation();
            _imagesConverter.ConvertingComplete += ConvertingComplete;
            _imagesConverter.ConvertingProgressChanged += ConvertingProgressChanged;
            _nameSolver = new FileNameConflictSolver();
        }

        public void AbortConverting()
        {
           _imagesConverter.AbortAsyncConverting();
        }

        public void StartConverting()
        {
            string[] save = ValidateSavePaths();
            _imagesConverter.ConvertAllAsync(_view.ConvertProperties,_loadedImages,save);
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

        private string[] ValidateSavePaths()
        {
            string[] conflicts = _fileNameValidation.GetConflictFileNames(_loadedImages,_saveDirectory);
            string[] paths;
            if(conflicts.Length == 0)
            {
                paths = _nameSolver.CreateDestonationPaths(_loadedImages,_saveDirectory);
            }
            else
            {
                paths = SolveNameConflicts(conflicts);
            }
            return paths;
        }

        private string[] SolveNameConflicts(string[] conflicts)
        {
            INameConflictsView view = new NameConflictsView();
            INameConflictsViewPresenter presenter = new NameConflictViewPresenter(view,conflicts);
            view.AttachPresenter(presenter);
            presenter.ShowView();
            var operation = presenter.Operation;
            string[] result;

            if(operation == FileNameConflictSolver.ConflictOperation.Rename)
            {
                result = _nameSolver.GetRenamedDestonationPaths(_loadedImages,_saveDirectory);
            }
            else if(operation == FileNameConflictSolver.ConflictOperation.Delete)
            {
                _nameSolver.DeleteConflictFiles(_loadedImages,_saveDirectory);
                result = _nameSolver.CreateDestonationPaths(_loadedImages,_saveDirectory);
            }
            else
            {
                _loadedImages = _nameSolver.GetPathsWithoutConflicts(_loadedImages, _saveDirectory);
                result = _nameSolver.CreateDestonationPaths(_loadedImages, _saveDirectory);
            }
            return result;
        }
    }
}
