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
        private readonly ICarRepository carRepo;
        public CarManager(ICarRepository repo)
        {
            carRepo = repo;
        }

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
        
        public bool IsBooked(int carId, List<DateTime> datesFromUser)
        {
            Car car = carRepo.GetCarById(carId);

            if (datesFromUser.Intersect(car.BookedDates).ToList().Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> GetCarsNotBookedOnThisDates(List<DateTime> dates)
        {
            List<string> cars = new List<string>();
            int[] IDs = carRepo.GetAllIDs();
            foreach (int id in IDs)
            {
                Car car = carRepo.GetCarById(id);

                if (!this.IsBooked(id, dates)) {
                    cars.Add($"Id:{id}\nmodel:{car.ModelName}");
                }
                else
                {
                    continue;
                }
                
            }
            return cars;
        }

        public List<DateTime> GetCrossingDates(int carId, List<DateTime> datesFromUser)
        {
            Car car = carRepo.GetCarById(carId);
            var crossings = datesFromUser.Intersect(car.BookedDates).ToList();

            return crossings;
        }


        public void RentCarForDates(int carId, List<DateTime> dates)
        {
             var car = carRepo.GetCarById(carId);

            if (!IsBooked(carId, dates))
            {
                foreach (var date in dates)
                {
                    car.BookedDates.Add(date);
                }
                carRepo.Update(car);
                Console.WriteLine("car booked");
            }
            else
            {
                List<DateTime> crossings = GetCrossingDates(carId, dates);
                Console.WriteLine("Car is booked on this dates:");
                foreach (var date in crossings)
                {
                    Console.WriteLine(date.ToShortDateString());
                }
            }
        }

    }

}
