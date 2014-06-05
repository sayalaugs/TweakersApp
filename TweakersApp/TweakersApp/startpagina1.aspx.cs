using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TweakersApp
{
    public partial class startpagina1 : System.Web.UI.Page
    {
        DatabaseConnection db = new DatabaseConnection();
        Controller ctrl = new Controller();
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            ctrl.Articles = db.GetAllArticles();
            ctrl.Products = db.GetAllProducts();
            ctrl.Reviews = db.GetAllReviews();

            gvComments.DataSource = db.DataTable();
            gvComments.DataBind();


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


            //wanneer de user een auteur is, worden ook de artikel mogelijkheden weergegeven
            if (user is AuthorUser)
            {
                pnlArtikelPlaatsen.Visible = true;
                lblArtikel.Visible = true;
            }

            refresh();
        }

        //ververst data op het scherm
        protected void refresh()
        {
            ddlArtikelProducts.Items.Clear();
            ddlReviewProducts.Items.Clear();

            foreach (Product p in ctrl.Products)
            {
                ddlArtikelProducts.Items.Add(p.Name.ToString());
                ddlReviewProducts.Items.Add(p.Name.ToString());
            }
        }

        //voegt een product toe
        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            string productName = tbProductNaam.Text;
            decimal productPrice = Convert.ToDecimal(tbProductPrice.Text);
            string releaseDate = Convert.ToString(CalReleaseDate.SelectedDate.ToShortDateString());

            Product product = new Product(1, productName, releaseDate, productPrice);

            ctrl.AddProduct(product);


            refresh();

        }

        //plaatst een artikel
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

        //voegt review toe
        protected void btnReview_Click(object sender, EventArgs e)
        {
            string titel = tbReviewTitel.Text;
            string productname = ddlReviewProducts.SelectedValue.ToString(); // product moet object worden, niet alleen string
            Product product = db.GetProduct(productname);
            string text = tbReviewText.Text;
            int reviewrating = 0;
            
            if (rbOne.Checked)
            {
                reviewrating = 1;

                rbTwo.Checked = false;
                rbThree.Checked = false;
                rbFour.Checked = false;
                rbFive.Checked = false;
            }
            if (rbTwo.Checked)
            {
                reviewrating = 2;

                rbOne.Checked = false;
                rbThree.Checked = false;
                rbFour.Checked = false;
                rbFive.Checked = false;
            }
            if (rbThree.Checked)
            {
                reviewrating = 3;

                rbOne.Checked = false;
                rbTwo.Checked = false;
                rbFour.Checked = false;
                rbFive.Checked = false;
            }
            if (rbFour.Checked)
            {
                reviewrating = 4;

                rbOne.Checked = false;
                rbTwo.Checked = false;
                rbThree.Checked = false;
                rbFive.Checked = false;
            }
            if (rbFive.Checked)
            {
                reviewrating = 5;

                rbOne.Checked = false;
                rbTwo.Checked = false;
                rbThree.Checked = false;
                rbFour.Checked = false;
            }
            
            Review review = new Review(1, titel, text, reviewrating, user, product);

            ctrl.AddReview(review);
        }
    }
}