using System.Drawing;

namespace ImageConverter.Model.Interface
{
    public interface ISizingMode
    {
        Size GetNewSize(int width, int height);
    }
}
