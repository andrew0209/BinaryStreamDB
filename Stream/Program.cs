using Stream.models;
using Stream.operations;
using System;

namespace Stream_Bynary_Task4__
{
    class Program
    {
        static void Main(string[] args)
        {

            Car c = new Car()
            {
                Id = 4,
                Brand = "Tesla",
                Model = "Model3",
                Number = 122,
                OwnerId = 2
            };

            CarCRD carCRD = new CarCRD();
            //carCRD.Insert(c);
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
            carCRD.Delete(4);
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

            Console.ReadLine();
        }
    }

}
