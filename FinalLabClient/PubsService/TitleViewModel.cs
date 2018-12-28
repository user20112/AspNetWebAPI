using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubsService
{
    public class TitleViewModel
    {
        private string _titleid;
        private string _title;
        private string _type;
        private string _price;
        private string _pubdate;
        private PublisherViewModel _publisher;
        private string _advance;
        private string _royalty;
        private string _tyd_sales;
        private string _notes;

        public TitleViewModel(string titleid, string title, string type, Decimal? price, DateTime? pubdate, PublisherViewModel publisher, Decimal? advance, int? royalty, int? tyd_sales, string notes)
        {//constructor 
            _titleid = titleid;
            _title = title;
            _type = type;
            _price = price.HasValue ? price.Value.ToString() : "None";
            _pubdate = pubdate.HasValue ? pubdate.Value.ToString() : "Unknown";
            _advance = advance.HasValue ? advance.Value.ToString() : "None";
            _publisher = publisher;
            _royalty = royalty.HasValue ? royalty.Value.ToString() : "None";
            _tyd_sales = tyd_sales.HasValue ? tyd_sales.Value.ToString() : "None";
            _notes = notes;
        }

        public string titleid
        {
            get { return _titleid; }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string pubdate
        {
            get { return _pubdate; }
            set { _pubdate = value; }
        }
        public PublisherViewModel publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }
        public string royalty
        {
            get { return _royalty; }
            set { _royalty = value; }
        }
        public string tyd_sales
        {
            get { return _tyd_sales; }
            set { _tyd_sales = value; }
        }
        public string advance
        {
            get { return _advance; }
            set { _advance = value; }
        }
        public string notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
    }
}

