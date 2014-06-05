using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweakersApp
{
    public class Controller
    {
        DatabaseConnection db = new DatabaseConnection();

        private List<User> users = new List<User>();
        private List<Product> products = new List<Product>();
        private List<Review> reviews = new List<Review>();
        private List<Article> articles = new List<Article>();

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public List<Review> Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }

        public List<Article> Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        //voegt comment toe aan list en aan database
        public void AddArtComment(Comment comment, Article article, int UserId)
        {
            article.Comments.Add(comment);
            db.AddArtComment(comment, article, UserId);
        }

        //voegt comment toe aan list en aan database
        public void AddRevComment(Comment comment, Review review, int UserId)
        {
            review.Comments.Add(comment);
            db.AddRevComment(comment, review, UserId);
        }

        //voegt product toe
        public bool AddProduct(Product product)
        {
            foreach(Product p in products)
                if (p.Name == product.Name)
                {
                    return false;
                }
                else
                {
                    products.Add(product);
                    db.AddProduct(product);
                    return true;
                }
            products.Add(product);
            db.AddProduct(product);
            return true;
        }

        //voegt gebruiker toe
        public bool AddUser(User user, string password)
        {
            foreach (User u in users)
            {
                if (user.LoginName == u.LoginName)
                {
                    return false;
                }
                users.Add(user);
                db.AddUser(user, password);

                return true;
            }
            users.Add(user);
            db.AddUser(user, password);
            return true;
        }

        //voegt review toe aan lijst van reviews, ook db functie toevoegen
        public bool AddReview(Review review)
        {
            reviews.Add(review);
            db.AddReview(review);
            return true;
        }

        //voegt artikel toe aan lijst van artikelen, ook db functie toevoegen
        public bool AddArticle(Article article, AuthorUser author)
        {
            articles.Add(article);
            db.AddArticle(article, author);
            return true;
        }

        public void LikeComment(Article article, Comment comment)
        {
            foreach (Comment c in article.Comments)
            {
                if (c.ID == comment.ID)
                {
                    c.AmountOfLikes++;
                    db.Like_ArtComment(c.ID);
                }
            }
        }

        public void LikeComment(Review review, Comment comment)
        {
            foreach (Comment c in review.Comments)
            {
                if (c.ID == comment.ID)
                {
                    c.AmountOfLikes++;
                    db.Like_RevComment(c.ID);
                }
            }
        }

        public void DisikeComment(Article article, Comment comment)
        {
            foreach (Comment c in article.Comments)
            {
                if (c.ID == comment.ID)
                {
                    c.AmountOfLikes++;
                    db.Dislike_ArtComment(c.ID);
                }
            }
        }

        public void DisikeComment(Review review, Comment comment)
        {
            foreach (Comment c in review.Comments)
            {
                if (c.ID == comment.ID)
                {
                    c.AmountOfLikes++;
                    db.Dislike_RevComment(c.ID);
                }
            }
        }
    }
}