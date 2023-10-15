using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_Assignment_1
{
    public abstract class Appliance
    {
        private long itemNumber;
        private string brand;
        private int quantity;
        private int wattage;
        private string color;
        private double price;

        protected Appliance(long itemNumber, string brand, int quantity, int wattage, string color, double price)
        {
            this.ItemNumber = itemNumber;
            this.Brand = brand;
            this.Quantity = quantity;
            this.Wattage = wattage;
            this.Color = color;
            this.Price = price;
        }

        public long ItemNumber { get => itemNumber; set => itemNumber = value; }
        public string Brand { get => brand; set => brand = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Wattage { get => wattage; set => wattage = value; }
        public string Color { get => color; set => color = value; }
        public double Price { get => price; set => price = value; }


        //Method that change the list format for the text file.
        public virtual string FormatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price}";
        }

        public override string ToString()
        {
            return $"\nItemNumber: {ItemNumber}" +
                $"\nBrand: {Brand}" +
                $"\nQuantity: {Quantity}" +
                $"\nWattage: {Wattage}" +
                $"\nColor: {Color}" +
                $"\nPrice: {Price}";
        }
    }
}
