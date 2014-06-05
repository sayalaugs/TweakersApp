using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweakersApp
{
    public partial class AddProduct : System.Web.UI.Page
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

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            string productName = tbProductNaam.Text;
            decimal productPrice = Convert.ToDecimal(tbProductPrice.Text);
            string releaseDate = Convert.ToString(CalReleaseDate.SelectedDate.ToShortDateString());

            Product product = new Product(1, productName, releaseDate, productPrice);

            if (ctrl.AddProduct(product))
            {
                lblMessage.Text = "het product is toegevoegd!";
            }
            else
            {
                lblMessage.Text = "foutje";
            }
        }
    }
}