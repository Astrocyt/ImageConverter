using ImageConverter.Model;

namespace ImageConverter.Presenter.PresenterInterface
{
    public interface IMainViewPresenter
    {
        //size in B (lenght)
        long OrginalImagesSize {get; }
        long GetConvertedImagesSize {get; }
        void AbortConverting();
        void StartConverting();
        void LoadImages(string path,bool deepSearch);
    }
}
