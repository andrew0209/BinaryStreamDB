using System.Collections.Generic;
using System;

namespace Stream.models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Car> Cars { get; set; }

        public Owner()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
            Cars = null;
        }
        public Owner(int id, string fn, string ln)
        {
            Id = id;
            FirstName = fn;
            LastName = ln;
            Cars = null;
        }

        public Owner(int id, string fn, string ln, List<Car> cars)
        {
            Id = id;
            FirstName = fn;
            LastName = ln;
            Cars = new List<Car>(cars);
        }
        public void ConsoleRead()
        {
            Console.Write("Id: ");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("FirstName: ");
            FirstName = Console.ReadLine();
            Console.Write("LastName: ");
            LastName = Console.ReadLine();
        }
    }
}
