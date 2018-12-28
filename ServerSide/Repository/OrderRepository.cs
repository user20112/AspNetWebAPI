using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using configFile;
using System.Data.SqlClient;

namespace Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private string _connectionString;
        public OrderRepository()
        {
            _connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";

        }
        public bool IRepositoryAdd(Order x)
        {

            for (int y=0;y< x.Qty.Count;y++)
            {

                try
                {
                    string connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";
                    using (SqlConnection conn =
                        new SqlConnection(connectionString))
                        {
                        conn.Open();
                        string Command = "insert into sales values ('" + x.StorID + "','" + x.OrderNumber + "','" + x.Date.ToString() + "'," + x.Qty[y].ToString() +",'" + x.PayTerms + "','" +x.Books[y] +"');";
                        using (SqlCommand cmd = new SqlCommand(Command, conn))
                        {
                            int rows = cmd.ExecuteNonQuery();
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
            return true;
        }

        public List<Order> IRepositoryFindAll()
        {


            List<Order> orders = new List<Order>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("select DISTINCT (ord_num), stor_id, ord_date,payterms from sales", connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {
                                Order order = IRepositoryFindByID(dataReader["ord_num"].ToString());
                                orders.Add(order);
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 
            }
            catch (SqlException)
            {
                return default(List<Order>);

            }

            return orders;
        }

        public Order IRepositoryFindByID(string id)
        {
            List<int> qty = new List<int>();
            List<string> books = new List<string>();
            string storid = null;
            string payterms = null;
            DateTime orddate = DateTime.Now;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("select DISTINCT (ord_num), stor_id, ord_date,payterms from sales where ord_num = @id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id", id));

                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {

                            while (dataReader.Read()) // foward only and readonly
                            {
                                storid = dataReader["stor_id"].ToString();
                                payterms = dataReader["payterms"].ToString();
                                orddate = Convert.ToDateTime(dataReader["ord_date"]);
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 
            }
            catch (SqlException)
            {
                return default(Order);
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT S.qty, T.title_id FROM sales S JOIN titles T ON S.title_id = T.title_id WHERE S.ord_num = @id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id", id));

                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {

                            while (dataReader.Read()) // foward only and readonly
                            {
                                qty.Add(Convert.ToInt32(dataReader["qty"]));
                               books.Add(dataReader["title_id"].ToString());
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 
            }
            catch (SqlException)
            {
                return default(Order);
            }

            return new Order(storid, id, orddate, qty, payterms, books);
        }
        public bool UpdateOrderQuantity(string ordernum, string titleid, int quantity)
        {
            try
            {
                string connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    string Command = "update sales set qty="+quantity.ToString()+" where title_id='" + titleid.ToString() + "' And ord_num='" + ordernum.ToString() + "'";
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

        public bool IRepositoryRemove(Order x)
        {

            try
            {
                string connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    string Command = "DELETE FROM sales WHERE ord_num = '" + x.OrderNumber + "'; ";
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

        public bool IRepositoryReset(Order x)
        {
            throw new NotImplementedException();
        }

        public bool IRepositoryUpdate(Order x)
        {
            if (IRepositoryRemove(x))//since this is a non reliant section there will neve be a time where an order is stuck due to forieng key dependencies.
            {
                if (IRepositoryAdd(x))//therefore this should be ok.
                {
                    return true;
                }
            }
            return false;
        }
    }
}
