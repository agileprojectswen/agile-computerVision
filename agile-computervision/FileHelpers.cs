using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace agile_computervision
{
    public class FileHelpers
    {
        public static string workingDirectory = Environment.CurrentDirectory;
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        public static dynamic GetImages()
        {
            return GetFiles("Input");
        }

        /*To Filter .jpg & .jpeg Images*/
        private static Func<string, bool> FilterImage = (filename) => { return Regex.IsMatch(filename, @".jpeg|.jpg$"); };

        private static Func<string, List<string>> GetFiles = (folderName) =>
        {

            return Directory.GetFiles($"{projectDirectory}/{folderName}", "*.*", SearchOption.AllDirectories).Where(f => FilterImage(f))
                            .Select(f => f)
                            .ToList();
        };

        public static Func<string, bool> DeleteFolder = (outputFolderName) =>
              {
                  DirectoryInfo directory = new DirectoryInfo($"{projectDirectory}/Output/{outputFolderName}");
                  directory.EnumerateFiles().ToList().ForEach(f => f.Delete());
                  return true;
              };

        public static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        public static void CopyFiles(string sourcePath, string destinationFolder)
        {
            string destinationPath = $"{projectDirectory}/Output/{destinationFolder}";

            System.IO.File.Copy(sourcePath, System.IO.Path.Combine(destinationPath, System.IO.Path.GetFileName(sourcePath)));
        }

        public static void ClearResults()
        {
            DeleteFolder("Healthy");
            DeleteFolder("Diseased");
        }
    }
}
