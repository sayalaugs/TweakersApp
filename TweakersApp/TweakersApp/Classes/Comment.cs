using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweakersApp
{
    public class Comment
    {
        public int ID { get; private set; }
        public User User { get; private set; }
        public DateTime DateAdded { get; private set; }
        public string Text { get; private set; }
        public int Rating { get; private set; }

        public Comment(int ID, User User, DateTime DateAdded, string Text, int Rating)
        {
            this.ID = ID;
            this.User = User;
            this.DateAdded = DateAdded;
            this.Text = Text;
            this.Rating = Rating;
        }
    }
}