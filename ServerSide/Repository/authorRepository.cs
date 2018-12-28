using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;


using Model;
using configFile;

namespace Repository
{

    public class authorRepository : IRepository<author>
    {
        private string _connectionString;
        public authorRepository()
        {
            _connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";

        }
        public author IRepositoryFindByID(string id)
        {
            author au = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM authors WHERE au_id = @id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id", id));

                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {

                                au = new author(dataReader["au_id"].ToString(),
                                                dataReader["au_fname"].ToString(),
                                                dataReader["au_lname"].ToString(),
                                                dataReader["phone"].ToString(),
                                                dataReader["address"].ToString(),
                                                dataReader["city"].ToString(),
                                                dataReader["state"].ToString(),
                                                dataReader["zip"].ToString(),
                                                Convert.ToBoolean(dataReader["contract"]));
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 
            }
            catch (SqlException)
            {
                return default(author);
            }

            return au;
        }
        public bool IRepositoryAdd(author au)
        {



            try
            {
                string connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    string temp = "";
                    if (au.contract)
                    {
                        temp = "1";
                    }
                    else
                    {
                        temp = "0";
                    } //
                    string Command = "INSERT INTO authors VALUES ('" + au.id + "','" + au.LastName + "','" + au.FirstName + "','" + au.phone + "','" + au.address + "','" + au.city + "','" + au.state + "','" + au.zip + "'," + temp + ");";
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
        public bool IRepositoryUpdate(author au)
        {

            try
            {
                string connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    string temp = "";
                    if (au.contract)
                    {
                        temp = "1";
                    }
                    else
                    {
                        temp = "0";
                    }
                    string Command = "Update authors SET au_fname='" + au.FirstName + "', au_lname='" + au.LastName + "',phone = '" + au.phone + "',address= '" + au.address + "', city = '" + au.city + "', state= '" + au.state + "', zip ='" + au.zip + "',contract=" + temp + "WHERE au_id= '" + au.id + "'";
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
        public bool IRepositoryRemove(author au)
        {
            try
            {
                string connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    string Command = "DELETE FROM authors WHERE au_id = '" + au.id + "'; ";
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
        bool preventfeedback = false;
        public List<author> IRepositoryFindAll()
        {


            List<author> authors = new List<author>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM authors", connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {
                                author au = new author(dataReader["au_id"].ToString(),
                                 dataReader["au_fname"].ToString(),
                                 dataReader["au_lname"].ToString(),
                                 dataReader["phone"].ToString(),
                                 dataReader["address"].ToString(),
                                 dataReader["city"].ToString(),
                                 dataReader["state"].ToString(),
                                 dataReader["zip"].ToString(),
                                 Convert.ToBoolean(dataReader["contract"]));
                                authors.Add(au);
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 
            }
            catch (SqlException)
            {
                //bad connectoin first try reinstalling database.
                author au = new author("", "", "", "", "", "", "", "", false);
                if (IRepositoryReset(au))
                {
                    if (preventfeedback)
                    {
                        return default(List<author>);
                    }
                    else
                    {

                        return IRepositoryFindAll();
                    }
                }
                else
                {

                    return default(List<author>);

                }
            }

            return authors;
        }
        private void CloseConections()
        {

            try
            {
                string connectionString = "Integrated Security=true;Initial Catalog=master;Data Source=(local);";
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    string Command = "ALTER DATABASE pubs SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    //IRepositoryUpdate authors SET au_fname='bill', au_lname='mlem',phone = '123 123-1234',address= '123 mlem way', city = 'mlem', state= 'nh', zip ='03301',contract=1 WHERE au_id= '172-32-1176'
                    using (SqlCommand cmd = new SqlCommand(Command, conn))
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            
                        }
                        else
                        {
                            
                        }

                        //rows number of record got IRepositoryUpdated
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
                //Display Error message
                
            }


            try
            {
                string connectionString = "Integrated Security=true;Initial Catalog=master;Data Source=(local);";
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    string Command = "ALTER DATABASE pubs SET MULTI_USER";
                    //IRepositoryUpdate authors SET au_fname='bill', au_lname='mlem',phone = '123 123-1234',address= '123 mlem way', city = 'mlem', state= 'nh', zip ='03301',contract=1 WHERE au_id= '172-32-1176'
                    using (SqlCommand cmd = new SqlCommand(Command, conn))
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {

                        }
                        else
                        {

                        }

                        //rows number of record got IRepositoryUpdated
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
                //Display Error message

            }
        }
        public bool IRepositoryReset(author T1)
        {

            //return false;


            try
            {
                string Path = "";
                bool searching = true;
                foreach (string directory in System.IO.Directory.GetLogicalDrives())
                {
                    if (searching)
                    {


                        foreach (string filePath in Directory.GetDirectories(directory))
                        {
                            if (searching)
                            {
                                try
                                {
                                    if (string.IsNullOrWhiteSpace(Path))
                                    {
                                        if (searching)
                                        {
                                            foreach (string f in Directory.GetFiles(filePath, "instpubs.sql", SearchOption.AllDirectories))
                                            {

                                                if (searching)
                                                {
                                                    Path = f;
                                                    searching = false;

                                                }
                                            }
                                        }
                                    }
                                }

                                catch (Exception)
                                {

                                }

                            }
                        }
                    }
                }
                string script = File.ReadAllText(Path);
                // split script on GO command
                System.Collections.Generic.IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                                 RegexOptions.Multiline | RegexOptions.IgnoreCase);
                string connectionstring = "";
                if (T1.contract)
                {
                    connectionstring = _connectionString;
                }
                else
                {
                    connectionstring = "Integrated Security=true;Initial Catalog=master;Data Source=(local);";
                }
                CloseConections();
                using (SqlConnection connection = new SqlConnection(connectionstring))//uses different string for setup and IRepositoryReset. determined by bool in author.
                {
                    connection.Open();
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {
                            using (var command = new SqlCommand(commandString, connection))
                            {
                                try
                                {
                                    command.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {

                                    string spError = commandString.Length > 100 ? commandString.Substring(0, 100) + " ...\n..." : commandString;
                                    return false;
                                }
                            }
                        }
                    }
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

    }

}
