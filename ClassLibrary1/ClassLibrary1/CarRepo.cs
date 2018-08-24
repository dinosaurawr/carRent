using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
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

            foreach (var car in CarList)
            {
                allModels.Add(car.ModelName);
            }

            return allModels;

        }

        public void WriteAllCars()
        {
            foreach (var car in CarList)
            {
                Console.WriteLine($"Car id: {car.Id}\nCar model name: {car.ModelName}");
            }
        }

        public List<Car> GetCarsByModel(string modelName)
        {
            List<Car> cars = new List<Car>();
            foreach (var car in CarList)
            {
                if (car.ModelName == modelName)
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
