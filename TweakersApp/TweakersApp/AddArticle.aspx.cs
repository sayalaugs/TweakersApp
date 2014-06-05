using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweakersApp
{
    public partial class AddArticle : System.Web.UI.Page
    {
        DatabaseConnection db = new DatabaseConnection();
        Controller ctrl = new Controller();
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            ctrl.Products = db.GetAllProducts();

            //haalt info op van ingelogde user
            string soort = Session["Soort"].ToString();
            if (soort == "Auteur")
            {
                user = db.GetAuthorUser(Session["LogIn"].ToString());
            }
            else if (soort == "Normaal")
            {
                user = db.GetNormalUser(Session["LogIn"].ToString());
            }

            refresh();
        }

        protected void refresh()
        {
            ddlArtikelProducts.Items.Clear();

            foreach (Product p in ctrl.Products)
            {
                ddlArtikelProducts.Items.Add(p.Name.ToString());
            }
        }

        protected void btnPlaceArticle_Click(object sender, EventArgs e)
        {
            string titel = tbArticleTitel.Text;
            string text = tbArticleText.Text;
            string product = ddlArtikelProducts.SelectedValue.ToString(); //product hoort bij artikel, en moet object zijn, niet string

            //als user een author is, wordt deze ook als author gecast en meegegeven aan het artikel.
            if (user is AuthorUser)
            {
                AuthorUser author = user as AuthorUser;
                Article article = new Article(1, titel, text, author, DateTime.Now.ToShortDateString());
                lblMessage.Text = "het plaatsen van het artikel is gelukt";

                ctrl.AddArticle(article, author);
            }
            else
            {
                lblMessage.Text = "Alleen een auteur kan artikelen plaatsen";
            }
        }
    }
}