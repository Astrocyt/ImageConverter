using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageConverter.View.ViewInterface;
using ImageConverter.Presenter.PresenterInterface;
using ImageConverter.Model;

namespace ImageConverter.Presenter.PresenterClass
{
    public class NameConflictViewPresenter : INameConflictsViewPresenter
    {
        private INameConflictsView _view;
        private FileNameValidation _fileNameValidation; 
        private string[] _paths;
        private FileNameConflictSolver.ConflictOperation _operation ;
        
        public FileNameConflictSolver.ConflictOperation Operation { get { return _operation; } }


        public NameConflictViewPresenter(INameConflictsView view, string[] paths)
        {
            this._view = view;
            this._paths = paths;
            this._fileNameValidation = new FileNameValidation();
        }
        
        public void IgnoreFiles()
        {
            this._operation = FileNameConflictSolver.ConflictOperation.Ignore;
            _view.Close();
        }

        public void RenameFiles()
        {
            this._operation = FileNameConflictSolver.ConflictOperation.Rename;
            _view.Close();
        }

        public void ReplaceFiles()
        {
            this._operation = FileNameConflictSolver.ConflictOperation.Delete;
            _view.Close();
        }

        public void ShowView()
        {
            _view.SetConflictsPaths(_paths);
            _view.Show();
        }
    }
}
