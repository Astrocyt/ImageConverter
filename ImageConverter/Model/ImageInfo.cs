using System.IO;
namespace ImageConverter.Model
{
    public struct ImageInfo
    {
        public long Size{get;private set;}
        public string Name{get;private set;}
        public string Extension {get;private set;}

        public ImageInfo(string name,string extension,long size):this()
        {
            this.Size = size;
            this.Name = name;
            this.Extension = extension;
        }
    }
}