using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Title
    {
        private string _titleid;
        private string _title;
        private string _type;
        private Decimal? _price;
        private DateTime? _pubdate;
        private Publisher _publisher;
        private Decimal? _advance;
        private int? _royalty;
        private int? _tyd_sales;
        private string _notes;

        public Title(string titleid, string title, string type, Decimal? price, DateTime? pubdate, Publisher publisher, Decimal? advance,int? royalty,int? tyd_sales,string notes)
        {//constructor 
            _titleid = titleid;
            _title = title;
            _type = type;
            _price = price;
            _pubdate = pubdate;
            _publisher = publisher;
            _advance = advance;
            _royalty = royalty;
            _tyd_sales = tyd_sales;
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
        public Decimal? price
        {
            get { return _price; }
            set { _price = value; }
        }
        public DateTime? pubdate
        {
            get { return _pubdate; }
            set { _pubdate = value; }
        }
        public Publisher publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }
        public int? royalty
        {
            get { return _royalty; }
            set { _royalty = value; }
        }
        public int? tyd_sales
        {
            get { return _tyd_sales; }
            set { _tyd_sales = value; }
        }
        public Decimal? advance
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
