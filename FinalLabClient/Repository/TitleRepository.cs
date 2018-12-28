using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;


using Model;
using configFile;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Repository
{

    public class titleRepository : IRepository<Title>
    {
        private string _connectionString;

        public titleRepository()
        {
            _connectionString = configurationFile.getSetting("apiRoot") + "Books";
        }

        public Title IRepositoryFindByID(string Book)
        {
            Title book = default(Title);

            HttpClient client = new HttpClient();

            // For this example Books is already a part of the path
            string path = _connectionString + "/" + Book;

            try
            {
                HttpResponseMessage response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode == true)
                    book = response.Content.ReadAsAsync<Title>().Result;

            }
            catch //(Exception ex)
            {
                return book;
            }
            return book;
        }
        public bool IRepositoryAdd(Title Book)
        {
            HttpClient client = new HttpClient();
            string path = _connectionString + "/Add/";
            string data = JsonConvert.SerializeObject(Book);
            StringContent message = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(path, message).Result;
            return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
        }

        public bool IRepositoryUpdate(Title Book)
        {
            HttpClient client = new HttpClient();
            string path = _connectionString + "/Update/";
            string data = JsonConvert.SerializeObject(Book);
            StringContent message = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(path, message).Result;
            return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
        }

        public bool IRepositoryRemove(Title Book)
        {
            HttpClient client = new HttpClient();
            string path = _connectionString + "/Remove/";
            string data = JsonConvert.SerializeObject(Book);
            StringContent message = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(path, message).Result;
            return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
        }

        public List<Title> IRepositoryFindAll()
        {
            List<Title> book = default(List<Title>);

            HttpClient client = new HttpClient();

            // For this example Books is already a part of the path
            string path = _connectionString;

            try
            {
                HttpResponseMessage response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode == true)
                    book = response.Content.ReadAsAsync<List<Title>>().Result;

            }
            catch //(Exception ex)
            {
                return book;
            }
            return book;
        }

        public List<string> getBooksByAuthor(string au_id)
        {
            List<string> book = default(List<string>);

            HttpClient client = new HttpClient();

            // For this example Books is already a part of the path
            string path = _connectionString + "/ByAuthor/" + au_id;

            try
            {
                HttpResponseMessage response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode == true)
                    book = response.Content.ReadAsAsync<List<string>>().Result;

            }
            catch //(Exception ex)
            {
                return book;
            }
            return book;
        }
        public bool Link(string Book, string au)
        {

            {
                bool Succ = false;

                HttpClient client = new HttpClient();

                // For this example Books is already a part of the path
                string path = _connectionString + "/Link" + "/" + Book + "/" + au;

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
        public bool UnLink(string Book, string au)
        {


            {
                bool Succ = false;

                HttpClient client = new HttpClient();

                // For this example Books is already a part of the path
                string path = _connectionString + "/UnLink" + "/" + Book + "/" + au;

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

    }

}
