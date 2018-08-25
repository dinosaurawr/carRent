using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class CarRepo
    {
        private List<Car> carList;

        public CarRepo()
        {
            carList = new List<Car>();
        }

        public List<string> GetAllModels()
        {
            List<string> allModels = new List<string>();

            foreach (var car in carList)
            {
                allModels.Add(car.ModelName);
            }

            return allModels;

        }

        public void WriteAllCars()
        {
            foreach (var car in carList)
            {
                Console.WriteLine($"Car id: {car.Id}\nCar model name: {car.ModelName}");
            }
        }

        public List<Car> GetCarsByModel(string modelName)
        {
            List<Car> cars = new List<Car>();
            foreach (var car in carList)
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
            var car = carList;
            return carList.FirstOrDefault(c => c.Id == id);

        }

        public void DeleteCar(Car car)
        {
            carList.Remove(car);
        }

        public void AddCarToList(int id, string modelName)
        {
            Car car = new Car(id, modelName);
            carList.Add(car);
        }

        public void Update()
        {

        }
    }
}
