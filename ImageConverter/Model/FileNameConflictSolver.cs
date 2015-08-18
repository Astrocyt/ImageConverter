using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ImageConverter.Model
{
    public class FileNameConflictSolver
    {
        public enum ConflictOperation
        {
            Rename,Delete,Ignore
        };
        
        FileNameValidation _validation;
        
        public FileNameConflictSolver()
        {
            _validation = new FileNameValidation();
        }

        public string[] GetPathsWithoutConflicts(string[] filePaths,string destonationDirectory)
        {
            return (filePaths.Except
                (_validation.GetConflictFileNames(filePaths,destonationDirectory)))
                .ToArray<string>();
        }

        public string[] CreateDestonationPaths(string[] filePaths,string destonation)
        {
            string[] destPaths = new string[filePaths.Length];

            for (int i = 0; i < destPaths.Length; i++)
            {
                destPaths[i] = CreateDestonationPath(filePaths[i],destonation);
            }

            return destPaths;
        }

        public string[] GetRenamedDestonationPaths(string[] filePaths, string destonation)
        {
            string[] conflicts = _validation.GetConflictFileNames(filePaths,destonation);
            string[] result = new string[filePaths.Length];
            
            for (int i = 0; i < result.Length; i++)
            {
                if(conflicts.Contains(filePaths[i]))
                    result[i] = RenameDestonationPath(filePaths[i],destonation);
                else 
                    result[i] = CreateDestonationPath(filePaths[i],destonation);
            }
            return result;
        }

        public void DeleteConflictFiles(string[] files,string destonationFolder)
        {
            
        }

        public string CreateDestonationPath(string source,string destonation)
        {
            string name = Path.GetFileNameWithoutExtension(source);
            string extension = Path.GetExtension(source);
            if(!destonation.EndsWith(Path.DirectorySeparatorChar.ToString()))
                  destonation = string.Format("{0}{1}",destonation,Path.DirectorySeparatorChar.ToString());
            
            string result = string.Format("{0}{1}",destonation,name);
            return result;
        }

        public string RenameDestonationPath(string source,string destonation)
        {//without extension!
            string name = Path.GetFileNameWithoutExtension(source);
            if(!destonation.EndsWith("\\"))
                destonation+="\\";
            
            return string.Format("{1}{0}(1)",name,destonation);
        }
    }
}
