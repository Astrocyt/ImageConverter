using System.IO;
namespace ImageConverter.Model
{
    public struct ImageInfo
    {
        public long Size{get;private set;}
        public string Name{get;private set;}
        public string Extension {get;private set;}

        public ImageInfo(string path):this()
        {
            this.Size = new FileInfo(path).Length;
            this.Name = Path.GetFileNameWithoutExtension(path);
            this.Extension = Path.GetExtension(path).TrimStart('.');
        }

        public static ImageInfo[] CreateImageInfoFromPaths(string[] paths)
        {
            ImageInfo[] imgInfo = new ImageInfo[paths.Length];
            for (int i = 0; i < imgInfo.Length; i++)
            {
                imgInfo[i] = new ImageInfo(paths[i]);
            }
            return imgInfo;
        }
    }
}