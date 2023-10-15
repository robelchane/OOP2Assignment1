using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_Assignment_1
{
    public class Refrigerator : Appliance
    {
        private string doors;
        private int height;
        private int width;


        public Refrigerator(long itemNumber, string brand, int quantity, int wattage, string color, double price, string doors, int height, int width) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Doors = doors;
            this.Height = height;
            this.Width = width;

        }

        public string Doors { get => doors; set => doors = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }

        public const string TwoDoors = "Two Doors";
        public const string ThreeDoors = "Three Doors";
        public const string FourDoors = "Four Doors";
        
        //A method that change the door output format for printing.
        public string FormatForDoor(string Doors)
        {
            if (Doors == "2") 
            {
                return TwoDoors;
            }
            else if (Doors == "3")
            {
                return ThreeDoors;
            }
            else
            {
                return FourDoors;
            }
        }

        //Method that change the list format for the text file.
        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{Doors};{Height};{Width};";
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"\nNumber of Doors: {FormatForDoor(Doors)}" +
                $"\nHeight: {Height}" +
                $"\nWidth: {Width}";
        }
    }
}
