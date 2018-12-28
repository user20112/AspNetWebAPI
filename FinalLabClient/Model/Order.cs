using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public string StorID;
        public string OrderNumber;
        public DateTime Date;
        public List<int> Qty;
        public string PayTerms;
        public List<string> Books;
        public Order(string storid, string ordernumber, DateTime date, List<int> qty, string payterms, List<string> books)
        {//constructor 
            StorID = storid;
            OrderNumber = ordernumber;
            Date = date;
            Qty = qty;
            PayTerms = payterms;
            Books = books;
        }

    }
}
