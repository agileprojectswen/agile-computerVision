using System.Windows;
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

        public static void UserAlertMessage(string userMsg)
        {

            //   MessageBox.Show("text", "title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }


}



