using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services
{
    public class DescriptionBuilderService
    {
        // Construct-a-Croc
        // "It's Contstruct O'Clock!"
        public string Color { get; set; }
        public string Hobby { get; set; }
        public string Hat { get; set; } = "";
        public string Tail { get; set; } = "";
        public string HeldItem { get; set; } = "";

        public DescriptionBuilderService(string color, string hobby)
        {
            this.Color = color;
            this.Hobby = hobby;
        }

        public DescriptionBuilderService WithHat(string hat)
        {
            if (hat is null)
            {
                this.Hat = "";
                return this;
            }
            this.Hat = hat;
            return this;
        }

        public DescriptionBuilderService WithFancyTail(string tail)
        {
            if(tail is null)
            {
                this.Tail = "";
                return this;
            }
            this.Tail = tail;
            return this;
        }

        public DescriptionBuilderService WithHeldItem(string heldItem)
        {
            if (heldItem is null)
            {
                this.HeldItem = "";
                return this;
            }
            this.HeldItem = heldItem;
            return this;
        }

        public string Build()
        {
            string crocDescription = $"This Crocodile is {Color} and likes to {Hobby}.";
            string hat = Hat is "" ? "no hat." : $"a {Hat} hat.";
            string tail = Tail is "" ? Color : $"{Tail}";
            string heldItem = HeldItem is "" ? "" : $" They are holding a {HeldItem}";

            return crocDescription + $" They are wearing {hat}" + $" Their tail is {tail}." + $"{heldItem}.";
        }
    }
}
