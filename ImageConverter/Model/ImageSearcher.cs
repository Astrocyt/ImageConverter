using System;
using System.IO;
using System.Linq;

namespace ImageConverter.Model
{
    class ImageSearcher
    {
        public string[] GetImagesPaths(string sourceDirectory, bool deepSearch)
        {
            string[] images ;
            if(Directory.Exists(sourceDirectory))
            {
                SearchOption searchOption = deepSearch ? SearchOption.AllDirectories 
                    : SearchOption.TopDirectoryOnly;
                string[] allfiles = Directory.GetFiles(sourceDirectory,"*", searchOption);
                images = GetImages(allfiles, ImageConvertProperties.AvailableImageFormats);
                return images;
            }
            else images = new string[]{};
            return images;
        }
        public ImageInfo[] GetImagesInfo(string[] paths)
        {
            ImageInfo[] info = new ImageInfo[paths.Length];
            for (int i = 0; i < info.Length; i++)
            {
                info[i] = CreateImageInfo(paths[i]);
            }
            return info;
        }
        private string[] GetImages(string[] paths, string[] extensions) 
        {
            string[] result = 
                (from f in paths where extensions.Any(e => 
                    e.ToLower() == (Path.GetExtension(f).ToLower().TrimStart('.')))
                 select f).ToArray();
            return result;
        }
        private ImageInfo CreateImageInfo(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            long size = new FileInfo(path).Length;
            string extension = Path.GetExtension(path).Replace('.',' ').Trim();
            return new ImageInfo(name,extension,size);
        }
    }
}
