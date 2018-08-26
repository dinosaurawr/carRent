using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    internal class Car
    {
        public int Id { private set; get; }
        public string ModelName { private set; get; }
        public List<DateTime> BookedDates;

        //constructor
        public Car(int id, string modelname)
        {
            BookedDates = new List<DateTime>();
            Id = id;
            ModelName = modelname.ToLower();
        }

    }
}
