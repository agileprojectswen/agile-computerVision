using Newtonsoft.Json;
namespace agile_computervision
{
    public class GenericUtilities
    {
        /*Generic Deserilization*/
        public static T Deserialize<T>(string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}



