using System;

namespace Stream.models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }
        public int OwnerId { get; set; }

        public Car()
        {
            Id = 0;
            Brand = "";
            Model = "";
            Number = 0;
            OwnerId = 0;
        }
        public Car(int id, string b, string m, int n, int Oid)
        {
            Id = 0;
            Brand = b;
            Model = m;
            Number = n;
            OwnerId = Oid;
        }
        public void ConsoleRead()
        {
            Console.Write("Id: ");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Brand: ");
            Brand = Console.ReadLine();
            Console.Write("Model: ");
            Model = Console.ReadLine();
            Console.Write("Number: ");
            Number = Convert.ToInt32(Console.ReadLine());
            Console.Write("OwnerId: ");
            OwnerId = Convert.ToInt32(Console.ReadLine());
        }
    }
}
