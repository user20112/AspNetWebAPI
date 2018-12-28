/*
 * Name: Devlin Paddock
 * Course: CPET240C Section: WR 
 * Lab06
 * Term :Fall 2018
 * interfaces with and talks to pubs database on the local machine.  This only interacts with the authors , titles , and publishers Tablbes adding editing and removing values. It can not Remove authors that are active in other tables.
 *  
 *  *Extra random stuff:
 * Database reset button for ease of testing. Does warn requires no other application interfaceing with pubs at the time of reset.
 * Database is automaticly installed by the program on startup if not found. if this fails it will prompt the user to install the database manually.
 * stores Publisher Data as well as a class under title class.
 * Closes all existing connections before Reset of database ( allows a reset even if something else is connected).
 * Finds an install file for pubs. this allows for it to be hosted by different web applications or if you delete the one in the file you can add your own and it will find it whereever it is placed on the pc.
 * Double click to change quantity in little modal form
 * known problems:
 * when no database is found startup takes 13seconds average. has to wait for open to fail then find file then install database.
 * Edit Orders that already exist
 * Delete Orders.
 * 
  */

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;

using PubsService;
namespace Lab03
{

    public partial class Form1 : Form
    {
        Form form = new Form();
        List<PubsService.AuthorViewModel> authors = new List<AuthorViewModel>();
        List<PubsService.TitleViewModel> books = new List<TitleViewModel>();
        List<PubsService.StoreViewModel> stores = new List<StoreViewModel>();
        List<PubsService.OrderViewModel> orders = new List<OrderViewModel>();
        authorsService pubs;
        Random rnd = new Random(); // used for random numbers randomly.
        bool clicked = false;


        public Form1()
        {

            InitializeComponent();// Make the form !
            SetupForm();

        }

        void SetupForm()
        {
            pubs = new authorsService();
            authors = pubs.GetAllAuthors(); // get all authors
            books = pubs.GetAllBooks();//get all books.
            orders = pubs.GetAllOrders();
            stores = pubs.GetAllStores();
            comboBox1.Click += ComboClick;

            if (authors == null || books == null || orders == null || stores == null)// if we return defaul authors it means the connection was invalid. send error out.
            {
                MessageBox.Show("Invalid Connection. Please setup SQL ServerManagement with (local) and with pubs installed");

            }
            else//valid return.
            {
                StoreList.View = View.Details;
                OrderList.View = View.Details;
                BookList.View = View.Details;
                CurrentList.View = View.Details;
                StoreList.HideSelection = false;
                OrderList.HideSelection = false;
                BookList.HideSelection = false;
                CurrentList.HideSelection = false;
                StoreList.MultiSelect = false;
                OrderList.MultiSelect = false;
                BookList.MultiSelect = false;
                CurrentList.MultiSelect = false;
                StoreList.Columns.Add("Store Name", -2);


                foreach (StoreViewModel store in stores)
                {
                    StoreList.Items.Add(store.StorName);
                }
                StoreList.Click += new EventHandler(StoreOnClick);
                OrderList.Click += new EventHandler(OrderOnClick);


            }


        }
        void ComboClick(object sender, EventArgs e)
        {
            clicked = true;
        }
        void CurrentDoubleClick(object sender, EventArgs e)
        {
            form = new Form();
            Label Lable = new Label();
            Lable.Text = "enter the quantity:";
            NumericUpDown box = new NumericUpDown();
            box.Name = "Box";
            box.Value = 0;
            Lable.Location = new Point(0, 0);
            box.Location = new Point(0, 25);
            box.Maximum = 10000;
            box.Increment = 5;
            box.Value = 1;
            box.Minimum = 1;


            form.Size = new Size(200, 200);
            form.Controls.Add(Lable);
            form.Controls.Add(box);
            Button submit = new Button();
            submit.Click += new EventHandler(submitclick);
            submit.Location = new Point(0, 50);
            submit.Text = "submit";
            form.Controls.Add(submit);
            form.ShowDialog(this); // if you need non-modal window
        }
        void submitclick(object sender, EventArgs e)
        {
            foreach (TitleViewModel book in books)
            {
                if (book.title == CurrentList.SelectedItems[0].SubItems[0].Text)
                {
                    if (pubs.UpdateOrderQuantity(OrderList.SelectedItems[0].SubItems[0].Text, book.titleid, Convert.ToInt32(((NumericUpDown)form.Controls.Find("Box", true)[0]).Value)))
                    {
                        CurrentList.SelectedItems[0].SubItems[2].Text = Convert.ToString(((NumericUpDown)form.Controls.Find("Box", true)[0]).Value);
                        orders = pubs.GetAllOrders();
                        CurrentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        form.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter a valid number");
                    }
                }
            }

        }
        void StoreOnClick()
        {
            if (StoreList.SelectedItems.Count == 0)
            {
                StoreList.Items[0].Selected = true;
            }

            OrderList.Clear();
            OrderList.Columns.Add("Order Number", -2);
            OrderList.Visible = true;
            OrdersLabel.Visible = true;
            NewOrder.Visible = true;
            List<string> stororders = null;
            foreach (StoreViewModel store in stores)
            {
                if (StoreList.SelectedItems[0].SubItems[0].Text.ToString() == store.StorName)
                {
                    stororders = pubs.FindOrdersByStore(store.StorID);
                }
            }
            foreach (string order in stororders)
            {
                foreach (OrderViewModel Order in orders)
                {
                    if (order == Order.OrderNumber)
                    {
                        OrderList.Items.Add(Order.OrderNumber);
                    }

                }
            }


        }
        void StoreOnClick(object sender, EventArgs e)
        {
            if (StoreList.SelectedItems.Count == 0)
            {
                StoreList.Items[0].Selected = true;
            }
            else
            {
                OrderList.Clear();
                OrderList.Columns.Add("Order Number", -2);
                OrderList.Visible = true;
                OrdersLabel.Visible = true;
                NewOrder.Visible = true;
                List<string> stororders = null;
                foreach (StoreViewModel store in stores)
                {
                    if (StoreList.SelectedItems[0].SubItems[0].Text.ToString() == store.StorName)
                    {
                        stororders = pubs.FindOrdersByStore(store.StorID);
                    }
                }
                foreach (string order in stororders)
                {
                    foreach (OrderViewModel Order in orders)
                    {
                        if (order == Order.OrderNumber)
                        {
                            OrderList.Items.Add(Order.OrderNumber);
                        }
                    }
                }
            }

        }
        void OrderOnClick(object sender, EventArgs e)
        {
            foreach (OrderViewModel order in orders)
            {
                if (order.OrderNumber == OrderList.SelectedItems[0].SubItems[0].Text)
                {
                    if (order.PayTerms == "OnInvoice")
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                    if (order.PayTerms == "Net 30")
                    {
                        comboBox1.SelectedIndex = 1;
                    }
                    if (order.PayTerms == "Net 60")
                    {
                        comboBox1.SelectedIndex = 2;
                    }

                }

            }

            comboBox1.Visible = true;
            button1.Visible = true;
            CurrentList.Visible = true;
            Quantity.Visible = true;
            lable1.Visible = true;
            ShiftLeft.Visible = true;
            ShiftRight.Visible = true;
            BookList.Clear();
            CurrentList.Clear();
            BookList.Columns.Add("Book Name", -1);
            BookList.Columns.Add("Price", -1);
            BookList.Columns.Add("Type", -1);
            BookList.Columns.Add("Publisher", -1);
            BookList.Columns.Add("Pubdate", -1);
            DeleteOrder.Visible = true;
            PaymentLabel.Visible = true;
            BookList.Visible = true;
            CurrentList.Visible = true;
            BooksLabel.Visible = true;
            CurrentLabel.Visible = true;
            CurrentList.Columns.Add("book Name", -2);
            CurrentList.Columns.Add("Price", -2);
            CurrentList.Columns.Add("Qty", -2);
            CurrentList.Columns.Add("Total", -2);
            List<string> BooksInOrder = new List<string>();
            foreach (OrderViewModel order in orders)
            {
                if (OrderList.SelectedItems[0].SubItems[0].Text.ToString() == order.OrderNumber)
                {
                    for (int x = 0; x < order.Qty.Count; x++)
                    {
                        foreach (TitleViewModel book in books)
                        {
                            if (book.titleid == order.Books[x])
                            {
                                List<string> item = new List<string>();
                                item.Add(book.title);
                                item.Add(book.price);
                                item.Add(order.Qty[x].ToString());
                                if (book.price == "None")
                                {
                                    item.Add("0");
                                }
                                else
                                {
                                    item.Add((order.Qty[x] * Convert.ToDecimal(book.price)).ToString());
                                }


                                CurrentList.Items.Add(new ListViewItem(item.ToArray()));
                                BooksInOrder.Add(book.titleid);
                            }

                        }

                    }
                }
            }
            bool inorder = false;
            CurrentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            foreach (TitleViewModel book in books)
            {
                foreach (string Book in BooksInOrder)
                {
                    if (Book == book.titleid)
                    {
                        inorder = true;
                    }
                }
                if (inorder)
                {
                    //skip it
                }
                else
                {
                    List<string> item = new List<string>();
                    item.Add(book.title);
                    item.Add(book.price);
                    item.Add(book.type);
                    item.Add(book.publisher.pub);
                    item.Add(book.pubdate);
                    BookList.Items.Add(new ListViewItem(item.ToArray()));
                }
                inorder = false;

            }
            BookList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            CurrentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }
        void OrderOnClick()
        {
            foreach (OrderViewModel order in orders)
            {
                if (order.OrderNumber == OrderList.SelectedItems[0].SubItems[0].Text)
                {
                    if (order.PayTerms == "OnInvoice")
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                    if (order.PayTerms == "Net 30")
                    {
                        comboBox1.SelectedIndex = 1;
                    }
                    if (order.PayTerms == "Net 60")
                    {
                        comboBox1.SelectedIndex = 2;
                    }
                }
            }
            comboBox1.Visible = true;
            button1.Visible = true;
            CurrentList.Visible = true;
            Quantity.Visible = true;
            lable1.Visible = true;
            ShiftLeft.Visible = true;
            ShiftRight.Visible = true;
            BookList.Clear();
            CurrentList.Clear();
            BookList.Columns.Add("Book Name", -1);
            BookList.Columns.Add("Price", -1);
            BookList.Columns.Add("Type", -1);
            BookList.Columns.Add("Publisher", -1);
            BookList.Columns.Add("Pubdate", -1);
            DeleteOrder.Visible = true;
            PaymentLabel.Visible = true;
            BookList.Visible = true;
            CurrentList.Visible = true;
            BooksLabel.Visible = true;
            CurrentLabel.Visible = true;
            CurrentList.Columns.Add("book Name", -2);
            CurrentList.Columns.Add("Price", -2);
            CurrentList.Columns.Add("Qty", -2);
            CurrentList.Columns.Add("Total", -2);
            List<string> BooksInOrder = new List<string>();
            foreach (OrderViewModel order in orders)
            {
                if (OrderList.SelectedItems[0].SubItems[0].Text.ToString() == order.OrderNumber)
                {
                    for (int x = 0; x < order.Qty.Count; x++)
                    {
                        foreach (TitleViewModel book in books)
                        {
                            if (book.titleid == order.Books[x])
                            {
                                List<string> item = new List<string>();
                                item.Add(book.title);
                                item.Add(book.price);
                                item.Add(order.Qty[x].ToString());
                                if (book.price == "None")
                                {
                                    item.Add("0");
                                }
                                else
                                {
                                    item.Add((order.Qty[x] * Convert.ToDecimal(book.price)).ToString());
                                }


                                CurrentList.Items.Add(new ListViewItem(item.ToArray()));
                                BooksInOrder.Add(book.titleid);
                            }

                        }

                    }
                }
            }
            bool inorder = false;
            CurrentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            foreach (TitleViewModel book in books)
            {
                foreach (string Book in BooksInOrder)
                {
                    if (Book == book.titleid)
                    {
                        inorder = true;
                    }
                }
                if (inorder)
                {
                    //skip it
                }
                else
                {
                    List<string> item = new List<string>();
                    item.Add(book.title);
                    item.Add(book.price);
                    item.Add(book.type);
                    item.Add(book.publisher.pub);
                    item.Add(book.pubdate);
                    BookList.Items.Add(new ListViewItem(item.ToArray()));
                }
                inorder = false;

            }
            BookList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            CurrentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }
        void refresh()
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public PublisherViewModel GetPublisher(string Name)
        {
            foreach (TitleViewModel book in books)
            {
                if (book.publisher.pub == Name)
                {
                    return book.publisher;
                }
            }
            return default(PublisherViewModel);
        }
        private ListViewItem GetItemFromPoint(ListView listView, Point mousePosition)// grabs item from mouse and listbox tossed in.
        {
            Point localPoint = listView.PointToClient(mousePosition);
            return listView.GetItemAt(localPoint.X, localPoint.Y);
        }

        public string GenerateID()
        {
            string id = "";
            int First = rnd.Next(100, 999); // creates a number between 1 and 12
            int Second = rnd.Next(10, 99);   // creates a number between 1 and 6
            int Third = rnd.Next(1000, 9999);     // creates a number between 0 and 51
            id = First.ToString() + "-" + Second.ToString() + "-" + Third.ToString(); // in form xxx-xx-xxxx


            return id;
        }
        public bool CheckID(string id)
        {
            bool validity = true;
            foreach (AuthorViewModel au in authors)// jsut make sure its not already used.
            {
                if (id == au.id)
                {
                    validity = false;
                }
            }
            return validity;
        }
        public bool CheckName(string first, string last)
        {
            bool validity = true;
            foreach (AuthorViewModel au in authors) //make sure its a unique first last name pair.
            {
                if (first == au.FirstName)
                {
                    if (last == au.LastName)
                    {
                        validity = false;
                    }
                }
            }
            return validity;
        }

        public string NewTitleID()
        {
            string id = "";
            int First = rnd.Next(1000, 9999); // creates a number between 1 and 12
            id = "US" + First.ToString();
            return id;
        }
        public string GetStoreID(string storname)
        {

            foreach (StoreViewModel store in stores)
            {
                if (store.StorName == storname)
                {
                    return store.StorID;
                }
            }
            return "000000";
        }
        public string GenerateOrderNumber()
        {

            int Value = rnd.Next(1000, 9999);
            if (ValidateOrderNumber(Value.ToString()))
            {
                return Value.ToString();
            }
            else
            {
                return GenerateOrderNumber();
            }
        }
        public bool ValidateOrderNumber(string ID)
        {
            foreach (OrderViewModel order in orders)
            {
                if (order.OrderNumber == ID)
                {
                    return false;
                }
            }
            return true;
        }
        private void NewOrder_Click(object sender, EventArgs e)
        {

            if (StoreList.SelectedItems.Count == 0)
            {
                MessageBox.Show("No Store is selected!");
            }
            else
            {
                string temp = GenerateOrderNumber();
                OrderList.Items.Add(temp);
                orders.Add(new OrderViewModel(GetStoreID(StoreList.SelectedItems[0].SubItems[0].Text.ToString()), temp, DateTime.Now.ToString(), new List<int>(), "OnInvoice", new List<string>()));
                OrderList.Items[OrderList.Items.Count - 1].Selected = true;
                OrderOnClick();
            }
        }
        public OrderViewModel getorder(string id)
        {
            foreach (OrderViewModel order in orders)
            {
                if (order.OrderNumber == id)
                {
                    return order;
                }
            }

            return default(OrderViewModel);

        }
        private void DeleteOrder_Click(object sender, EventArgs e)
        {
            if (OrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("No Order Selected");
            }
            else
            {

                bool neworder = false;
                foreach (OrderViewModel order in orders)
                {

                    if (OrderList.SelectedItems[0].SubItems[0].Text.ToString() == order.OrderNumber)
                    {
                        if (order.Qty.Count < 1)
                        {
                            neworder = true;
                        }
                    }

                }
                if (neworder)
                {
                    orders = pubs.GetAllOrders();
                    StoreOnClick();
                }
                else
                {


                    if (pubs.Remove(getorder(OrderList.SelectedItems[0].SubItems[0].Text.ToString())))
                    {
                        orders = pubs.GetAllOrders();
                        StoreOnClick();
                    }
                    else
                    {
                        MessageBox.Show("RemoveFailed");
                    }
                }
            }
        }

        private void ShiftLeft_Click(object sender, EventArgs e)
        {
            if (OrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("No Order is selected!");
            }
            else
            {



                if (CurrentList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("nothings selected!");
                }
                else
                {
                    if (CurrentList.Items.Count == 0)
                    {
                        MessageBox.Show("Theres Nothing to remove!");
                    }
                    else
                    {
                        foreach (OrderViewModel order in orders)
                        {
                            if (order.OrderNumber == OrderList.SelectedItems[0].SubItems[0].Text)
                            {
                                if (CurrentList.Items.Count == 1)
                                {
                                    pubs.Remove(order);
                                    MessageBox.Show("Order Removed");
                                    orders = pubs.GetAllOrders();
                                    StoreOnClick();
                                    button1_Click(null, null);
                                    break;
                                }
                                else
                                {
                                    order.Qty.RemoveAt(CurrentList.SelectedItems[0].Index);
                                    order.Books.RemoveAt(CurrentList.SelectedItems[0].Index);
                                    if (pubs.Update(order))
                                    {
                                        orders = pubs.GetAllOrders();
                                        OrderOnClick();
                                    }
                                    else
                                    {
                                        MessageBox.Show("RemoveFailed");
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
        public string GetBookByTitle(string title)
        {
            foreach (TitleViewModel book in books)
            {
                if (book.title == title)
                {
                    return book.titleid;
                }
            }
            return default(string);
        }
        private void ShiftRight_Click(object sender, EventArgs e)
        {
            if (StoreList.SelectedItems.Count == 0)
            {
                MessageBox.Show("No Store is selected!");
            }
            else
            {
                if (OrderList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("No Order is selected!");
                }
                else
                {
                    if (BookList.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("nothings selected!");
                    }
                    else
                    {

                        if (CurrentList.Items.Count == 0)
                        {


                            OrderViewModel order = new OrderViewModel(GetStoreID(StoreList.SelectedItems[0].SubItems[0].Text.ToString()), OrderList.SelectedItems[0].SubItems[0].Text.ToString(), DateTime.Now.ToString(), new List<int>(), "OnInvoice", new List<string>());
                            order.Qty.Add(Convert.ToInt32(Quantity.Value));
                            order.Books.Add(GetBookByTitle(BookList.SelectedItems[0].SubItems[0].Text.ToString()));
                            if (pubs.Add(order))
                            {
                                orders = pubs.GetAllOrders();
                                OrderOnClick();
                            }
                            else
                            {
                                MessageBox.Show("AddFailed");
                            }
                        }
                        else
                        {
                            OrderViewModel order = new OrderViewModel(GetStoreID(StoreList.SelectedItems[0].SubItems[0].Text.ToString()), OrderList.SelectedItems[0].SubItems[0].Text.ToString(), DateTime.Now.ToString(), new List<int>(), "OnInvoice", new List<string>());
                            order.Qty.Add(Convert.ToInt32(Quantity.Value));
                            order.Books.Add(GetBookByTitle(BookList.SelectedItems[0].SubItems[0].Text.ToString()));
                            for (int x = 0; x < CurrentList.Items.Count; x++)
                            {
                                order.Qty.Add(Convert.ToInt32(CurrentList.Items[x].SubItems[2].Text));
                                order.Books.Add(GetBookByTitle(CurrentList.Items[x].SubItems[0].Text.ToString()));
                            }

                            if (pubs.Update(order))
                            {
                                orders = pubs.GetAllOrders();
                                OrderOnClick();
                            }
                            else
                            {
                                MessageBox.Show("AddFailed");
                            }
                        }

                    }
                }
            }
        }

        private void ResetData_Click(object sender, EventArgs e)
        {

            if (pubs.Reset()) // send the IRepositoryReset signle
            {

                orders = pubs.GetAllOrders();
                StoreList.Items[0].Selected = true;
                StoreOnClick(); //refresh list.
            }
            else
            {//failed then close form.
                MessageBox.Show("Reset Failed. Make sure you are not currently accessing the database and try again. ( this includes accesing by other programs as it drops the original table.)");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clicked)
            {
                clicked = false;
                switch (comboBox1.SelectedIndex)
                {
                    case 0:

                        foreach (OrderViewModel order in orders)
                        {
                            if (order.OrderNumber == OrderList.SelectedItems[0].SubItems[0].Text)
                            {
                                order.PayTerms = "OnInvoice";
                                pubs.Update(order);
                            }

                        }

                        break;
                    case 1:
                        foreach (OrderViewModel order in orders)
                        {
                            if (order.OrderNumber == OrderList.SelectedItems[0].SubItems[0].Text)
                            {
                                order.PayTerms = "Net 30";
                                pubs.Update(order);
                            }
                        }
                        break;
                    case 2:
                        foreach (OrderViewModel order in orders)
                        {
                            if (order.OrderNumber == OrderList.SelectedItems[0].SubItems[0].Text)
                            {
                                order.PayTerms = "Net 60";
                                pubs.Update(order);
                            }
                        }
                        break;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentList.Items.Clear();
            BookList.Items.Clear();
        }









    }

}
