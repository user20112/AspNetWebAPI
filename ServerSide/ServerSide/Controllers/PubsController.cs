using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository;
using Model;
namespace ServerSide.Controllers
{
    [RoutePrefix("API")]
    public class PubsController : ApiController
    {
        [HttpGet,Route("Authors")]
        public List<author>GetAllAuthors()
        {
            authorRepository Repo = new authorRepository();
            return Repo.IRepositoryFindAll();
        }
        [HttpGet,Route("Authors/{au_id}")]
        public author GetAuthorByID(string au_id)
        {
            authorRepository Repo = new authorRepository();
            return Repo.IRepositoryFindByID(au_id);
        }
        [HttpPost, Route("Authors/Add")]
        public bool IRepositoryAdd(author au)
        {
            authorRepository Repo = new authorRepository();
            return Repo.IRepositoryAdd(au);
        }
        [HttpPost, Route("Authors/Update")]
        public bool IRepositoryUpdate(author au)
        {
            authorRepository Repo = new authorRepository();
            return Repo.IRepositoryUpdate(au);
        }
        [HttpPost, Route("Authors/Remove")]
        public bool IRepositoryRemove(author au)
        {
            authorRepository Repo = new authorRepository();
            return Repo.IRepositoryRemove(au);
        }
        [HttpPost, Route("Authors/Reset")]
        public bool IRepositoryReset(author au)
        {
            authorRepository Repo = new authorRepository();
            return Repo.IRepositoryReset(au);
        }

        [HttpGet, Route("Stores")]
        public List<Store> GetAllStores()
        {
            StorRepository Repo = new StorRepository();
            return Repo.IRepositoryFindAll();
        }
        [HttpGet, Route("Stores/Orders/{id}")]
        public List<String> GetAllOrders(string id)
        {
            StorRepository Repo = new StorRepository();
            return Repo.FindallOrders(id);
        }
        [HttpGet, Route("Stores/{au_id}")]
        public Store GetStoreByID(string au_id)
        {
            StorRepository Repo = new StorRepository();
            return Repo.IRepositoryFindByID(au_id);
        }
        [HttpPost, Route("Stores/Add")]
        public bool StoresAdd(Store au)
        {
            StorRepository Repo = new StorRepository();
            return Repo.IRepositoryAdd(au);
        }
        [HttpPost, Route("Stores/Update")]
        public bool StoresUpdate(Store au)
        {
            StorRepository Repo = new StorRepository();
            return Repo.IRepositoryUpdate(au);
        }
        [HttpPost, Route("Stores/Remove")]
        public bool StoresRemove(Store au)
        {
            StorRepository Repo = new StorRepository();
            return Repo.IRepositoryRemove(au);
        }
        [HttpGet, Route("Books")]
        public List<Title> GetAllBooks()
        {
            titleRepository Repo = new titleRepository();
            return Repo.IRepositoryFindAll();
        }
        [HttpGet, Route("Books/{au_id}")]
        public Title GetBookByID(string au_id)
        {
            titleRepository Repo = new titleRepository();
            return Repo.IRepositoryFindByID(au_id);
        }
        [HttpPost, Route("Books/Add")]
        public bool BooksAdd(Title au)
        {
            titleRepository Repo = new titleRepository();
            return Repo.IRepositoryAdd(au);
        }
        [HttpPost, Route("Books/Update")]
        public bool BooksUpdate(Title au)
        {
            titleRepository Repo = new titleRepository();
            return Repo.IRepositoryUpdate(au);
        }
        [HttpPost, Route("Books/Remove")]
        public bool BooksRemove(Title au)
        {
            titleRepository Repo = new titleRepository();
            return Repo.IRepositoryRemove(au);
        }
        [HttpPost, Route("Books/ByAuthor/{au_id}")]
        public List<String> GetBooksByAuthor(string id)
        {
            titleRepository Repo = new titleRepository();
            return Repo.getBooksByAuthor(id);
        }
        [HttpPost, Route("Books/UnLink/{book_id}/{au_id}")]
        public bool BookUnlink(string book_id, string au_id)
        {
            titleRepository Repo = new titleRepository();
            return Repo.UnLink(book_id,au_id);
        }
        [HttpPost, Route("Books/Link/{book_id}/{au_id}")]
        public bool BookLink(string book_id, string au_id)
        {
            titleRepository Repo = new titleRepository();
            return Repo.Link(book_id, au_id);
        }
        [HttpGet, Route("Orders")]
        public List<Order> GetAllOrders()
        {
            OrderRepository Repo = new OrderRepository();
            return Repo.IRepositoryFindAll();
        }
        [HttpGet, Route("Orders/{au_id}")]
        public Order GetOrdersByID(string au_id)
        {
            OrderRepository Repo = new OrderRepository();
            return Repo.IRepositoryFindByID(au_id);
        }
        [HttpPost, Route("Orders/Add")]
        public bool OrdersAdd(Order au)
        {
            OrderRepository Repo = new OrderRepository();
            return Repo.IRepositoryAdd(au);
        }
        [HttpPost, Route("Orders/Update")]
        public bool OrdersUpdate(Order au)
        {
            OrderRepository Repo = new OrderRepository();
            return Repo.IRepositoryUpdate(au);
        }
        [HttpPost, Route("Orders/Remove")]
        public bool OrdersRemove(Order au)
        {
            OrderRepository Repo = new OrderRepository();
            return Repo.IRepositoryRemove(au);
        }
        [HttpPost, Route("Orders/{ordernum}/{book_id}/{quantity}")]
        public bool Ordersupdatequantity(string ordernum,string book_id, int quantity)
        {
            OrderRepository Repo = new OrderRepository();
            return Repo.UpdateOrderQuantity(ordernum,book_id, quantity);
        }

    }
}
