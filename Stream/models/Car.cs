using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream.models
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }

        public Car()
        {
            Brand = "";
            Model = "";
            Number = "";
        }
        public Car(string b, string m, int n)
        {
            Brand = b;
            Model = m;
            Number = n;
        }
    }
}
