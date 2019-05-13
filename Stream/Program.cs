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
                Id = 5,
                Brand = "BMW",
                Model = "X3",
                Number = 122,
                OwnerId = 2
            };
            Owner o = new Owner()
            {
                Id = 5,
                FirstName = "Sem",
                LastName = "Smith",

            };

            // todo console menu
            // function which you can use Insert(object), Delete(id), GetAll(), GetById(id)

            CarCRD carCRD = new CarCRD("cars");
            OwnerCRD own = new OwnerCRD("owners");

            //carCRD.Insert(c);
            carCRD.Delete(5);
            foreach (Car car in carCRD.GetAll())
            {
                Console.WriteLine(car.Id);
                Console.WriteLine(car.Brand);
                Console.WriteLine(car.Model);
                Console.WriteLine(car.Number);
                Console.WriteLine(car.OwnerId);
                Console.WriteLine();
            }

            //own.Insert(o);

            foreach (Owner car in own.GetAll())
            {
                Console.WriteLine(car.Id);
                Console.WriteLine(car.FirstName);
                Console.WriteLine(car.LastName);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

}
