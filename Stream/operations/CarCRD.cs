using Stream.interfaces;
using Stream.models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Stream.operations
{
    class CarCRD : ICRD<Car>
    {
        public string path = Path.Combine(Environment.CurrentDirectory, "DataBase.dat");
        //string path = @"D:\Maksym`s\university\software\task04\BinaryStreamDB\Stream\DataBase.dat";
        public void Delete(int id)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    //while (reader.PeekChar() != -1)
                    //while (reader.BaseStream.Position != reader.BaseStream.Length)
                    while (reader.PeekChar() != -1)
                    {
                        
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Car> GetAll()
        {
            try
            {
                var cars = new List<Car>();
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {                    
                    //while (reader.PeekChar() != -1)
                    //while (reader.BaseStream.Position != reader.BaseStream.Length)
                    while (reader.PeekChar() != -1)
                    {
                        var car = new Car();
                        car.Brand = reader.ReadString();
                        car.Model = reader.ReadString();
                        car.Number = reader.ReadInt32();
                        car.OwnerId = reader.ReadInt32();
                        cars.Add(car);
                    }
                }

                return cars;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Car GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Car car)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    writer.Write(car.Brand);
                    writer.Write(car.Model);
                    writer.Write(car.Number);
                    writer.Write(car.OwnerId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
