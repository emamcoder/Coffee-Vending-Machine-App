using System;
using System.Collections.Generic;
using System.Text;
using CoffeeVendingMachineApp.ApplicationSettings;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace CoffeeVendingMachineApp.CoffeeVendingMachineSetting
{
    public class CoffeeVendingMachine
    {
        /// <summary>
        /// Array of integer for available change
        /// </summary>
        public static List<int> availableChange;

        /// <summary>
        /// Load the configuration details
        /// </summary>
        /// <returns></returns>
        private static JObject GetJSON()
        {
            return AppSettings.LoadJson();
        }

        /// <summary>
        /// Prind all the available item from config, on the console window
        /// </summary>
        public static void PrintCoffeeItems()
        {
            JObject config = AppSettings.LoadJson();
            JToken data = config.SelectToken("VendingMachineConfig.MenuOptions");
            int count = 1;
            foreach (JToken token in data.Children())
            {
                string[] token1 = token.ToString().Split(":");
                string item = token1[0].Substring(1, token1[0].Length - 2);
                Console.WriteLine($"{count++} {item} - {token1[1]}$");
            }
        }

        /// <summary>
        /// Get the requested item based on price and availability of change
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        /// <returns>string of item details</returns>
        public static string GetItem(int item, int amount)
        {
            JObject config = AppSettings.LoadJson();
            if (item == 1)
            {
                int lattePrice = int.Parse(config.SelectToken("VendingMachineConfig.MenuOptions.Latte").Value<string>());
                if (amount >= lattePrice & IsChangeAvailable(lattePrice, amount))
                {
                    Console.WriteLine($"Enjoy your Latte\nYour change {amount - lattePrice}");
                }
                else
                {
                    Console.WriteLine($"Please provide the amount  >= {lattePrice}");
                }
            }
            else if (item == 2)
            {
                int cappuinnoPrice = int.Parse(config.SelectToken("VendingMachineConfig.MenuOptions.Cappuinno").Value<string>());
                if (amount >= cappuinnoPrice & IsChangeAvailable(cappuinnoPrice, amount))
                {
                    Console.WriteLine($"Enjoy your Latte\nYour change {amount - cappuinnoPrice}");
                }
                else
                {
                    Console.WriteLine($"Please provide the amount  >= {cappuinnoPrice}");
                }

            }
            else if (item == 3)
            {
                int irishPrice = int.Parse(config.SelectToken("VendingMachineConfig.MenuOptions.Irish").Value<string>());
                if (amount >= irishPrice & IsChangeAvailable(irishPrice, amount))
                {
                    Console.WriteLine($"Enjoy your Latte\nYour change {amount - irishPrice}");
                }
                else
                {
                    Console.WriteLine($"Please provide the amount  >= {irishPrice}");
                }

            }
            else if (item == 4)
            {
                int expressoPrice = int.Parse(config.SelectToken("VendingMachineConfig.MenuOptions.Expresso").Value<string>());
                if (amount >= expressoPrice & IsChangeAvailable(expressoPrice, amount))
                {
                    Console.WriteLine($"Enjoy your Latte\nYour change {amount - expressoPrice}");
                }
                else
                {
                    Console.WriteLine($"Please provide the amount  >= {expressoPrice}");
                }
            }
            else
            {
                Console.WriteLine($"Sorry dont have sifficient change\nYour amount - {amount}");
            }
            return "";
        }

        /// <summary>
        /// Check the availability of change which need to return to the custommer
        /// </summary>
        /// <param name="price"></param>
        /// <param name="cost"></param>
        /// <returns>true/false</returns>
        private static bool IsChangeAvailable(int price, int cost)
        {
            int sum = 0;
            for (int i = 0; i < availableChange.Count(); i++)
            {
                if (sum + availableChange[i] <= (cost - price))
                {
                    sum = sum + availableChange[i];
                }
            }
            if (sum == (cost - price)) return true;
            return false;
        }

    }
}
