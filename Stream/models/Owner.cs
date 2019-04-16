using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream.models
{
    public class Owner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Car> Cars { get; set; }

        public Owner()
        {
            FirstName = "";
            LastName = "";
            Cars = null;
        }
        public Owner(string fn, string ln)
        {
            FirstName = fn;
            LastName = ln;
            Cars = null;
        }

        public Owner(string fn, string ln, List<Car> cars)
        {
            FirstName = fn;
            LastName = ln;
            Cars = new List<Car>(cars);
        }
    }
}
