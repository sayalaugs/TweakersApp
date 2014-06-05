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
            btnAddArticle.Visible = false;
            btnAddProduct.Visible = false;
            btnAddReview.Visible = false;

            if (Session["Soort"] != null)
            {
                string soort = Session["Soort"].ToString();

                if (soort == "Auteur")
                {
                    user = db.GetAuthorUser(Session["LogIn"].ToString());
                    lblInlogtext.Visible = true;
                    lblUser.Visible = true;
                    lblUser.Text = user.LoginName;
                    btnAddArticle.Visible = true;
                    btnAddProduct.Visible = true;
                    btnAddReview.Visible = true;

                }
                else if (soort == "Normaal")
                {
                    user = db.GetNormalUser(Session["LogIn"].ToString());
                    lblInlogtext.Visible = true;
                    lblUser.Visible = true;
                    lblUser.Text = user.LoginName;
                    btnAddReview.Visible = true;
                }
            }
            else
            {
                lblInlogtext.Text = "U bent niet ingelogd";
            }


            gvArticles.DataSource = db.DatatableArticles();
            gvArticles.DataBind();
            gvReviews.DataSource = db.DatatableReviews();
            gvReviews.DataBind();

        }


        protected void gvArticles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "GetArtID")
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = gvArticles.Rows[index];
                TableCell ID = selectedRow.Cells[1];
                string ArticleNr = ID.Text;
                int ArticleID = Convert.ToInt32(ArticleNr);

                Session["ArtId"] = ArticleID;
                Response.Redirect("~/ArticleInfo.aspx");
            }
        }

        protected void gvReviews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "GetRevID")
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = gvArticles.Rows[index];
                TableCell ID = selectedRow.Cells[1];
                string RevNr = ID.Text;
                int RevID = Convert.ToInt32(RevNr);

                Session["RevId"] = RevID;
                Response.Redirect("~/ReviewInfo.aspx");
            }

        }

        protected void btnAddArticle_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/AddArticle.aspx");
        }

        protected void btnAddReview_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/AddReview.aspx");
        }

        protected void btnAddProduct_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/AddProduct.aspx");

        }
    }
}