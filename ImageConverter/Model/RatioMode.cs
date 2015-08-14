using System;
using ImageConverter.Model.Interface;
namespace ImageConverter.Model
{
    class RatioMode : ISizingMode
    {
        private int _ratio;
        
        public System.Drawing.Size GetNewSize(int width,int height)
        {
            double resizeRatio = 1/(double)_ratio;
            int newWidth =  (int)(width * resizeRatio);
            int newHeight = (int)(height * resizeRatio);

            return new System.Drawing.Size(newWidth,newHeight);
        }

        public RatioMode(int ratio)
        {
            this._ratio=ratio;
        }
    }
}
