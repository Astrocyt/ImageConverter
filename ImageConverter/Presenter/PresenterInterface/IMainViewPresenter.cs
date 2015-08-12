using ImageConverter.Model;

namespace ImageConverter.Presenter.PresenterInterface
{
    public interface IMainViewPresenter
    {
        //size in B (lenght)
        void AbortConverting();
        void StartConverting();
        void LoadImages(string path,bool deepSearch);
    }
}
