﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace agile_computervision
{
    public class ImagePrediction
    {
        public static async Task<HttpResponseMessage> MakePredictionRequestAsync(string imageFilePath)
        {
            var client = new HttpClient();

            // Request headers - replace this example key with your valid Prediction-Key.
            client.DefaultRequestHeaders.Add("Prediction-Key", "49096b646eab4c00b877e1c4431549b2");

            // Prediction URL - replace this example URL with your valid Prediction URL.
            string url = "https://eastus2.api.cognitive.microsoft.com/customvision/v3.0/Prediction/bc07bb8e-1bd6-4382-ac08-45a9cf351184/classify/iterations/Iteration12/image";

            // Request body. Try this sample with a locally stored image.
            byte[] byteData = FileHelpers.GetImageAsByteArray(imageFilePath);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return await client.PostAsync(url, content);

            }
        }


        public static void ProcessImages(List<string> files)
        {
            HttpResponseMessage response = null;
            foreach (var file in files)
            {
                Console.WriteLine($"Processing {file} ");
                response = ImagePrediction.MakePredictionRequestAsync(file.ToString()).Result;

                if (!(response.IsSuccessStatusCode)) { GenericUtilities.UserAlertMessage($"UserMessage.InvalidFileFormatErrMsg{file}"); Console.WriteLine("Error Response, File Not Processed"); }
                else
                {

                    Root predictionResults = GenericUtilities.Deserialize<Root>(response.Content.ReadAsStringAsync().Result.ToString());

                    Console.WriteLine($"Response:{response.Content.ReadAsStringAsync().Result.ToString()}");

                    predictionResults.predictions.ForEach(item => Predict(item.probability, item.tagName, file));

                    Console.WriteLine($"Please View the Output folder for Results.");
                }
            }
        }

        public static bool Predict(dynamic probability, string tagName, string sourcePath)
        {
            if (probability > 0.6)
            {
                FileHelpers.CopyFiles(sourcePath, tagName);
                return true;
            }
            return false;
        }
    }

    public class UserMessage
    {

        public static readonly string FileFormatMessage = "Currently we are supporting '.jpg' file format, all other formats will be excluded from processing.";

        public static readonly string InvalidFileFormatErrMsg = $"Invalid File Format Found";

    }
}
