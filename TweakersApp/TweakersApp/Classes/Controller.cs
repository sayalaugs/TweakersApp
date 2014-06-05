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

        //voegt product toe, ook db toevoeging doen
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
    }
}