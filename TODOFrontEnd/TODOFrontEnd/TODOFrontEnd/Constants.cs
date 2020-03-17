using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TODOFrontEnd
{
    public static class Constants
    {
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "http://10.0.2.2:5000" : "https://10.0.2.2:5001";
        public static string TodoItemsUrl = BaseAddress + "/api/TODO/{0}";
    }
}
