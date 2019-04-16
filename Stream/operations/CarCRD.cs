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
                    while (reader.PeekChar() != -1)
                    {
                        var car = new Car();
                        car.Id = reader.ReadInt32();
                        car.Brand = reader.ReadString();
                        car.Model = reader.ReadString();
                        car.Number = reader.ReadInt32();
                        car.OwnerId = reader.ReadInt32();
                        if (car.Id != id)
                        {
                            Insert(car, newPath);
                        }
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

        public List<Car> GetAll()
        {
            try
            {
                var cars = new List<Car>();
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {                    
                    //while (reader.BaseStream.Position != reader.BaseStream.Length)
                    while (reader.PeekChar() != -1)
                    {
                        var car = new Car();
                        car.Id = reader.ReadInt32();
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
            try
            {
                var car = new Car();
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {                 
                    while (reader.PeekChar() != -1)
                    {
                        
                        car.Id = reader.ReadInt32();
                        car.Brand = reader.ReadString();
                        car.Model = reader.ReadString();
                        car.Number = reader.ReadInt32();
                        car.OwnerId = reader.ReadInt32();
                        if (car.Id == id)
                        {                            
                            break;
                        }
                    }
                }

                return car;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insert(Car car)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    writer.Write(car.Id);
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

        public void Insert(Car car, string path)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    writer.Write(car.Id);
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
