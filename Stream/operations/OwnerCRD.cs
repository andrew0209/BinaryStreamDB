using Stream.interfaces;
using Stream.models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Stream.operations
{
    class OwnerCRD : ICRD<Owner>
    {
        public string path = Path.Combine(Environment.CurrentDirectory, "DataBase.dat");
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Owner> GetAll()
        {
            throw new NotImplementedException();
        }

        public Owner GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Owner item)
        {
            throw new NotImplementedException();
        }
    }
}
