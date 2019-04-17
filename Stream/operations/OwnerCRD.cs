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
            string newPath = Path.Combine(Environment.CurrentDirectory, "NewDataBase.dat");
            try
            {
                FileStream fs = new FileStream("NewDataBase.dat", FileMode.CreateNew);
                fs.Close();
                fs.Dispose();
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    reader.Read();
                    while (reader.PeekChar() != -1)
                    {
                        //var car = new Owner();
                        //car.Id = reader.ReadInt32();
                        //car.Brand = reader.ReadString();
                        //car.Model = reader.ReadString();
                        //car.Number = reader.ReadInt32();
                        //car.OwnerId = reader.ReadInt32();
                        //if (car.Id != id)
                        //{
                        //    Insert(car, newPath);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                File.Delete(Path.Combine(Environment.CurrentDirectory, "backup.dat"));
                File.Move("DataBase.dat", "backup.dat");
                File.Delete(path);
                File.Move("NewDataBase.dat", "DataBase.dat");
                File.Delete(newPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
