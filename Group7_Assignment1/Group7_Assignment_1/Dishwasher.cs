using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_Assignment_1
{
    public class Dishwasher : Appliance
    {
        private string feature;
        private string soundRating;

        public Dishwasher(long itemNumber, string brand, int quantity, int wattage, string color, double price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Feature = feature;
            this.SoundRating = soundRating;
        }

        public string Feature { get => feature; set => feature = value; }
        public string SoundRating { get => soundRating; set => soundRating = value; }


        public const string SoundRatingModerate = "Moderate";
        public const string SoundRatingQuiet = "Quiet";
        public const string SoundRatingQuieter = "Quieter";
        public const string SoundRatingQuietest = "Quietest";


        //A method that change the dishwasher output format for printing.
        public string FormatForDish(string SoundRating)
        {
            if (SoundRating == "Qt")
            {
                return SoundRatingQuietest;
            }
            else if (SoundRating == "Qr")
            {
                return SoundRatingQuieter;
            }
            else if (SoundRating == "Qu")
            {
                return SoundRatingQuiet;
            }
            else
            {
                return SoundRatingModerate;
            }
        }

        //Method that change the list format for the text file.
        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{Feature};{SoundRating};";
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"\nFeature: {Feature}" +
                $"\nSoundRating: {FormatForDish(SoundRating)}";
        }
    }
}
