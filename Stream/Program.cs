using Stream.models;
using Stream.operations;
using Stream.database;
using System;
using System.Collections.Generic;

namespace Stream_Bynary_Task4__
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car()
            {
                Id = 5,
                Brand = "Tesla",
                Model = "Model3",
                Number = 122,
                OwnerId = 2
            };

            dbFormat format = new dbFormat();

            List<string> types = new List<string>();
            types.Add("int");
            types.Add("string");
            types.Add("string");
            types.Add("string");
            types.Add("int");
            //format.CreateTable("cars", 5, types);
            //format.ChangeFormat("cars");


            CarCRD carCRD = new CarCRD();
            carCRD.Insert(c);
            Console.WriteLine("old");
            foreach (Car car in carCRD.GetAll())
            {
                Console.WriteLine(car.Id);
                Console.WriteLine(car.Brand);
                Console.WriteLine(car.Model);
                Console.WriteLine(car.Number);
                Console.WriteLine(car.OwnerId);
                Console.WriteLine();
            }
            //carCRD.Delete(2);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("new");
            foreach (Car car in carCRD.GetAll())
            {
                Console.WriteLine(car.Id);
                Console.WriteLine(car.Brand);
                Console.WriteLine(car.Model);
                Console.WriteLine(car.Number);
                Console.WriteLine(car.OwnerId);
                Console.WriteLine();
            }

            //Car t = carCRD.GetByID(3);
            //Console.WriteLine(t.Id);
            //Console.WriteLine(t.Brand);
            //Console.WriteLine(t.Model);
            //Console.WriteLine(t.Number);
            //Console.WriteLine(t.OwnerId);
            //Console.WriteLine();

            Console.ReadLine();
        }
    }

}
