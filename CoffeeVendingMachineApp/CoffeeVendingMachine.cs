using System;
using System.Collections.Generic;
using System.Text;
using CoffeeVendingMachineApp.ApplicationSettings;
using Newtonsoft.Json.Linq;

namespace CoffeeVendingMachineApp.CoffeeVendingMachineSetting
{
    public class CoffeeVendingMachine
    {
        private static JObject GetJSON()
        {
            return AppSettings.LoadJson();
        }

        public static void PrintCoffeeItems()
        {
            JObject config = AppSettings.LoadJson();
            JToken data = config.SelectToken("VendingMachineConfig.MenuOptions");
            int count = 1;
            foreach (JToken token in data.Children())
            {
                string[] token1 = token.ToString().Split(":");
                string item = token1[0].Substring(1, token1[0].Length - 2);
                Console.WriteLine($"{count++} {item}");
            }
        }

        public static string GetItem(int item, int amount)
        {
            JObject config = AppSettings.LoadJson();
            JToken data = config.SelectToken("VendingMachineConfig.AvailableChange");
            int availableChange =int.Parse( data.Value<string>());
            if (item == 1)
            {
                int lattePrice =int.Parse(config.SelectToken("VendingMachineConfig.MenuOptions.Latte").Value<string>());
                if (amount >= lattePrice & amount - lattePrice <= availableChange)
                {
                    Console.WriteLine($"Enjoy your Latte\nYour change {amount - lattePrice}");
                }
                else
                {
                    Console.WriteLine($"Sorry dont have sifficient change\nYour amount - {amount}");
                }
            }
            return "";
        }
    }

    public enum CoffeeMenu
    {
        Latte,
        Cappuinno,
        Irish,
        Expresso
    }

    public enum Amount
    {
        ONE = 1,
        FIVE = 5
    }
}
