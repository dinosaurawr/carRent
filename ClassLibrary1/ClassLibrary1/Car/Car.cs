using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    public class Car
    {
        public int Id { private set; get; }
        public string ModelName { private set; get; }
        public string BookedDates { get; set; }

        protected Car()
        {
        }
        //constructor
        public Car(int id, string modelname)
        {
            Id = id;
            ModelName = modelname.ToLower();
            BookedDates = "";
        }

        public List<DateTime> GetListOfDates()
        {
            if (BookedDates == null)
            {
                return new List<DateTime>();
            }
            else
            {
                return JsonConvert.DeserializeObject<List<DateTime>>(BookedDates);
            }
        }
    }
}
