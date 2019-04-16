using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stream.models;

namespace Stream_Bynary_Task4__
{
    public class BinaryCar
    {
        
        public void Write(Car car, string path)
        {
            //string path = @"D:\Progi\C#\Stream\Stream\binar.bin";
            try
            {
                
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    
                    writer.Write(car.Brand);
                    //writer.Write("\n");
                    writer.Write(car.Model);
                    //writer.Write("\n");
                    writer.Write(car.Number);
                }
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.ReadLine();
        }
        //public void Read()
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[2];
            cars[0] = new Car("BMW", "X6", 122);
            cars[1] = new Car("Audi", "A6", 123);

            string path = @"D:\Progi\C#\Stream\Stream\binar.bin";

            try
            {
                // создаем объект BinaryWriter
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    // записываем в файл значение каждого поля структуры
                    foreach (Car c in cars)
                    {
                        
                        writer.Write(c.Brand);
                        //writer.Write("\n");
                        writer.Write(c.Model);
                        //writer.Write("\n");
                        writer.Write(c.Number);
                       
                    }
                }
                // создаем объект BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    while (reader.PeekChar() > -1)
                    {
                        string brand = reader.ReadString();
                        string model = reader.ReadString();
                        int number = reader.ReadInt32();

                        Console.WriteLine("Brand: {0}  Model: {1}  Number: {2}",
                            brand, model, number);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }

}
