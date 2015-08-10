using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace ImageConverter.Model
{
    public class ImageConvertProperties
    {
        public string sourcePath;
        public string destonationPath;
        public bool ratioMode;
        public InterpolationMode interpolationMode;
        public CompositingQuality compositionQuality;
        public SmoothingMode smoothinMode;
        public ImageFormat imageFormat;
        public int width;
        public int height;
        public double ratio;
    }
}
