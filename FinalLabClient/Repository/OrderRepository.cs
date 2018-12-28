using System;
using System.Collections.Generic;
using System.Text;

using Model;
using configFile;
using System.Net.Http;
using Newtonsoft.Json;

namespace Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private string _connectionString;
        public OrderRepository()
        {
            _connectionString = configurationFile.getSetting("apiRoot") + "Orders";

        }
        public bool IRepositoryAdd(Order x)
        {
            HttpClient client = new HttpClient();
            string path = _connectionString + "/Add/";
            string data = JsonConvert.SerializeObject(x);
            StringContent message = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(path, message).Result;
            return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
        }

        public List<Order> IRepositoryFindAll()
        {
            List<Order> orders = default(List<Order>);

            HttpClient client = new HttpClient();

            // For this example Books is already a part of the path
            string path = _connectionString;

            try
            {
                HttpResponseMessage response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode == true)
                    orders = response.Content.ReadAsAsync<List<Order>>().Result;

            }
            catch //(Exception ex)
            {
                return orders;
            }
            return orders;
        }

        public Order IRepositoryFindByID(string id)
        {
            Order order = default(Order);

            HttpClient client = new HttpClient();

            // For this example Books is already a part of the path
            string path = _connectionString + "/" + id;

            try
            {
                HttpResponseMessage response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode == true)
                    order = response.Content.ReadAsAsync<Order>().Result;

            }
            catch //(Exception ex)
            {
                return order;
            }
            return order;
        }
        public bool UpdateOrderQuantity(string ordernum, string titleid, int quantity)
        {
            {
                bool Succ = false;

                HttpClient client = new HttpClient();

                // For this example Books is already a part of the path
                string path = _connectionString + "/" + ordernum + "/" + titleid + "/" + quantity;

                try
                {
                    HttpResponseMessage response = client.GetAsync(path).Result;

                    if (response.IsSuccessStatusCode == true)
                        Succ = response.Content.ReadAsAsync<bool>().Result;

                }
                catch //(Exception ex)
                {
                    return Succ;
                }
                return Succ;
            }
        }

        public bool IRepositoryRemove(Order x)
        {
            HttpClient client = new HttpClient();
            string path = _connectionString + "/Remove/";
            string data = JsonConvert.SerializeObject(x);
            StringContent message = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(path, message).Result;
            return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
        }


        public bool IRepositoryUpdate(Order x)
        {
            HttpClient client = new HttpClient();
            string path = _connectionString + "/Update/";
            string data = JsonConvert.SerializeObject(x);
            StringContent message = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(path, message).Result;
            return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
        }
    }
}
