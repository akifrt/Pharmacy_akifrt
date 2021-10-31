using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class Drug
    {
        public string Name { get; }
        private int ID { get; set; }
        public DrugType Type { get; set; }
        public double Price { get; set; }

        public int Count { get; set; }
        public Drug(string name, DrugType type, int count, int price)
        {
            Name = name;
            Type = type;
            Count = count;
            Price = price;
            ID++;
        }

        public override string ToString()
        {
            return $"Drug name = {this.Name}, Drug type = {this.Type}, Drug id = {this.ID}, Drug Price = {this.Price}, Drug Count = {this.Count}";
        }
    }
}
