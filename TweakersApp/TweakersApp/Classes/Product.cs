using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweakersApp
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get;  set; }
        public string ReleaseDate { get;  set; }
        public decimal Price { get;  set; }

        public Product(int ID, string Name, string ReleaseDate, decimal Price)
        {
            this.ID = ID;
            this.Name = Name;
            this.ReleaseDate = ReleaseDate;
            this.Price = Price;
        }
    }
}