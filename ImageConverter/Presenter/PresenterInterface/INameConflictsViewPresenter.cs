
using ImageConverter.View.ViewInterface;
using ImageConverter.Model;
namespace ImageConverter.Presenter.PresenterInterface
{
    public interface INameConflictsViewPresenter
    {
        FileNameConflictSolver.ConflictOperation Operation {get;}
        void IgnoreFiles();
        void ReplaceFiles();
        void RenameFiles();
        void ShowView();
    }
}
