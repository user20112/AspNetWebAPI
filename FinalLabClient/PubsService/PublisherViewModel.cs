using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubsService
{
    public class PublisherViewModel
    {
        public string _pubid;
        public string _pub;
        public string _state;
        public string _country;
        public string _city;

        public PublisherViewModel(string pubid, string pub, string state, string country, string city)
        {//constructor 
            if (city == null)
            {
                _city = "Unknown";
            }
            else
            {
                _city = city;
            }
            _pubid = pubid;
            if (pub == null)
            {
                _pub = "Anonymous";
            }
            else
            {
                _pub = pub;
            }
            if (state == null)
            {
                _state = "Unknown";
            }
            else
            {
                _state = state;
            }
            if (country == null)
            {
                _country = "UnKnown";
            }
            else
            {
                _country = country;
            }
        }

        public string pubid
        {
            get { return _pubid; }
        }

        public string pub
        {
            get { return _pub; }
            set { _pub = value; }
        }
        public string state
        {
            get { return _state; }
            set { _state = value; }
        }
        public string country
        {
            get { return _country; }
            set { _country = value; }
        }



    }
}
