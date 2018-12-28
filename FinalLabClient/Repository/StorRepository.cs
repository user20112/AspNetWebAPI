using System;
using System.Collections.Generic;

using Model;
using configFile;
using System.Data.SqlClient;
using System.Net.Http;

namespace Repository
{
    public class StorRepository : IRepository<Store>
    {
        private string _connectionString;
        public StorRepository()
        {
            _connectionString = configurationFile.getSetting("apiRoot")+"Stores";

        }
        public bool IRepositoryAdd(Store x)
        {
            throw new NotImplementedException();
        }

        public List<Store> IRepositoryFindAll()
        {
            List<Store> stores = default(List<Store>);

            HttpClient client = new HttpClient();

            // For this example Books is already a part of the path
            string path = _connectionString;

            try
            {
                HttpResponseMessage response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode == true)
                    stores = response.Content.ReadAsAsync<List<Store>>().Result;

            }
            catch //(Exception ex)
            {
                return stores;
            }
            return stores;
        }

        public Store IRepositoryFindByID(string id)
        {
            {
                Store store = default(Store);

                HttpClient client = new HttpClient();

                // For this example Books is already a part of the path
                string path = _connectionString + "/" + id;

                try
                {
                    HttpResponseMessage response = client.GetAsync(path).Result;

                    if (response.IsSuccessStatusCode == true)
                        store = response.Content.ReadAsAsync<Store>().Result;

                }
                catch //(Exception ex)
                {
                    return store;
                }
                return store;
            }
        }
        public List<string> FindallOrders(string id)
        {
            List<string> ID = default(List<string>);

            HttpClient client = new HttpClient();

            // For this example Books is already a part of the path
            string path = _connectionString+ "/Orders/"+id;

            try
            {
                HttpResponseMessage response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode == true)
                    ID = response.Content.ReadAsAsync<List<string>>().Result;

            }
            catch //(Exception ex)
            {
                return ID;
            }
            return ID;
        }

        public bool IRepositoryRemove(Store x)
        {
            throw new NotImplementedException();
        }

        public bool IRepositoryUpdate(Store x)
        {
            throw new NotImplementedException();
        }
    }
}
