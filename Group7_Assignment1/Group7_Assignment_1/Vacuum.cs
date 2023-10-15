using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_Assignment_1
{
    public class Vacuum : Appliance
    {
        private string grade;
        private string batteryVoltage;

        public Vacuum(long itemNumber, string brand, int quantity, int wattage, string color, double price, string grade, string batteryVoltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Grade = grade;
            this.BatteryVoltage = batteryVoltage;
        }

        public string Grade { get => grade; set => grade = value; }
        public string BatteryVoltage { get => batteryVoltage; set => batteryVoltage = value; }


        //A method that change the vacuum output format for printing.
        public string FormatForVac(string BatteryVoltage)
        {
            if (BatteryVoltage == "18")
            {
                return "Low";
            }
            else
            {
                return "High";
            }
        }

        //Method that change the list format for the text file.
        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{Grade};{BatteryVoltage};";
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"\nGrade: {Grade}" +
                $"\nBattery Voltage: {FormatForVac(BatteryVoltage)}";
        }
    }


}
