namespace PubsService
{
    public class AuthorViewModel
    {
        public string _fname { get; set; }
        public string _lname { get; set; }
        public string _id { get; private set; }

        public string _phone { get; set; }
        public string _address { get; set; }
        public string _city { get; set; }
        public string _state { get; set; }
        public string _zip { get; set; }
        public string _contract { get; set; }
        public AuthorViewModel(string id, string fname, string lname, string phone, string address, string city, string state, string zip, bool contract)
        {
            _id = id;
            _fname = fname;
            _lname = lname;
            _phone = phone;
            _address = address;
            _city = city;
            _state = state;
            _zip = zip;
            if (contract)
            {
                _contract = "yes";
            }
            else
            {
                _contract = "no";
            }


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
        public string contract
        {
            get { return _contract; }
            set { _contract = value; }
        }


    }
}
