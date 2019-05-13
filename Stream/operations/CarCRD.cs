using Stream.interfaces;
using Stream.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Stream.operations
{
    class CarCRD : ICRD<Car>
    {
        private string TableName { get; set; }

        public CarCRD(string name)
        {
            TableName = name;
        }

        public string path = Path.Combine(Environment.CurrentDirectory, "DataBase.dat");

        public void Delete(int id)
        {
            string newPath = Path.Combine(Environment.CurrentDirectory, "NewDataBase.dat");
            try
            {
                FileStream fs = new FileStream("NewDataBase.dat", FileMode.CreateNew);
                fs.Close();
                fs.Dispose();

                bool writeToCar = false;
                int current = 0;
                var car = new Car();
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() != -1)
                    {
                        char fieldType = reader.ReadChar();
                        switch (fieldType)
                        {
                            case 'C': // char
                                Console.WriteLine(reader.ReadChar());
                                break;
                            case 'S': // string
                                if (writeToCar)
                                {
                                    switch (current)
                                    {
                                        case 1:
                                            car.Brand = reader.ReadString();
                                            current++;
                                            break;
                                        case 2:
                                            car.Model = reader.ReadString();
                                            current++;
                                            break;
                                    }
                                }
                                else
                                {
                                    reader.ReadString();
                                }
                                break;
                            case 'T': // string name of table
                                if (reader.ReadString() == TableName)
                                {
                                    writeToCar = true;
                                }
                                else
                                {
                                    writeToCar = false;
                                }
                                break;
                            case 'I': // int32
                                if (writeToCar)
                                {
                                    switch (current)
                                    {
                                        case 0:
                                            car.Id = reader.ReadInt32();
                                            current++;
                                            break;
                                        case 3:
                                            car.Number = reader.ReadInt32();
                                            current++;
                                            break;
                                        case 4:
                                            car.OwnerId = reader.ReadInt32();
                                            current++;
                                            break;
                                    }
                                }
                                else
                                {
                                    reader.ReadInt32();
                                }
                                break;
                            case 'E': // string end of table
                                if (reader.ReadString() == "%end%")
                                {
                                    if (car.Id != id)
                                    {
                                        Insert(car, newPath);
                                        car = new Car();
                                    }
                                }
                                else
                                {
                                    throw new Exception("Unexpected error");
                                }
                                current = 0;
                                break;
                            default: // unexpected!
                                throw new Exception("Unexpected field type");
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
                bool writeToCar = false;
                int current = 0;
                var cars = new List<Car>();
                var car = new Car();
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    //while (reader.BaseStream.Position != reader.BaseStream.Length)
                    while (reader.PeekChar() != -1)
                    {
                        char fieldType = reader.ReadChar();
                        switch (fieldType)
                        {
                            case 'C': // char
                                Console.WriteLine(reader.ReadChar());
                                break;
                            case 'S': // string
                                if (writeToCar)
                                {
                                    switch (current)
                                    {
                                        case 1:
                                            car.Brand = reader.ReadString();
                                            current++;
                                            break;
                                        case 2:
                                            car.Model = reader.ReadString();
                                            current++;
                                            break;
                                    }
                                }
                                else
                                {
                                    reader.ReadString();
                                }
                                break;
                            case 'T': // string name of table
                                if (reader.ReadString() == TableName)
                                {
                                    writeToCar = true;
                                }
                                else
                                {
                                    writeToCar = false;
                                }
                                break;
                            case 'I': // int32
                                if (writeToCar)
                                {
                                    switch (current)
                                    {
                                        case 0:
                                            car.Id = reader.ReadInt32();
                                            current++;
                                            break;
                                        case 3:
                                            car.Number = reader.ReadInt32();
                                            current++;
                                            break;
                                        case 4:
                                            car.OwnerId = reader.ReadInt32();
                                            current++;
                                            break;
                                    }
                                }
                                else
                                {
                                    reader.ReadInt32();
                                }
                                break;
                            case 'E': // string end of table
                                if (reader.ReadString() == "%end%")
                                {
                                    if (writeToCar)
                                    {
                                        cars.Add(car);
                                        car = new Car();
                                    }
                                }
                                else
                                {
                                    throw new Exception("Unexpected error");
                                }
                                current = 0;
                                break;
                            default: // unexpected!
                                throw new Exception("Unexpected field type");
                        }
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
                bool writeToCar = false;
                int current = 0;
                var car = new Car();
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() != -1)
                    {
                        char fieldType = reader.ReadChar();
                        switch (fieldType)
                        {
                            case 'C': // char
                                Console.WriteLine(reader.ReadChar());
                                break;
                            case 'S': // string
                                if (writeToCar)
                                {
                                    switch (current)
                                    {
                                        case 1:
                                            car.Brand = reader.ReadString();
                                            current++;
                                            break;
                                        case 2:
                                            car.Model = reader.ReadString();
                                            current++;
                                            break;
                                    }
                                }
                                else
                                {
                                    reader.ReadString();
                                }
                                break;
                            case 'T': // string name of table
                                if (reader.ReadString() == TableName)
                                {
                                    writeToCar = true;
                                }
                                else
                                {
                                    writeToCar = false;
                                }
                                break;
                            case 'I': // int32
                                if (writeToCar)
                                {
                                    switch (current)
                                    {
                                        case 0:
                                            car.Id = reader.ReadInt32();
                                            current++;
                                            break;
                                        case 3:
                                            car.Number = reader.ReadInt32();
                                            current++;
                                            break;
                                        case 4:
                                            car.OwnerId = reader.ReadInt32();
                                            current++;
                                            break;
                                    }
                                }
                                else
                                {
                                    reader.ReadInt32();
                                }
                                break;
                            case 'E': // string end of table
                                if (reader.ReadString() == "%end%")
                                {
                                    if (car.Id == id)
                                    {
                                        return car;
                                    }
                                }
                                else
                                {
                                    throw new Exception("Unexpected error");
                                }
                                current = 0;
                                break;
                            default: // unexpected!
                                throw new Exception("Unexpected field type");
                        }
                    }
                }


                return new Car(); //todo need return message not found
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
                    writer.Write('T');
                    writer.Write(TableName);
                    writer.Write('I');
                    writer.Write(car.Id);
                    writer.Write('S');
                    writer.Write(car.Brand);
                    writer.Write('S');
                    writer.Write(car.Model);
                    writer.Write('I');
                    writer.Write(car.Number);
                    writer.Write('I');
                    writer.Write(car.OwnerId);
                    writer.Write('E');
                    writer.Write("%end%");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //use for deleting item
        public void Insert(Car car, string path)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    writer.Write('T');
                    writer.Write(TableName);
                    writer.Write('I');
                    writer.Write(car.Id);
                    writer.Write('S');
                    writer.Write(car.Brand);
                    writer.Write('S');
                    writer.Write(car.Model);
                    writer.Write('I');
                    writer.Write(car.Number);
                    writer.Write('I');
                    writer.Write(car.OwnerId);
                    writer.Write('E');
                    writer.Write("%end%");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
