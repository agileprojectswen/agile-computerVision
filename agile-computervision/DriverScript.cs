using System;
using System.Collections.Generic;
using System.Net.Http;

namespace agile_computervision
{
    class CropDiseaseDetection
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Retrieving Images from the Input Folder.......");

            HttpResponseMessage response = null;

            /*Get All Image from Input Folder*/
            List<string> files = FileHelpers.GetImages();

            if (files.Count == 0) { Console.WriteLine("No Images Found. Please upload images in 'Input' Folder:"); };

            foreach (var file in files)
            {
                Console.WriteLine($"Processing {file} ");
                response = Prediction.MakePredictionRequestAsync(file.ToString()).Result;
                Console.WriteLine($"Please View the Output folder for Results.{response.Content.ReadAsStringAsync().Result.ToString()}");
            }
        }
    }
}
