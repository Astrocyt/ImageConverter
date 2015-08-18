using System;
using System.IO;
using System.Linq;

namespace ImageConverter.Model
{
    public class FileNameValidation
    {
        

        public FileNameValidation()
        {}

        public string[] GetConflictFileNames(string[] sourcePaths,string directory)
        {   
            return
                (from i in sourcePaths where (from f in Directory.GetFiles(directory)
                                               select Path.GetFileNameWithoutExtension(f))
                                               .Contains(Path.GetFileNameWithoutExtension(i)) select i).ToArray();
        }
    }
}
