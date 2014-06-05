using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweakersApp
{
    public class AuthorUser : User
    {
        public int AmountOfArticles { get; private set; }

        public AuthorUser(int ID, string UserName, string Birtday, string Email, string LoginName, string gender, string soort, int AmountOfArticles)
            : base(ID, UserName, Birtday, Email, LoginName, gender, soort)
        {
            this.AmountOfArticles = AmountOfArticles;
        }
    }
}