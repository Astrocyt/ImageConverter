using ImageConverter.Model;

namespace ImageConverter.Presenter.PresenterInterface
{
    public delegate void ProgressChangeDelegate(double completePercent);
    public delegate void ConvertingCompletedDelegate();


    public interface IMainViewPresenter
    {
        event ProgressChangeDelegate ProgressChanged;
        event ConvertingCompletedDelegate ConvertingComplete;
        //size in B (lenght)
        long OrginalImagesSize {get; }
        long GetConvertedImagesSize {get; }
        void AbortConverting();
        void StartConverting();
        void LoadImages(string path,bool deepSearch);
    }
}
