using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T>
    {
        List<T> IRepositoryFindAll(); //labled in explicit interface implementation as per visual c#2010 by john sharp pg 255.
        T IRepositoryFindByID(string id); //reset database to default.
        bool IRepositoryAdd(T x);//add a T to pubs
        bool IRepositoryUpdate(T x);//update an existing T in pubs
        bool IRepositoryRemove(T x);//remove an existing T in pubs


    }
}
