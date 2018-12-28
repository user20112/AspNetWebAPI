using System;
using System.Collections.Generic;

using Model;
using configFile;
using System.Data.SqlClient;

namespace Repository
{
    public class StorRepository : IRepository<Store>
    {
        private string _connectionString;
        public StorRepository()
        {
            _connectionString = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";

        }
        public bool IRepositoryAdd(Store x)
        {
            throw new NotImplementedException();
        }

        public List<Store> IRepositoryFindAll()
        {



            List<Store> stores = new List<Store>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM stores", connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {
                                Store store = new Store(dataReader["stor_id"].ToString(),
                                 dataReader["stor_name"].ToString(),
                                 dataReader["stor_address"].ToString(),
                                 dataReader["city"].ToString(),
                                 dataReader["state"].ToString(),
                                 dataReader["zip"].ToString());
                                stores.Add(store);
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 
            }
            catch (SqlException)
            {
                return default(List<Store>);
            }

            return stores;
        }

        public Store IRepositoryFindByID(string id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("select * from stores where stor_id ='" + id + "'", connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {
                                Store store = new Store(dataReader["stor_id"].ToString(),
                                 dataReader["stor_name"].ToString(),
                                 dataReader["stor_address"].ToString(),
                                 dataReader["city"].ToString(),
                                 dataReader["state"].ToString(),
                                 dataReader["zip"].ToString());

                                return store;
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 
            }
            catch (SqlException)
            {
                return default(Store);
            }
            return default(Store);
        }
        public List<string> FindallOrders(string id)//select ord_num from sales where stor_id = '7067';
        {
            List<string> stores = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("select DISTINCT (ord_num) from sales where stor_id = '" + id+"';", connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {
                                stores.Add(dataReader["ord_num"].ToString());
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 
            }
            catch (SqlException)
            {
                return default(List<string>);
            }

            return stores;
        }

        public bool IRepositoryRemove(Store x)
        {
            throw new NotImplementedException();
        }

        public bool IRepositoryReset(Store x)
        {
            throw new NotImplementedException();
        }

        public bool IRepositoryUpdate(Store x)
        {
            throw new NotImplementedException();
        }
    }
}
