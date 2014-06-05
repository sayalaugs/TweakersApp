using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweakersApp
{
    public class Comment
    {
        public int ID { get; set; }
        public User User { get; private set; }
        public string DateAdded { get; private set; }
        public string Text { get; private set; }
        public int AmountOfLikes { get;  set; }
        public int AmountOfDislikes { get;  set; }

        public Comment(int ID, User User, string DateAdded, string Text)
        {
            this.ID = ID;
            this.User = User;
            this.DateAdded = DateAdded;
            this.Text = Text;
            this.AmountOfDislikes = 0;
            this.AmountOfLikes = 0;

        }
    }
}