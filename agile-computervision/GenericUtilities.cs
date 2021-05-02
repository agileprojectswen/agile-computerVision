using System.Windows;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System;

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

            // MessageBox.Show("text", "title");
        }

     
    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr h, string message, string title, int type);
}


}



