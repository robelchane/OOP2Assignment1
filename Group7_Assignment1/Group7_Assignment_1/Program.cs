using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

/*Assignment: Classes and Inheritance

Name: Kristiana Bautista, Robel Chane, Jericko Chavez, Shelyn del Mundo

Date: October 5, 2023

 

Program description: 

This program is for a local company, Modern Appliances to manage

their stocks by allowing the employees and customers to perform

buy, find and list appliances.

*/

namespace Group7_Assignment_1
{
    public class Program
    {
        static List<Appliance> appliances = new List<Appliance>();

        //A method that parses the appliances.txt file into a single list. 
        public static void LoadAppliancesListFromFile()
        {
            string path = @"..\..\Res\appliances.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                string ItemNumber = fields[0];
                string Brand = fields[1];
                string Quantity = fields[2];
                string Wattage = fields[3];
                string Color = fields[4];
                string Price = fields[5];

                if (fields[0].StartsWith("1"))
                {
                    string Doors = fields[6];
                    string Height = fields[7];
                    string Width = fields[8];

                    appliances.Add(new Refrigerator(long.Parse(ItemNumber), Brand, int.Parse(Quantity), int.Parse(Wattage), Color, double.Parse(Price), Doors, int.Parse(Height), int.Parse(Width)));
                }
                else if (fields[0].StartsWith("2"))
                {
                    string Grade = fields[6];
                    string BatteryVoltage = fields[7];

                    appliances.Add(new Vacuum(long.Parse(ItemNumber), Brand, int.Parse(Quantity), int.Parse(Wattage), Color, double.Parse(Price), Grade, BatteryVoltage));

                }
                else if (fields[0].StartsWith("3"))
                {
                    string Capacity = fields[6];
                    string RoomType = fields[7];

                    appliances.Add(new Microwave(long.Parse(ItemNumber), Brand, int.Parse(Quantity), int.Parse(Wattage), Color, double.Parse(Price), double.Parse(Capacity), RoomType));
                }
                else if (fields[0].StartsWith("4") || fields[0].StartsWith("5"))
                {
                    string Feature = fields[6];
                    string SoundRating = fields[7];

                    appliances.Add(new Dishwasher(long.Parse(ItemNumber), Brand, int.Parse(Quantity), int.Parse(Wattage), Color, double.Parse(Price), Feature, SoundRating));
                }

            }
        }


        //A method that allows a customer to purchase an appliance. 
        public static void Checkout()
        {
            Console.WriteLine("Enter the item number of an Appliance:");
            long userInputIN = long.Parse(Console.ReadLine());

            bool status = false;
            for (int i = 0; i < appliances.Count; i++)
            {
                Appliance a = appliances[i];
                if (a.ItemNumber == userInputIN)
                {
                    status = true;
                    if (a.Quantity > 0)
                    {
                        a.Quantity--;
                        Console.WriteLine("Appliance " + '"' + userInputIN + '"' + " has been checked out.");
                    }
                    else
                    {
                        Console.WriteLine("The appliance is not available to be checked out.");
                    }
                }
            }
            if (status == false)
            {
                Console.WriteLine("No appliances found with that item number.");
            }
        }

        //A method that prompts the customer to enter a brand
        //and prints out the appliances with the same brand.
        public static void FindApplianceByBrand()
        {
            Console.WriteLine("Enter brand to search for:");
            string userInputBrand = Console.ReadLine();
            
            bool status = false;
            Console.WriteLine("Matching Appliances:");
            for (int i = 0; i < appliances.Count; i++)
            {
                Appliance a = appliances[i];
                if (a.Brand.ToUpper() == userInputBrand.ToUpper())
                {
                    status = true;
                    Console.WriteLine(a);
                }
            }
            if (status == false)
            {
                Console.WriteLine("No appliances found with that brand");
            }
        }

        //A method that prompts the user to enter appliance type and features
        //and print the matching appliance based on the user input.
        public static void DisplayAppliancesType()
        {
            Console.WriteLine("Appliance Types" +
                "\n1 - Refrigerator" +
                "\n2 - Vacuums" +
                "\n3 - Microwave" +
                "\n4 - Dishwashers");


            
            Console.WriteLine("Enter type of appliance:");
            int userInputType = int.Parse(Console.ReadLine());

            if (userInputType == 1)
            {
                Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors): ");
                string numDoorsInput = Console.ReadLine();

                Console.WriteLine("\nMatching Refrigerators:");

                for (int i = 0;i < appliances.Count;i++)
                {
                    Appliance a = appliances[i];
                    if (a is Refrigerator)
                    {
                        Refrigerator f = (Refrigerator)a;
                        if (f.Doors == numDoorsInput)
                        {
                            Console.WriteLine(f);
                        }
                    }
                }
            }

            else if (userInputType == 2)
            {
                Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
                string voltageInput = Console.ReadLine();


                Console.WriteLine("\nMatching Vacuum:");
                for (int i = 0; i < appliances.Count;i++)
                {
                    Appliance a = appliances[i];
                    if (a is Vacuum)
                    {
                        Vacuum v = (Vacuum)a;
                        if (v.BatteryVoltage == voltageInput)
                        {
                            Console.WriteLine(v);
                        }
                    }
                }
            }

            else if (userInputType == 3)
            {
                Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
                string roomInput = Console.ReadLine();

                Console.WriteLine("\nMatching Microwave:");
                for (int i = 0; i < appliances.Count; i++)
                {
                    Appliance a = appliances[i];
                    if (a is Microwave)
                    {
                        Microwave m = (Microwave)a;
                        if (m.RoomType.ToUpper() == roomInput.ToUpper())
                        {
                            Console.WriteLine(m);
                        }
                    }
                }
            }

            else if (userInputType == 4)
            {
                Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                string roomInput = Console.ReadLine();

                Console.WriteLine("\nMatching Dishwasher:");
                for (int i = 0; i < appliances.Count; i++)
                {
                    Appliance a = appliances[i];
                    if (a is Dishwasher)
                    {
                        Dishwasher d = (Dishwasher)a;
                        if (d.SoundRating.ToUpper() == roomInput.ToUpper())
                        {
                            Console.WriteLine(d);
                        }
                    }
                }
            }
        }


        //A method that prompts a user to enter a number, and the program then displays
        //that number of random appliances. The appliances can be of any type. 
        public static void RandomAppliance()
        {
            Console.WriteLine("Enter number of appliance:");
            int numOfAppliances = int.Parse(Console.ReadLine());
            Random random = new Random();

            Console.WriteLine("\nRandom appliances:");
            for (int i = 0; i < numOfAppliances; i++)
            {
                int num = random.Next(0, appliances.Count - 1);

                Appliance a = (Appliance)appliances[num];
                Console.WriteLine(a);
            }

        }

        //A method that add the list of appliances back in the appliance.txt file.
        public static void AddToTextFile()
        {
            string path = @"..\..\Res\appliances.txt";
            string line = "";
            File.WriteAllText(path, string.Empty);

            foreach (Appliance a in appliances)
            {
                if (a is Refrigerator)
                {
                    Refrigerator fridge = (Refrigerator)a;
                    line = fridge.FormatForFile();
                    File.AppendAllText(path, line + "\n");
                }
                else if (a is Vacuum)
                {
                    Vacuum vac = (Vacuum)a;
                    line = vac.FormatForFile();
                    File.AppendAllText(path, line + "\n");
                }
                else if (a is Microwave)
                {
                    Microwave micro = (Microwave)a;
                    line = micro.FormatForFile();
                    File.AppendAllText(path, line + "\n");
                }
                else if (a is Dishwasher)
                {
                    Dishwasher dish = (Dishwasher)a;
                    line = dish.FormatForFile();
                    File.AppendAllText(path, line + "\n");
                }

            }
        }

        //Runs the main program
        static void Main(string[] args)
        {
            LoadAppliancesListFromFile();

            while (true)
            {
                Console.WriteLine("\n\nWelcome to Modern Appliances!" +
                    "\nHow may we assist you?" +
                    "\n1 - Check out appliance" +
                    "\n2 - Find appliances by brand" +
                    "\n3 - Display appliances by type" +
                    "\n4 - Produce a random appliance list" +
                    "\n5 - Save & exit\n");

                int option;

                while (true)
                {
                    Console.WriteLine("Enter option: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out option) && option >= 1 && option <= 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid option (1-5).");
                    }
                }

                switch (option)
                {
                    case 1:
                        Checkout();
                        break;
                    case 2:
                        FindApplianceByBrand();
                        break;
                    case 3:
                        DisplayAppliancesType();
                        break;
                    case 4:
                        RandomAppliance();
                        break;
                    case 5:
                        AddToTextFile();
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
