using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data.OleDb;
using System.Data;

namespace TweakersApp
{
    public class DatabaseConnection
    {

        public OracleConnection conn;
        string pcn = "system";
        string pw = "22522842";
        private int UserIdIn;
        private int ProductIdIn;
        private int ArticleIdIn;
        private int ReviewIdIn;

        // the constructor in which the connectionstring is set
        public DatabaseConnection()
        {
            conn = new OracleConnection();
        
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + " //localhost/" + ";";
        }
   


        public User Login(string accountname, string password)
        {
            String cmd = "Select UserID, LoginName, Naam, Birthday, Gender, Email, Soort From Gebruiker Where LoginName = '" + accountname + "' AND LoginPass = '" + password + "'";

            //String cmd = "Select ac.Accountnaam, ac.UserID_acc, us.Naam, us.Email From ACCOUNT_ ac, User_ us Where ac.ACCOUNTNAAM = '" + accountname + "' AND ac.WACHTWOORD = '" + password + "'" + "AND ac.USERID_ACC = us.USERID ";
            OracleCommand command = new OracleCommand(cmd, conn);
            command.CommandType = System.Data.CommandType.Text;

            try
            {
                conn.Open();
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                int UserID = Convert.ToInt32(reader["UserID"].ToString());
                string LoginName = reader["LoginName"].ToString();
                string name = reader["Naam"].ToString();
                string Birthday = reader["Birthday"].ToString();
                string Gender = reader["Gender"].ToString();
                string Email = reader["Email"].ToString();
                string Soort = reader["Soort"].ToString();

                User login = new User(UserID, name, Birthday, Email, LoginName, Gender, Soort);

                login.LoginName = accountname;

                return login;
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public bool AddUser(User user, string password)
        {
            UserIdIn = GetInsertID("UserID", "GEBRUIKER");
            UserIdIn++;
            int amountofcomments = 0;
            int amountofarticles = 0;
            string sql1 = "INSERT INTO GEBRUIKER (UserID, LoginName, LoginPass, Naam, Birthday, Gender, Email, Soort) Values ( :UserID, :LoginName, :LoginPass, :Naam, :Birthday, :Gender, :Email, :Soort)";
            string sql2 = "INSERT INTO NORMAAL (UserID, AmountOfComments) Values (:UserID, :amountofcomments )";
            string sql3 = "INSERT INTO AUTHOR (UserID, AddedArticles) Values (:UserID, :amountofarticles )"; 

            OracleCommand command1 = new OracleCommand(sql1, conn);
            OracleCommand command2 = new OracleCommand(sql2, conn);
            OracleCommand command3 = new OracleCommand(sql3, conn);

            command1.Parameters.Add(":UserID", UserIdIn);
            command1.Parameters.Add(":LoginName", user.LoginName);
            command1.Parameters.Add(":LoginPasse", password);
            command1.Parameters.Add(":Naam", user.UserName);
            command1.Parameters.Add(":Birthday", user.Birthday);
            command1.Parameters.Add(":Gender", user.gender);
            command1.Parameters.Add(":Email", user.Email);
            command1.Parameters.Add(":Soort", user.soort);

            command2.Parameters.Add(":UserID", UserIdIn);
            command2.Parameters.Add(":amountofcomments", amountofcomments);

            command3.Parameters.Add(":UserID", UserIdIn);
            command3.Parameters.Add(":amountofarticles", amountofarticles);


            try
            {
                conn.Open();
                command1.ExecuteNonQuery();

                if (user.soort == "Normaal")
                {
                    command2.ExecuteNonQuery();

                        return true;
                }
                else if (user.soort == "Auteur")
                {
                    command3.ExecuteNonQuery();

                        return true;
                }
                
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool AddProduct(Product product)
        {
            ProductIdIn = GetInsertID("ProductID", "PRODUCT");
            ProductIdIn++;
            string sql = "INSERT INTO PRODUCT (ProductID, Naam, ReleaseDate, Price) Values ( :ProductID, :Naam, :ReleaseDate, :Price)";

            OracleCommand command = new OracleCommand(sql, conn);

            command.Parameters.Add(":ProductID", ProductIdIn);
            command.Parameters.Add(":Naam", product.Name);
            command.Parameters.Add(":ReleaseDate", product.ReleaseDate);
            command.Parameters.Add(":Price", product.Price);


            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool AddArticle(Article article, AuthorUser author)
        {
            ArticleIdIn = GetInsertID("ArticleID", "ARTICLE");
            ArticleIdIn++;
            string sql = "INSERT INTO ARTICLE  (ArticleID, Naam, Text, Author, DateAdded) Values ( :ArticleID, :Naam, :Text, '" + author + "' , :DateAdded)";

            OracleCommand command = new OracleCommand(sql, conn);

            command.Parameters.Add(":ArticleID", ArticleIdIn);
            command.Parameters.Add(":Naam", article.Name);
            command.Parameters.Add(":Text", article.Text);
            //command.Parameters.Add(":Author", author);
            command.Parameters.Add(":DateAdded", article.DateAdded);


            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool AddReview(Review review)
        {
            ReviewIdIn = GetInsertID("ReviewID", "REVIEW");
            ReviewIdIn++;
            //Product product = GetProduct(review.Product.Name);
            //User user = GetUser(review.User.Name);

            string sql = "INSERT INTO REVIEW  (ReviewID, ProductID, UserID, Naam, ReviewText, ProductRating) Values ( :ReviewID, :ProductID, :UserID, :Naam, :ReviewText, :ProductRating)";

            OracleCommand command = new OracleCommand(sql, conn);

            command.Parameters.Add(":ReviewID", ReviewIdIn);
            command.Parameters.Add(":ProductID", review.Product.ID);
            command.Parameters.Add(":UserID", review.User.ID);
            command.Parameters.Add(":Naam", review.Name);
            command.Parameters.Add(":ReviewText", review.Text);
            command.Parameters.Add(":ProductRating", review.ProductRating);


            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        private int GetInsertID(string ID, string tabelnaam)
        {
            string insertID = "Select Max(" + ID + ") From " + tabelnaam;

            OracleCommand commandID = new OracleCommand(insertID, conn);
            commandID.CommandType = System.Data.CommandType.Text;

            try
            {
                conn.Open();
                OracleDataReader readerMat = commandID.ExecuteReader();
                readerMat.Read();
                int id = readerMat.GetInt32(0);
                return id;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }

        }

        public User GetUser(int ID)
        {
            String cmd = "Select Soort, LoginName from GEBRUKER Where UserID = :ID";
            OracleCommand command = new OracleCommand(cmd, conn);
            command.CommandType = System.Data.CommandType.Text;

            command.Parameters.Add(":ID", ID);

            try
            {
                conn.Open();
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();

                string Soort = reader["Soort"].ToString();
                string LoginName = reader["LoginName"].ToString();


                if (Soort == "Auteur")
                {
                    User user = GetAuthorUser(LoginName);

                    return user;
                }
                else if(Soort == "Normaal")
                {
                    User user = GetNormalUser(LoginName);

                    return user;
                }

            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public User GetAuthorUser(string accountname)
        {
            String cmd = "Select g.UserID, g.LoginName, g.Naam, g.Birthday, g.Gender, g.Email, g.Soort, au.AddedArticles From GEBRUIKER g, AUTHOR au Where g.LoginName = :LoginName and au.UserID = g.UserID";
            OracleCommand command = new OracleCommand(cmd, conn);
            command.CommandType = System.Data.CommandType.Text;

            command.Parameters.Add(":LoginName", accountname);

            try
            {
                conn.Open();
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                int UserID = Convert.ToInt32(reader["UserID"]);
                string LoginName = reader["LoginName"].ToString();
                string name = reader["Naam"].ToString();
                string Birthday = reader["Birthday"].ToString();
                string Gender = reader["Gender"].ToString();
                string Email = reader["Email"].ToString();
                string Soort = reader["Soort"].ToString();
                int amountofarticles = Convert.ToInt32(reader["AddedArticles"]);

                User user = new AuthorUser(UserID, name, Birthday, Email, LoginName, Gender, Soort, amountofarticles);
                user.LoginName = accountname;
                return user;

            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public User GetNormalUser(string accountname)
        {
            String cmd = "Select g.UserID, g.LoginName, g.Naam, g.Birthday, g.Gender, g.Email, g.Soort , n.AmountOfComments From GEBRUIKER g, NORMAAL n Where g.LoginName = :LoginName and n.UserID = g.UserID";
            OracleCommand command = new OracleCommand(cmd, conn);
            command.CommandType = System.Data.CommandType.Text;

            command.Parameters.Add(":LoginName", accountname);

            try
            {
                conn.Open();
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                int UserID = Convert.ToInt32(reader["UserID"]);
                string LoginName = reader["LoginName"].ToString();
                string name = reader["Naam"].ToString();
                string Birthday = reader["Birthday"].ToString();
                string Gender = reader["Gender"].ToString();
                string Email = reader["Email"].ToString();
                string Soort = reader["Soort"].ToString();
                int amountofcomments = Convert.ToInt32(reader["AmountOfComments"]);

                User user = new NormalUser(UserID, name, Birthday, Email, LoginName, Gender, Soort, amountofcomments);
                user.LoginName = accountname;
                return user;


            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public Product GetProduct(string productname)
        {
            String cmd = "Select * from PRODUCT where Naam = :ProductName";
            OracleCommand command = new OracleCommand(cmd, conn);
            command.CommandType = System.Data.CommandType.Text;

            command.Parameters.Add(":ProductName", productname);

            try
            {
                conn.Open();
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                int ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                string Naam = reader["Naam"].ToString();
                string ReleaseDate = reader["ReleaseDate"].ToString();
                decimal Price = Convert.ToDecimal(reader["Price"]);

                Product product = new Product(ProductID, Naam, ReleaseDate, Price);
                product.Name = productname;

                return product;

            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public Product GetProduct(int ID)
        {
            String cmd = "Select * from PRODUCT where ProductID = :ID";
            OracleCommand command = new OracleCommand(cmd, conn);
            command.CommandType = System.Data.CommandType.Text;

            command.Parameters.Add(":ID", ID);

            try
            {
                conn.Open();
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                int ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                string Naam = reader["Naam"].ToString();
                string ReleaseDate = reader["ReleaseDate"].ToString();
                decimal Price = Convert.ToDecimal(reader["Price"]);

                Product product = new Product(ProductID, Naam, ReleaseDate, Price);
                product.ID = ProductID;

                return product;

            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public DataTable DataTable()
        {

            DataSet dataSet = new DataSet();
            DataTable dt = null;

            string sql = "Select * from GEBRUIKER";


            try
            {
                conn.Open();

                OracleDataAdapter adapter = new OracleDataAdapter();
                OracleCommand command = new OracleCommand(sql, conn);
                command.CommandText = sql;
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
                dt = dataSet.Tables[0];
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public List<Article> GetAllArticles()
        {
            string sql = "Select * FROM Article";
            OracleCommand command = new OracleCommand(sql, conn);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                conn.Open();
                List<Article> databaseArticles = new List<Article>();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ArticleID = reader.GetInt32(0);
                    string Naam = reader["Naam"].ToString();
                    string Text = reader["Text"].ToString();
                    string Authorname = reader["Author"].ToString();
                    string Date = reader["DateAdded"].ToString();



                    User user = GetAuthorUser(Authorname);
                    AuthorUser author = user as AuthorUser; //dit werkt zolang author naam uniek is, beter author enkel als naam string meegeven aan article?
                    Article article = new Article(ArticleID, Naam, Text, author, Date);
                    databaseArticles.Add(article);
                }
                return databaseArticles;
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public List<Product> GetAllProducts()
        {
            string sql = "Select * FROM Product";
            OracleCommand command = new OracleCommand(sql, conn);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                conn.Open();
                List<Product> databaseProducts = new List<Product>();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ProductID = reader.GetInt32(0);
                    string Naam = reader["Naam"].ToString();
                    string ReleaseDate = reader["ReleaseDate"].ToString();
                    decimal Price = Convert.ToDecimal(reader["Price"]);

                    Product product = new Product(ProductID, Naam, ReleaseDate, Price);
                    databaseProducts.Add(product);
                }
                return databaseProducts;
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public List<Review> GetAllReviews()
        {
            string sql = "Select * FROM Review";
            OracleCommand command = new OracleCommand(sql, conn);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                conn.Open();
                List<Review> databaseReviews = new List<Review>();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ReviewID = reader.GetInt32(0);
                    int ProductID = Convert.ToInt32(reader["ProductID"]);
                    int UserID = Convert.ToInt32(reader["UserID"]);
                    int ProductRating = Convert.ToInt32(reader["ProductRating"]);
                    string Naam = reader["Naam"].ToString();
                    string ReviewText = reader["ReviewText"].ToString();

                    User user = GetUser(UserID);
                    Product product = GetProduct(ProductID);

                    Review review = new Review(ReviewID, Naam, ReviewText, ProductRating, user, product);
                    databaseReviews.Add(review);
                }
                return databaseReviews;
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
    }          
}