using System.Collections.Generic;
using System;

using Repository;
using Model;

namespace PubsService
{
    public class authorsService
    {
        authorRepository AuthorRepository;
        titleRepository TitleRepository;
        StorRepository StorRepository;
        OrderRepository OrderRepository;


        public authorsService(titleRepository t, authorRepository a, OrderRepository o, StorRepository s)
        {
            StorRepository = s;
            OrderRepository = o;
            AuthorRepository = a;
            TitleRepository = t;
        }
        public authorsService()
        {
            StorRepository = new StorRepository();
            OrderRepository = new OrderRepository();
            AuthorRepository = new authorRepository();
            TitleRepository = new titleRepository();
        }
        public List<AuthorViewModel> GetAllAuthors()
        {
            List<AuthorViewModel> authors = new List<AuthorViewModel>();
            List<author> lstAuthors;

            lstAuthors = AuthorRepository.IRepositoryFindAll();// get all authors
            if (lstAuthors == null)
            {
                return null;
            }
            else
            {

                foreach (author au in lstAuthors)//add authors from lower class to upper class
                {

                    authors.Add(new AuthorViewModel(au.id,
                        au.FirstName, au.LastName, au.phone, au.address, au.city, au.state, au.zip, au.contract));
                }

                return authors;// return upper class

            }
        } //get all authors
        public List<TitleViewModel> GetAllBooks()
        {
            int x = 0;
            List<Title> Titles;
            List<TitleViewModel> titles = new List<TitleViewModel>();
            Titles = TitleRepository.IRepositoryFindAll();

            foreach (Title book in Titles)
            {//string titleid, string title, string type, Decimal? price, DateTime? pubdate, PublisherViewModel publisher, Decimal? advance, int? royalty, int? tyd_sales, string notes
                //id name  state country city
                PublisherViewModel publisher = new PublisherViewModel(book.publisher.pubid, book.publisher.pub, book.publisher.state, book.publisher.country, book.publisher._city);
                titles.Add(new TitleViewModel(book.titleid, book.title, book.type, book.price, book.pubdate, publisher, book.advance, book.royalty, book.tyd_sales, book.notes));

                x++;
            }
            return titles;
        }//get all books
        public List<OrderViewModel> GetAllOrders()
        {
            int x = 0;
            List<Order> orders;
            List<OrderViewModel> Orders = new List<OrderViewModel>();
            orders = OrderRepository.IRepositoryFindAll();

            foreach (Order order in orders)
            {//string titleid, string title, string type, Decimal? price, DateTime? pubdate, PublisherViewModel publisher, Decimal? advance, int? royalty, int? tyd_sales, string notes
                //id name  state country city
                Orders.Add(new OrderViewModel(order.StorID, order.OrderNumber, order.Date.ToString(),order.Qty,order.PayTerms,order.Books));

                x++;
            }
            return Orders;
        }//get all books
        public List<StoreViewModel> GetAllStores()
        {
            int x = 0;
            List<Store> stores;
            List<StoreViewModel> Stores = new List<StoreViewModel>();
            stores = StorRepository.IRepositoryFindAll();

            foreach (Store store in stores)
            {//string titleid, string title, string type, Decimal? price, DateTime? pubdate, PublisherViewModel publisher, Decimal? advance, int? royalty, int? tyd_sales, string notes
                //id name  state country city
                
                Stores.Add(new StoreViewModel(store.StorID,store.StorName,store.Address,store.City,store.State,store.Zip));

                x++;
            }
            return Stores;
        }//get all books
        public bool Update(AuthorViewModel au)
        {
            bool temp = false;
            if (au.contract == "yes")
            {
                temp = true;
            }

            author AU = new author(au.id,
                    au.FirstName, au.LastName, au.phone, au.address, au.city, au.state, au.zip, temp);

            return AuthorRepository.IRepositoryUpdate(AU);
        }//update author
        public bool Update(TitleViewModel book)
        {

            Title Book = new Title(book.titleid, book.title, book.type, Convert.ToDecimal(book.price), Convert.ToDateTime(book.pubdate), new Publisher(book.publisher.pubid, book.publisher.pub, book.publisher.state, book.publisher.country, book.publisher._city), Convert.ToDecimal(book.advance), Convert.ToInt32(book.royalty), Convert.ToInt32(book.tyd_sales), book.notes);
            return TitleRepository.IRepositoryUpdate(Book);
        }//update book
        public bool Update(OrderViewModel x)
        {

            return OrderRepository.IRepositoryUpdate(new Order(x.StorID,x.OrderNumber,Convert.ToDateTime(x.Date),x.Qty,x.PayTerms,x.Books));
        }//update book
        public bool Remove(AuthorViewModel au)
        {
            bool temp = false;
            if (au.contract == "yes")
            {
                temp = true;
            }

            author AU = new author(au.id,
                    au.FirstName, au.LastName, au.phone, au.address, au.city, au.state, au.zip, temp);

            return AuthorRepository.IRepositoryRemove(AU);

        }// remove author
        public bool Remove(TitleViewModel book)
        {
            Title Book = new Title(book.titleid, book.title, book.type, Convert.ToDecimal(book.price), Convert.ToDateTime(book.pubdate), new Publisher(book.publisher.pubid, book.publisher.pub, book.publisher.state, book.publisher.country, book.publisher._city), Convert.ToDecimal(book.advance), Convert.ToInt32(book.royalty), Convert.ToInt32(book.tyd_sales), book.notes);

            return TitleRepository.IRepositoryRemove(Book);

        }//remove book
        public bool Remove(OrderViewModel x)
        {
            return OrderRepository.IRepositoryRemove(new Order(x.StorID,x.OrderNumber,Convert.ToDateTime(x.Date),x.Qty,x.PayTerms,x.Books));

        }//remove book
        public bool Add(AuthorViewModel au)
        {
            bool temp = false;
            if (au.contract == "yes")
            {
                temp = true;
            }

            author AU = new author(au.id,
                    au.FirstName, au.LastName, au.phone, au.address, au.city, au.state, au.zip, temp);

            return AuthorRepository.IRepositoryAdd(AU);
        }//add author
        public bool Add(TitleViewModel book)
        {
            Title Book = new Title(book.titleid, book.title, book.type, Convert.ToDecimal(book.price), Convert.ToDateTime(book.pubdate), new Publisher(book.publisher.pubid, book.publisher.pub, book.publisher.state, book.publisher.country, book.publisher._city), Convert.ToDecimal(book.advance), Convert.ToInt32(book.royalty), Convert.ToInt32(book.tyd_sales), book.notes);

            return TitleRepository.IRepositoryAdd(Book);
        }//add book
        public bool Add(OrderViewModel x)
        {
            return OrderRepository.IRepositoryAdd(new Order(x.StorID, x.OrderNumber, Convert.ToDateTime(x.Date), x.Qty, x.PayTerms, x.Books));
        }
        public bool Reset()
        {
            author AU = new author("",
                    "", "", "", "", "", "", "", true); // important side note if this is true it executes at pubs level if false at master.

            return AuthorRepository.IRepositoryReset(AU);
        } //reset database.
        public TitleViewModel FindByID(string book)
        {

            Title Book = TitleRepository.IRepositoryFindByID(book);
            return new TitleViewModel(Book.titleid, Book.title, Book.type, Book.price, Book.pubdate, new PublisherViewModel(Book.publisher.pubid, Book.publisher.pub, Book.publisher.state, Book.publisher.country, Book.publisher._city), Book.advance, Book.royalty, Book.tyd_sales, Book.notes);
        } // find book by id
        public List<string> getBooksByAuthor(string au_id)
        {
            return TitleRepository.getBooksByAuthor(au_id);
        }//get all books for author
        public bool Link(string Book, string au)
        {
            return TitleRepository.Link(Book, au);
        }// link a book and author
        public bool UnLink(string Book, string au)
        {
            return TitleRepository.UnLink(Book, au);
        }// unlink a book and author.
        public List<string> FindOrdersByStore(string id)
        {
            return StorRepository.FindallOrders(id);
        }
        public bool UpdateOrderQuantity(string ordernum,string titleid,int quantity)
        {
            return OrderRepository.UpdateOrderQuantity(ordernum, titleid, quantity);
        }
    }
}

