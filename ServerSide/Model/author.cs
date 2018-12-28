namespace Model // author class.
{
    public class author
    {
        private string _id;
        private string _fname;
        private string _lname;
        private string _phone;
        private string _address;
        private string _city;
        private string _state;
        private string _zip;
        private bool _contract;

        public author(string id, string fname, string lname, string phone, string address, string city, string state, string zip, bool contract)
        {//constructor 
            _id = id;
            _fname = fname;
            _lname = lname;
            _phone = phone;
            _address = address;
            _city = city;
            _state = state;
            _zip = zip;
            _contract = contract;

        }

        public string id
        {
            get { return _id; }
        }

        public string FirstName
        {
            get { return _fname; }
            set { _fname = value; }
        }

        public string LastName
        {
            get { return _lname; }
            set { _lname = value; }
        }

        public string Name
        {
            get { return _fname + " " + _lname; }
        }
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        public string state
        {
            get { return _state; }
            set { _state = value; }
        }
        public string zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        public bool contract
        {
            get { return _contract; }
            set { _contract = value; }
        }
    }

}
