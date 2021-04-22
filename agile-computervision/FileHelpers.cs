using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace agile_computervision
{
    public class FileHelpers
    {
        public static dynamic GetImages()
        {
            return GetFiles("Input");
        }

        /*To Filter .jpg & .jpeg Images*/
        private static Func<string, bool> FilterImage = (filename) => { return Regex.IsMatch(filename, @".jpeg|.jpg$"); };

        private static Func<string, List<string>> GetFiles = (folderName) =>
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return Directory.GetFiles($"{projectDirectory}/{folderName}", "*.*", SearchOption.AllDirectories).Where(f => FilterImage(f))
                            .Select(f => f)
                            .ToList();
        };
    }
}
