using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Car
    {
        public int Id { private set; get; }
        public string ModelName { private set; get;}
        public List<DateTime> BookedDates;

        //constructor
        public Car(int id, string modelname)
        {
            Id = id;
            ModelName = modelname;
        }

    }

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
                    if(date == dateOccupied)
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
                Console.WriteLine("car booked");
            }
            else
            {
                List<DateTime> crossings = CheckCarForOccupyInDates(car, dates);
                Console.WriteLine("Car is booked on this dates:");
                foreach (var date in dates)
                {
                    Console.WriteLine(date.ToShortDateString());
                }
            }
        }

    }

    public class CarRepo
    {
        private List<Car> CarList;
        
        public CarRepo()
        {
            CarList = new List<Car>();
        }

        public Car GetCarById(int id)
        {
            foreach (Car car in CarList)
            {
                if (car.Id == id)
                {
                    return car;
                }
            }

            return null;
        }

        public void AddCarToList(int id, string modelName)
        {
            
        }

    }
}
