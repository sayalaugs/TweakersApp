using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TweakersApp
{
    public partial class Home : System.Web.UI.Page
    {
        DatabaseConnection db = new DatabaseConnection();
        Controller ctrl = new Controller();
        User user = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Visible = false;
            lblInlogtext.Visible = false;

            if (Session["Soort"] != null)
            {
                string soort = Session["Soort"].ToString();

                if (soort == "Auteur")
                {
                    user = db.GetAuthorUser(Session["LogIn"].ToString());
                    lblInlogtext.Visible = true;
                    lblUser.Visible = true;
                    lblUser.Text = user.LoginName;

                }
                else if (soort == "Normaal")
                {
                    user = db.GetNormalUser(Session["LogIn"].ToString());
                    lblInlogtext.Visible = true;
                    lblUser.Visible = true;
                    lblUser.Text = user.LoginName;
                }
            }

            if (user is AuthorUser)
            {
                //pnlArtikelPlaatsen.Visible = true;
                //lblArtikel.Visible = true;
            }


            gvArticles.DataSource = db.DatatableArticles();
            gvArticles.DataBind();

        }
    }
}