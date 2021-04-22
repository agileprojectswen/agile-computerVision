using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace agile_computervision
{
    public class Prediction
    {
        public static async Task<HttpResponseMessage> MakePredictionRequestAsync(string imageFilePath)
        {
            var client = new HttpClient();

            // Request headers - replace this example key with your valid Prediction-Key.
            client.DefaultRequestHeaders.Add("Prediction-Key", "49096b646eab4c00b877e1c4431549b2");

            // Prediction URL - replace this example URL with your valid Prediction URL.
            string url = "https://eastus2.api.cognitive.microsoft.com/customvision/v3.0/Prediction/bc07bb8e-1bd6-4382-ac08-45a9cf351184/classify/iterations/Iteration1/image";

            // Request body. Try this sample with a locally stored image.
            byte[] byteData = FileHelpers.GetImageAsByteArray(imageFilePath);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return await client.PostAsync(url, content);

            }
        }
    }
}
