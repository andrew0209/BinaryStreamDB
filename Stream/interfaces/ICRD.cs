using System.Collections.Generic;

namespace Stream.interfaces
{
    interface ICRD<T> where T : class
    {
        List<T> GetAll();
        T GetByID(long id);
        void Insert(T item);
        void Delete(long id);
    }
}
