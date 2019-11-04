using CoffeeVendingMachineApp.CoffeeVendingMachineSetting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoffeeVendingMachineApp.ApplicationSettings
{
    public class AppSettings
    {
        private string jsonString = String.Empty;
        private static JObject jsonData;
        private static AppSettings _app = new AppSettings();
        private AppSettings()
        {
            jsonString = File.ReadAllText("C:\\Users\\emamc\\source\\repos\\CoffeeVendingMachineApp\\AppSetting.json");
            jsonData = JObject.Parse(jsonString);
            JToken data = jsonData.SelectToken("VendingMachineConfig.AvailableChange");
            CoffeeVendingMachine.availableChange = new List<int>();
            for(int i=0; i< int.Parse(data.Value<string>()); i++)
            {
                CoffeeVendingMachine.availableChange.Add(i);
            }
        }

        /// <summary>
        /// Loding the configuration
        /// </summary>
        /// <returns>JSON object</returns>
        public static JObject LoadJson()
        {
            return jsonData;
        }
    }
}
