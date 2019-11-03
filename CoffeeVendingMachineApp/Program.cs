using System;
using CoffeeVendingMachineApp.ApplicationSettings;
using Newtonsoft.Json.Linq;
using CoffeeVendingMachineApp.CoffeeVendingMachineSetting;

namespace CoffeeVendingMachineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppSettings.LoadJson();
            while (true)
            {
                CoffeeVendingMachine.GetItem(1, 2);
                Console.WriteLine("Please select the item from list\nPLease let me know, which number of item would you like to have.");
                CoffeeVendingMachine.PrintCoffeeItems();
                int userInput = int.Parse(Console.ReadLine());
                if (userInput == 1 || userInput == 2 || userInput == 3 || userInput == 4)
                {
                    Console.WriteLine("Please enter the amount");
                    int amount = int.Parse(Console.ReadLine());
                    if(amount == 1 || amount == 5)
                    {
                        string output = CoffeeVendingMachine.GetItem(userInput, amount);
                        Console.WriteLine(output);
                    }
                    else
                    {
                        Console.WriteLine("Opps, wrong corrency! please frove eithr 1$ or 5$");
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
