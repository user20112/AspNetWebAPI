using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;


using Model;
using configFile;

namespace Repository
{

    public class titleRepository : IRepository<Title>
    {
        private string _connectionString;

        public titleRepository()
        {
            _connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";
        }

        public Title IRepositoryFindByID(string Book)
        {

            Title book = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM titles WHERE title_id = @id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id", Book));

                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {
                                string _pubid = "";
                                string _pub = "";
                                string _state = "";
                                string _country = "";
                                string _city = "";
                                string _titleid = "";
                                string _title = "";
                                string _type = "";
                                Decimal? _price = null;
                                DateTime? _pubdate = null;
                                Publisher _publisher;
                                Decimal? _advance = null;
                                int? _royalty = null;
                                int? _tyd_sales = null;
                                string _notes = "";
                                for (int x = 0; x < 14; x++)
                                {

                                    if (!dataReader.IsDBNull(x))
                                    {
                                        switch (x)
                                        {

                                            case 0: //title id
                                                _titleid = dataReader[x].ToString();

                                                break;
                                            case 1: //title
                                                _title = dataReader[x].ToString();
                                                break;
                                            case 2://type 
                                                _type = dataReader[x].ToString();
                                                break;
                                            case 3://pub id
                                                _pubid = dataReader[x].ToString();
                                                break;
                                            case 4://price
                                                _price = Convert.ToDecimal(dataReader[x]);
                                                break;
                                            case 5://advance
                                                _advance = Convert.ToDecimal(dataReader[x]);
                                                break;
                                            case 6://royalty
                                                _royalty = Convert.ToInt32(dataReader[x]);
                                                break;
                                            case 7://ytdsales
                                                _tyd_sales = Convert.ToInt32(dataReader[x]);
                                                break;
                                            case 8://notes
                                                _notes = dataReader[x].ToString();
                                                break;
                                            case 9://pubdate
                                                _pubdate = Convert.ToDateTime(dataReader[x]);
                                                break;
                                            case 10://duplicate do nothing.
                                                break;
                                            case 11://pubname 
                                                _pub = dataReader[x].ToString();
                                                break;
                                            case 12://city
                                                _city = dataReader[x].ToString();
                                                break;
                                            case 13://state
                                                _state = dataReader[x].ToString();
                                                break;
                                            case 14://country
                                                _country = dataReader[x].ToString();
                                                break;
                                        }


                                    }
                                }

                                _publisher = new Publisher(_pubid, _pub, _state, _country, _city);
                                book = new Title(_titleid, _title, _type, _price, _pubdate, _publisher, _advance, _royalty, _tyd_sales, _notes);

                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 
            }
            catch (SqlException)
            {
                return default(Title);
            }

            return book;
        }
        public bool IRepositoryAdd(Title Book)
        {



            try
            {
                string connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string Command = "INSERT INTO titles VALUES ('"+Book.titleid+"','"+Book.title+"','"+Book.type+"','"+Book.publisher.pubid+"',"+Book.price+ ","+Book.advance+ ","+Book.royalty+ ","+Book.tyd_sales+ ",'"+Book.notes+ "','"+Book.pubdate+"');";
                    using (SqlCommand cmd = new SqlCommand(Command, conn))
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                        //rows number of record got IRepositoryUpdated
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
                //Display Error message
                return false;
            }
        }

        public bool IRepositoryUpdate(Title Book)
        {

            try
            {
                string connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string Command = "Update titles SET  title='"+Book.title+ "', type ='"+Book.type+ "' ,price = "+Book.price+ ",pub_id ='"+Book.publisher.pubid+ "',notes='"+Book.notes+ "' where title_id= '"+Book.titleid+"';";
                    using (SqlCommand cmd = new SqlCommand(Command, conn))
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                        //rows number of record got IRepositoryUpdated
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
                //Display Error message
                return false;
            }
        }

        public bool IRepositoryRemove(Title Book)
        {
            try
            {
                string connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    string Command = "DELETE FROM titles WHERE title_id = '"+Book.titleid+"'; ";
                    //IRepositoryUpdate authors SET au_fname='bill', au_lname='mlem',phone = '123 123-1234',address= '123 mlem way', city = 'mlem', state= 'nh', zip ='03301',contract=1 WHERE au_id= '172-32-1176'
                    using (SqlCommand cmd = new SqlCommand(Command, conn))
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                        //rows number of record got IRepositoryUpdated
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
                //Display Error message
                return false;
            }
        }

        public List<Title> IRepositoryFindAll()
        {


            List<Title> books = new List<Title>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM titles T JOIN publishers P ON P.pub_id = T.pub_id", connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {
                                string _pubid = "";
                                string _pub = "";
                                string _state = "";
                                string _country = "";
                                string _city = "";
                                string _titleid = "";
                                string _title = "";
                                string _type = "";
                                Decimal? _price = null;
                                DateTime? _pubdate = null;
                                Publisher _publisher;
                                Decimal? _advance = null;
                                int? _royalty = null;
                                int? _tyd_sales = null;
                                string _notes = "";
                                for (int x = 0; x < 14; x++)
                                {

                                    if (!dataReader.IsDBNull(x))
                                    {
                                        switch (x)
                                        {

                                            case 0: //title id
                                                _titleid = dataReader[x].ToString();

                                                break;
                                            case 1: //title
                                                _title = dataReader[x].ToString();
                                                break;
                                            case 2://type 
                                                _type = dataReader[x].ToString();
                                                break;
                                            case 3://pub id
                                                _pubid = dataReader[x].ToString();
                                                break;
                                            case 4://price
                                                _price = Convert.ToDecimal(dataReader[x]);
                                                break;
                                            case 5://advance
                                                _advance = Convert.ToDecimal(dataReader[x]);
                                                break;
                                            case 6://royalty
                                                _royalty = Convert.ToInt32(dataReader[x]);
                                                break;
                                            case 7://ytdsales
                                                _tyd_sales = Convert.ToInt32(dataReader[x]);
                                                break;
                                            case 8://notes
                                                _notes = dataReader[x].ToString();
                                                break;
                                            case 9://pubdate
                                                _pubdate = Convert.ToDateTime(dataReader[x]);
                                                break;
                                            case 10://duplicate do nothing.
                                                break;
                                            case 11://pubname 
                                                _pub = dataReader[x].ToString();
                                                break;
                                            case 12://city
                                                _city = dataReader[x].ToString();
                                                break;
                                            case 13://state
                                                _state = dataReader[x].ToString();
                                                break;
                                            case 14://country
                                                _country = dataReader[x].ToString();
                                                break;
                                        }


                                    }
                                }

                                _publisher = new Publisher(_pubid, _pub, _state, _country, _city);
                                Title book = new Title(_titleid, _title, _type, _price, _pubdate, _publisher, _advance, _royalty, _tyd_sales, _notes);
                                books.Add(book);
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 

            }

            catch (SqlException)
            {
                //bad connectoin first try reinstalling database.
                return default(List<Title>);
            }

            return books;
        }
        public bool IRepositoryReset(Title Book)
        {
            return false;
        }
        public List<string> getBooksByAuthor(string au_id)
        {
            
            List<string> books = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT Titles.title_id FROM titles JOIN titleauthor ON Titleauthor.title_id = Titles.title_id WHERE Titleauthor.au_id = '" + au_id + "'", connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {
                                string book = (string)dataReader[0];
                                books.Add(book);
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 

            }

            catch (SqlException ex)
            {
                //badconnection.
                return default(List<string>);
            }
            return books;
        }
        public bool Link(string Book, string au)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO titleauthor values('" + au + "','" +Book+"','','');", connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {

                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 

            }

            catch (SqlException)
            {
                //bad connectoin first try reinstalling database.
                return false;
            }

            return true;
        }
        public bool UnLink(string Book, string au)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("delete  from titleauthor where title_id='" + Book + "' and au_id = '" + au + "';", connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {

                            } // end read loop 

                            if (dataReader.RecordsAffected==0)
                            {
                                return false;
                            }
                        }// end use reader
                    }// end use command
                }// end use connection 

            }

            catch (SqlException)
            {
                //bad connectoin first try reinstalling database.
                return false;
            }

            return true;
        }
    }

}
