using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System;
using System.Reflection;
namespace ImageConverter.Model
{
    public class ImageConvertProperties
    {

        public string sourcePath;
        public string destonationPath;
        public bool ratioMode;
        public InterpolationMode interpolationMode;
        public CompositingQuality compositionQuality;
        public SmoothingMode smoothingMode;
        public ImageFormat imageFormat;
        public int width;
        public int height;
        public double ratio;

        public static string[] AvailableInterpolationModes 
        {
            get
            {
                return (Enum.GetNames(typeof(InterpolationMode))
                    .Except(new string[]{"Invalid","Default"})).ToArray<string>();
            }
        }
        public static string[] AvalilableCompositionQuality
        {
            get
            {
                return (Enum.GetNames(typeof(CompositingQuality))
                    .Except(new string[]{"Invalid","Default"})).ToArray<string>();
            }
        }
        public static string[] AvalilableSmoothingModes
        {
            get
            {
                return (Enum.GetNames(typeof(SmoothingMode))
                    .Except(new string[]{"Invalid","Default"})).ToArray<string>();
            }
        }
        public static string[] AvailableImageFormats
        {
            get
            {
                return (from p in typeof(ImageFormat).GetProperties() select p.Name)
                    .Except(new string[]{"MemoryBmp","Guid"}).ToArray<string>();
            }
        }

        public string InterpolationMode 
        { 
            set
            {
                this.interpolationMode = (InterpolationMode)Enum.Parse(typeof(InterpolationMode),value);
            } 
        }
        public string CompositionQuality
        {
            set
            {
                this.compositionQuality = (CompositingQuality)Enum.Parse(typeof(CompositingQuality),value);
            }
        }
        public string SmoothingMode
        {
            set
            {
                this.smoothingMode = (SmoothingMode)Enum.Parse(typeof(SmoothingMode),value);
            }
        }
        public string ImageFormat
        {
            set
            {
                imageFormat = (ImageFormat)typeof(ImageFormat)
                    .InvokeMember(value,BindingFlags.GetProperty,null,typeof(ImageFormat),null);
            }
        }
    }
}
