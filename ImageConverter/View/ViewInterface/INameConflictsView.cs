using System;
using ImageConverter.Presenter.PresenterInterface;

namespace ImageConverter.View.ViewInterface
{
    public interface INameConflictsView
    {
        void AttachPresenter(INameConflictsViewPresenter conflictViewPresenter);
        void SetConflictsPaths(string[] paths);
        void Show();
        void Close();
    }
}
