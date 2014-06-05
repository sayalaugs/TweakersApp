using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweakersApp
{
    public partial class ReviewInfo : System.Web.UI.Page
    {
        DatabaseConnection db = new DatabaseConnection();
        Controller ctrl = new Controller();
        User user = null;
        Review review;
        int RevId;

        protected void Page_Load(object sender, EventArgs e)
        {
            RevId = Convert.ToInt32(Session["RevId"]);
            review = db.GetReview(Convert.ToInt32(Session["RevId"]));

            lblRevTitel.Text = review.Name;
            lblRating.Text = review.ProductRating.ToString();
            tbRevText.Text = review.Text;

            if (Session["Soort"] != null)
            {
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
            else
            {
                tbRevComment.Visible = false;
                btnAddComment.Visible = false;
                lblMessage.Visible = true;
            }

            gvComments.DataSource = db.DatatableRevComments(RevId);
            gvComments.DataBind();
        }

        protected void refresh()
        {
            gvComments.DataSource = db.DatatableRevComments(RevId);
            gvComments.DataBind();
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            string text = tbRevComment.Text;

            Comment comment = new Comment(1, user, DateTime.Now.ToShortDateString(), text);

            ctrl.AddRevComment(comment, review, user.ID);

            refresh();
        }

        protected void gvComments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Like")
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = gvComments.Rows[index];
                TableCell ID = selectedRow.Cells[2];
                string CommentNr = ID.Text;
                int CommentID = Convert.ToInt32(CommentNr);

                db.Like_RevComment(CommentID);
                refresh();
            }
            if (e.CommandName == "Dislike")
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = gvComments.Rows[index];
                TableCell ID = selectedRow.Cells[2];
                string CommentNr = ID.Text;
                int CommentID = Convert.ToInt32(CommentNr);

                db.Dislike_RevComment(CommentID);
                refresh();
            }
        }
    }
}