using Stream.models;
using Stream.operations;
using System;

namespace Stream_Bynary_Task4__
{
    class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[2];
            cars[0] = new Car("BMW", "X6", 122, 0);
            cars[1] = new Car("Audi", "A6", 123, 0);

            Car c = new Car()
            {
                Brand = "Tesla",
                Model = "Model3",
                Number = 122,
                OwnerId = 0
            };

            CarCRD carCRD = new CarCRD();
            carCRD.Insert(c);
            foreach (Car car in carCRD.GetAll())
            {
                Console.WriteLine(car.Model);

            }

            Console.ReadLine();
        }
    }

}
