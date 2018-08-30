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

        public static string path = @"C:\Users\Alexander\Desktop\cars\ClassLibrary1\ClassLibrary1\data.txt";
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
            List<string> carsString = new List<string>();

            foreach (var car in carRepo.Deserialize(carRepo.ReadData(path)))
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
            List<Car> cars = carRepo.Deserialize(carRepo.ReadData(path));
            Car bookedCar = carRepo.GetCarById(carId);

            foreach (var car in cars)
            {
                if (car.Id == bookedCar.Id)
                {
                    foreach(var date in dates)
                    {
                        car.BookedDates.Add(date);
                    }
                }
            }

            carRepo.UpdateData(carRepo.Serialize(cars), path);
        }

    }

}
