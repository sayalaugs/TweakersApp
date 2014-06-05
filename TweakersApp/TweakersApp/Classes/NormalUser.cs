using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweakersApp
{
    public class NormalUser : User
    {
        public int AmountOfComments { get; private set; }

        public NormalUser(int ID, string UserName, string Birtday, string Email, string LoginName, string gender, string soort, int AmountOfComments)
            : base(ID, UserName, Birtday, Email, LoginName, gender, soort)
        {
            this.AmountOfComments = AmountOfComments;
        }
    }
}