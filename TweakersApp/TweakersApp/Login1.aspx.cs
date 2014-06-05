using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweakersApp
{
    public partial class Login1 : System.Web.UI.Page
    {
        DatabaseConnection db = new DatabaseConnection();
        Controller ctrl = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            refresh();          
        }

        //ververst data op de pagina
        protected void refresh()
        {
        }

        //login methode
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            User loggedIn = db.Login(username, password);

            if (loggedIn != null)
            {
                Session["LogIn"] = loggedIn.LoginName;
                Session["Soort"] = loggedIn.soort;
                Response.Cookies["LoginName"].Value = loggedIn.LoginName;
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                lblMessageLogin.Text = "incorrecte gegevens, probeer het nog eens";
            }

        }

        //gebruiker registreren
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string loginname = tbRegUserLogin.Text;
            string password = tbRegUserPassword.Text;
            string name = tbRegName.Text;
            string birthdate = calRegBirthday.SelectedDate.ToString();
            string email = tbRegEmail.Text;
            string gender = ddlRegGender.SelectedValue.ToString();
            string soort = ddlRegType.SelectedValue.ToString(); //int a = "werkt niet meer? wisselt automatisch naar normaal";

            if (soort == "Auteur")
            {
                User user = new AuthorUser(1, name, birthdate, email, loginname, gender, soort, 0);
                if (ctrl.AddUser(user, password))
                {
                    lblMessageRegister.Text = "Registreren is gelukt!";
                }
                else
                {
                    lblMessageRegister.Text = "er is iets fout gegaan, probeer het nog eens";
                }

            }
            else if (soort == "Normaal")
            {
                User user = new NormalUser(1, name, birthdate, email, loginname, gender, soort, 0);
                ctrl.AddUser(user, password);
            }
        }
    }
}