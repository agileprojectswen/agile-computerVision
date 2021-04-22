using System;

namespace agile_computervision
{
    class CropDiseaseDetection
    {
        static void Main(string[] args)
        {
            /*Get All Image from Input Folder*/
            var files = FileHelpers.GetImages();
            Console.WriteLine(files.ToString());

        }

    }
}
