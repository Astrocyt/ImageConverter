using ImageConverter.Presenter.PresenterInterface;
using ImageConverter.Model;

namespace ImageConverter.View.ViewInterface
{
    public interface IMainView
    {
        ImageConvertProperties ConvertProperties { get;}
        void AttachPresenter(IMainViewPresenter presenter);
        void ActualizeLoadedImages(ImageInfo[] images);
    }
}
