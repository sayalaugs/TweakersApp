using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweakersApp
{
    public class Review
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Text { get; private set; }
        public int ProductRating { get; private set; }
        public User User { get; private set; }
        public Product Product { get; private set; }
        //lijst van comments waarschijnlijk

        public Review(int ID, string Name, string Text, int ProductRating, User User, Product Product)
        {
            this.ID = ID;
            this.Name = Name;
            this.Text = Text;
            this.ProductRating = ProductRating;
            this.User = User;
            this.Product = Product;
        }
    }
}