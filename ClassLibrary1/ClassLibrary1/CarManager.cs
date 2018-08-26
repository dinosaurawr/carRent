using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    //поменять кар на айди и искать по айди машину в репо (done)
    public class CarManager
    {

        public List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate | startDate<DateTime.Now)
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
        
        public bool IsBooked(int carId, CarRepo cR, List<DateTime> datesFromUser)
        {
            Car car = cR.GetCarById(carId);

            if (datesFromUser.Intersect(car.BookedDates).ToList().Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> GetCarsNotBookedOnThisDates(CarRepo cR, List<DateTime> dates)
        {
            List<string> cars = new List<string>();
            int[] IDs = cR.GetAllIDs();
            foreach (int id in IDs)
            {
                Car car = cR.GetCarById(id);

                if (!this.IsBooked(id, cR, dates)) {
                    cars.Add($"Id:{id}\nmodel:{car.ModelName}");
                }
                else
                {
                    continue;
                }
                
            }
            return cars;
        }

        public List<DateTime> GetCrossingDates(int carId, CarRepo cR, List<DateTime> datesFromUser)
        {
            Car car = cR.GetCarById(carId);
            var crossings = datesFromUser.Intersect(car.BookedDates).ToList();

            return crossings;
        }


        public void RentCarForDates(int carId, CarRepo cR, List<DateTime> dates)
        {
            Car car = cR.GetCarById(carId);

            if (!IsBooked(carId, cR, dates))
            {
                foreach (var date in dates)
                {
                    car.BookedDates.Add(date);
                }
                Console.WriteLine("car booked");
            }
            else
            {
                List<DateTime> crossings = GetCrossingDates(carId, cR, dates);
                Console.WriteLine("Car is booked on this dates:");
                foreach (var date in crossings)
                {
                    Console.WriteLine(date.ToShortDateString());
                }
            }
        }

    }

}
