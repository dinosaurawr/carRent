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
                return null;
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
            List<DateTime> crossings = new List<DateTime>();

            foreach (var date in datesFromUser)
            {
                foreach (var dateOccupied in car.BookedDates)
                {
                    if (date == dateOccupied)
                    {
                        crossings.Add(date);
                    }
                }
            }

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
