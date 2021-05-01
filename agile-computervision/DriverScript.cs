using System;
using System.Collections.Generic;

namespace agile_computervision
{
    class CropDiseaseDetection
    {
        static void Main(string[] args)
        {
            /*Clear Results From Ouput Folder*/
            FileHelpers.ClearResults();

            /*Warning Message*/
            GenericUtilities.UserAlertMessage(UserMessage.FileFormatMessage);

            /*Read Image From Input Folder*/
            Console.WriteLine("Retrieving Images from the Input Folder.......");

            /*Get All Image from Input Folder*/
            List<string> files = FileHelpers.GetImages();

            if (files.Count == 0) { Console.WriteLine("No Images Found. Please upload images in 'Input' Folder:"); };

            /*Process Image*/
            ImagePrediction.ProcessImages(files);
        }
    }

}
