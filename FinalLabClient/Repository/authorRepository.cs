using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;


using Model;
using configFile;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
namespace Repository
{

    public class authorRepository : IRepository<author>
    {
        private string _connectionString;
        public authorRepository()
        {
            _connectionString = configurationFile.getSetting("apiRoot") + "Authors";

        }
        public author IRepositoryFindByID(string id)// good example of get
        {
            author au = default(author);

            HttpClient client = new HttpClient();

            // For this example Books is already a part of the path
            string path = _connectionString + "/" + id;

            try
            {
                HttpResponseMessage response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode == true)
                    au = response.Content.ReadAsAsync<author>().Result;

            }
            catch //(Exception ex)
            {
                return au;
            }
            return au;
        }
        public bool IRepositoryAdd(author au)//working example of post
        {
            HttpClient client = new HttpClient();
            string path = _connectionString + "/Add/";
            string data = JsonConvert.SerializeObject(au);
            StringContent message = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(path, message).Result;
            return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
        }
        public bool IRepositoryUpdate(author au)
        {
            HttpClient client = new HttpClient();
            string path = _connectionString + "/Update/";
            string data = JsonConvert.SerializeObject(au);
            StringContent message = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(path, message).Result;
            return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
        }
        public bool IRepositoryRemove(author au)
        {
            HttpClient client = new HttpClient();
            string path = _connectionString + "/Remove/";
            string data = JsonConvert.SerializeObject(au);
            StringContent message = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(path, message).Result;
            return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
        }
        public List<author> IRepositoryFindAll()//good example of get
        {
            List<author> au = default(List<author>);

            HttpClient client = new HttpClient();

            // For this example Books is already a part of the path
            string path = _connectionString;

            try
            {
                HttpResponseMessage response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode == true)
                    au = response.Content.ReadAsAsync<List<author>>().Result;

            }
            catch //(Exception ex)
            {
                return au;
            }
            return au;
        }
        public bool IRepositoryReset(author au)
        {
            HttpClient client = new HttpClient();
            string path = _connectionString + "/Reset";
            string data = JsonConvert.SerializeObject(au);
            StringContent message = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(path, message).Result;
            return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);

        }
    }
}
