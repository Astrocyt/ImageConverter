using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System;
using System.Reflection;
using ImageConverter.Model.Interface;

namespace ImageConverter.Model
{
    public class ImageConvertProperties
    {
        public ISizingMode SizingMode 
        {
            get
            {
                return CreateSizingMode();
            }    
        }

        public bool ratioMode;
        public InterpolationMode interpolationMode;
        public CompositingQuality compositionQuality;
        public SmoothingMode smoothingMode;
        public ImageFormat imageFormat;
        public int width;
        public int height;
        public int ratio;

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
        public static string[] AvailableSmoothingModes
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
                    .Except(new string[] { "MemoryBmp", "Guid" }).Concat(new string[] { "Jpg" }).ToArray<string>();
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
                value = value == "Jpg" ? "Jpeg" : value;
                imageFormat = (ImageFormat)typeof(ImageFormat)
                    .InvokeMember(value.ToString(),BindingFlags.GetProperty,null,typeof(ImageFormat),null);
            }
        }

        ISizingMode CreateSizingMode()
        {
            ISizingMode sMode;
            if(ratioMode)
            {
                sMode = new RatioMode(ratio);
            }
            else
            {
                sMode = new FixedSizeMode(width,height);
            }
            return sMode;
        }
    }
}
