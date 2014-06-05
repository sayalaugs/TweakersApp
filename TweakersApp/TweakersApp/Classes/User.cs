using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweakersApp
{
    //enum aanmaken voor gender
    public class User
    {
        public enum Gender
        {
            M,
            V,
        }

        public int ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; private set; }
        public string Birthday { get; private set; }
        public string Email { get; private set; }
        public string LoginName { get; set; }
        public string gender { get; private set; }
        public string soort { get; private set; }

        private List<Comment> comments = new List<Comment>();

        public List<Comment> Comments { get { return comments; } }

        public User(int ID, string UserName, string Birthday, string Email, string LoginName, string gender, string soort)
        {
            this.ID = ID;
            this.UserName = UserName;
            this.Name = Name;
            this.Birthday = Birthday;
            this.Email = Email;
            this.LoginName = LoginName;
            this.gender = gender;
            this.soort = soort;
        }
    }
}