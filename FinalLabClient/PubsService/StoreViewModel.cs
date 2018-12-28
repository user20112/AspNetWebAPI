using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubsService
{
    public class StoreViewModel
    {
        public string StorID;
        public string StorName;
        public string Address;
        public string City;
        public string State;
        public string Zip;
        public StoreViewModel(string storid, string storname, string address, string city, string state, string zip)
        {
            StorID = storid;
            StorName = storname;
            Address = address;
            City = city;
            State = state;
            Zip = zip;

        }
    }
}
