using Stream.interfaces;
using Stream.models;
using System;
using System.Collections.Generic;

namespace Stream.operations
{
    class OwnerCRD : ICRD<Owner>
    {
        string path = "DataBase.dat";
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Owner> GetAll()
        {
            throw new NotImplementedException();
        }

        public Owner GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Owner item)
        {
            throw new NotImplementedException();
        }
    }
}
