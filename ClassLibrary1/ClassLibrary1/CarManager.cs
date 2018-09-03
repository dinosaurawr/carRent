using Newtonsoft.Json;
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
            var car = carRepo.GetCarById(carId);
            var carDatesList = car.GetListOfDates();

            if (carDatesList.Intersect(datesFromUser).Any())
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
            List<string> carsString = new List<string>();

            foreach (var car in carRepo.GetAllCars())
            {
                if (!IsBooked(car.Id, dates))
                {
                    carsString.Add($"Id: {car.Id}\nModel name: {car.ModelName}");
                }
                else
                {
                    continue;
                }
                
            }

            return carsString;
        }

        public void RentCarForDates(int carId, List<DateTime> dates)
        {
            using (CarContext db = new CarContext())
            {
                if (!IsBooked(carId, dates))
                {
                    db.Cars.Find(carId).BookedDates += JsonConvert.SerializeObject(dates);
                    carRepo.Update();
                    db.SaveChanges();
                }
            }
        }

    }

}
