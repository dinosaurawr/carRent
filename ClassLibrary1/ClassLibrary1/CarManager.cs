using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    public class CarManager
    {
        public List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException();
            }
            

            List<DateTime> allDates = new List<DateTime>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                allDates.Add(date.Date);
            }

            return allDates;
        }

        public List<DateTime> CheckCarForOccupyInDates(Car car, List<DateTime> datesFromUser)
        { 

            var crossings = datesFromUser.Intersect(car.BookedDates).ToList();

            return crossings;
        }


        public void RentCarForDates(Car car, List<DateTime> dates)
        {
            bool isEmpty = !CheckCarForOccupyInDates(car, dates).Any();

            if (isEmpty)
            {
                foreach (var date in dates)
                {
                    car.BookedDates.Add(date);
                }
                Console.WriteLine("car booked");
            }
            else
            {
                List<DateTime> crossings = CheckCarForOccupyInDates(car, dates);
                Console.WriteLine("Car is booked on this dates:");
                foreach (var date in crossings)
                {
                    Console.WriteLine(date.ToShortDateString());
                }
            }
        }

    }

}
