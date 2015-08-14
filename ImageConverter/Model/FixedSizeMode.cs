using System;
using ImageConverter.Model.Interface;

namespace ImageConverter.Model
{
    class FixedSizeMode : ISizingMode
    {
        int _width;
        int _height;

        public System.Drawing.Size GetNewSize(int width, int height)
        {
            return new System.Drawing.Size(_width,_height);
        }

        public FixedSizeMode(int width,int height)
        {
            this._width = width;
            this._height = height;
        }
    }
}
