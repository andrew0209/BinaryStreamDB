using Stream.models;
using Stream.operations;
using System;

namespace Stream_Bynary_Task4__
{
    class Program
    {
        public static void OwnMenu()
        {
            OwnerCRD own = new OwnerCRD("owners");
            Console.WriteLine("I - Insert");
            Console.WriteLine("S - Select");
            Console.WriteLine("D - Delete");
            //Console.WriteLine("E - Edit");
            Console.Write("Input operation: ");
            string op = Console.ReadLine();
            switch (op)
            {
                case "i":
                    Console.Clear();
                    Owner owner = new Owner();
                    owner.ConsoleRead();
                    own.Insert(owner);
                    Console.Clear();
                    OwnMenu();
                    break;
                case "d":
                    Console.Clear();
                    foreach (Owner o in own.GetAll())
                    {
                        Console.WriteLine(o.Id);
                        Console.WriteLine(o.FirstName);
                        Console.WriteLine(o.LastName);
                        Console.WriteLine();
                    }
                    Console.Write("Input id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    own.Delete(id);
                    Console.Clear();
                    OwnMenu();
                    break;
                
                case "s":
                    Console.Clear();
                    foreach (Owner o in own.GetAll())
                    {
                        Console.WriteLine(o.Id);
                        Console.WriteLine(o.FirstName);
                        Console.WriteLine(o.LastName);
                        Console.WriteLine();
                    }
                    OwnMenu();
                    break;
                case "q":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Error");
                    Console.Clear();
                    OwnMenu();
                    break;

            }

        }
        public static void CarMenu()
        {
            CarCRD cRD = new CarCRD("cars");
            Console.WriteLine("I - Insert");
            Console.WriteLine("S - Select");
            Console.WriteLine("D - Delete");
            //Console.WriteLine("E - Edit");
            Console.Write("Input operation: ");
            string op = Console.ReadLine();
            switch (op)
            {
                case "i":
                    Console.Clear();
                    Car car = new Car();
                    car.ConsoleRead();
                    cRD.Insert(car);
                    Console.Clear();
                    CarMenu();
                    break;
                case "d":
                    Console.Clear();
                    foreach (Car c in cRD.GetAll())
                    {
                        Console.WriteLine(c.Id);
                        Console.WriteLine(c.Brand);
                        Console.WriteLine(c.Model);
                        Console.WriteLine(c.Number);
                        Console.WriteLine(c.OwnerId);
                        Console.WriteLine();
                    }
                    Console.Write("Input id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    cRD.Delete(id);
                    Console.Clear();
                    CarMenu();
                    break;

                case "s":
                    Console.Clear();
                    foreach (Car c in cRD.GetAll())
                    {
                        Console.WriteLine(c.Id);
                        Console.WriteLine(c.Brand);
                        Console.WriteLine(c.Model);
                        Console.WriteLine(c.Number);
                        Console.WriteLine(c.OwnerId);
                        Console.WriteLine();
                    }
                    CarMenu();
                    break;
                case "q":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Error");
                    Console.Clear();
                    CarMenu();
                    break;

            }

        }
        public static void Menu()
        {
            Console.WriteLine("C - Cars");
            Console.WriteLine("O - Owners");
            
            Console.Write("Input name of table: ");
            string name = Console.ReadLine();
            
            
            switch (name)
            {
                case "c":
                    Console.Clear();
                    CarMenu();
                    break;
                case "o":
                    Console.Clear();
                    OwnMenu();
                    break;

                
                default:
                    Console.WriteLine("Error");
                    Console.Clear();
                    CarMenu();
                    break;

            }

        }
        static void Main(string[] args)
        {

            //Car c = new Car()
            //{
            //    Id = 6,
            //    Brand = "Tesla",
            //    Model = "Model3",
            //    Number = 122,
            //    OwnerId = 2
            //};
            //Owner o = new Owner()
            //{
            //    Id = 8,
            //    FirstName = "Sem",
            //    LastName = "Smith",

            //};

            //// todo console menu
            //// function which you can use Insert(object), Delete(id), GetAll(), GetById(id)

            //CarCRD carCRD = new CarCRD("cars");
            //OwnerCRD own = new OwnerCRD("owners");

            //carCRD.Insert(c);

            ////carCRD.Delete(6);
            //foreach (Car car in carCRD.GetAll())
            //{
            //    Console.WriteLine(car.Id);
            //    Console.WriteLine(car.Brand);
            //    Console.WriteLine(car.Model);
            //    Console.WriteLine(car.Number);
            //    Console.WriteLine(car.OwnerId);
            //    Console.WriteLine();
            //}

            ////own.Insert(o);
            ////own.Delete(8);

            //foreach (Owner car in own.GetAll())
            //{
            //    Console.WriteLine(car.Id);
            //    Console.WriteLine(car.FirstName);
            //    Console.WriteLine(car.LastName);
            //    Console.WriteLine();
            //}
            Menu();
            Console.ReadLine();
        }
    }

}
