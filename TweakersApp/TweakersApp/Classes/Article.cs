using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweakersApp
{
    public class Article
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Text { get; private set; }
        public AuthorUser Author { get; private set; }
        public string DateAdded { get; private set; }
        //lijst van comments

        public Article(int ID, string Name, string Text, AuthorUser Author, string DateAdded)
        {
            this.ID = ID;
            this.Name = Name;
            this.Text = Text;
            this.Author = Author;
            this.DateAdded = DateAdded;
        }
    }
}