using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweakersApp
{
    public partial class AddReview : System.Web.UI.Page
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

        //ververst data op het scherm
        protected void refresh()
        {
            ddlReviewProducts.Items.Clear();

            foreach (Product p in ctrl.Products)
            {
                ddlReviewProducts.Items.Add(p.Name.ToString());
            }
        }

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