using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_Assignment_1
{
    public class Microwave : Appliance
    {
        private double capacity;
        private string roomType;


        public Microwave(long itemNumber, string brand, int quantity, int wattage, string color, double price, double capacity, string roomType) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.RoomType = roomType;
            this.Capacity = capacity;
        }

        public double Capacity { get => capacity; set => capacity = value; }
        public string RoomType { get => roomType; set => roomType = value; }

        public const string RoomTypeKitchen = "Kitchen";
        public const string RoomTypeWorkSite = "Work Site";

        //A method that change the microwave output format for printing.
        public string FormatForMicro(string RoomType)
        {
            if (RoomType == "K")
            {
                return RoomTypeKitchen;
            }
            else
            {
                return RoomTypeWorkSite;
            }
        }

        //Method that change the list format for the text file.
        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{Capacity};{RoomType};";
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"\nCapacity: {Capacity}" +
                $"\nRoom Type: {FormatForMicro(RoomType)}";
        }
    }
}
