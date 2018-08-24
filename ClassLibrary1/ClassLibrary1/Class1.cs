using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    public class ConsoleHandler
    {
        public void MainMenu(CarRepo carRepo)
        {
            Console.WriteLine("1) book car \n2) exit");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                CarRenting(carRepo);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public void CarRenting(CarRepo carRepo)
        { 

            Console.WriteLine("enter start date dd.mm.yyyy");
            string input = Console.ReadLine();
            DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime startDate);

            Console.WriteLine("enter end date dd.mm.yyyy");
            input = Console.ReadLine();
            DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime endDate);

            CarManager carManager = new CarManager();

            List<DateTime> dates = carManager.GetDatesBetween(startDate, endDate);
            Console.WriteLine("your choosed dates:");
            foreach(var date in dates)
            {
                Console.WriteLine(date.ToShortDateString());
            }
            carRepo.WriteAllCars();

            Console.WriteLine("write car id:");

            int choosedId = Convert.ToInt32(Console.ReadLine());

            carManager.RentCarForDates(carRepo.GetCarById(choosedId), dates);
            Console.ReadKey();
        }
    }

    public class Car
    {
        public int Id { private set; get; }
        public string ModelName { private set; get;}
        public List<DateTime> BookedDates;

        //constructor
        public Car(int id, string modelname)
        {
            BookedDates = new List<DateTime>();
            Id = id;
            ModelName = modelname.ToLower();
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

    public class CarRepo
    {
        private List<Car> CarList;
        
        public CarRepo()
        {
            CarList = new List<Car>();
        }

        public List<string> GetAllModels()
        {
            List<string> allModels = new List<string>();

            foreach(var car in CarList)
            {
                allModels.Add(car.ModelName);
            }

            return allModels;

        }

        //debug method
        public void WriteAllCars()
        {
            foreach(var car in CarList)
            {
                Console.WriteLine($"Car id: {car.Id}\nCar model name: {car.ModelName}");
            }
        }

        public List<Car> GetCarsByModel(string modelName)
        {
            List<Car> cars = new List<Car>();
            foreach (var car in CarList)
            {
                if(car.ModelName == modelName)
                {
                    cars.Add(car);
                }
                else
                {
                    continue;
                }
            }
            return cars;
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

        public void DeleteCar(Car car)
        {
            CarList.Remove(car);
        }

        public void AddCarToList(int id, string modelName)
        {
            Car car = new Car(id, modelName);
            CarList.Add(car);
        }

        public void Update()
        {

        }
    }
}
