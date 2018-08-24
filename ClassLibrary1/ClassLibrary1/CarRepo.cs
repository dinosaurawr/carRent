using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class CarRepo
    {
        private List<Car> сarList;

        public CarRepo()
        {
            сarList = new List<Car>();
        }

        public List<string> GetAllModels()
        {
            List<string> allModels = new List<string>();

            foreach (var car in сarList)
            {
                allModels.Add(car.ModelName);
            }

            return allModels;

        }

        public void WriteAllCars()
        {
            foreach (var car in сarList)
            {
                Console.WriteLine($"Car id: {car.Id}\nCar model name: {car.ModelName}");
            }
        }

        public List<Car> GetCarsByModel(string modelName)
        {
            List<Car> cars = new List<Car>();
            foreach (var car in сarList)
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
            var car = ca
            return carList.FirstOrDefault(c => c.Id == id);

        }

        public void DeleteCar(Car car)
        {
            сarList.Remove(car);
        }

        public void AddCarToList(int id, string modelName)
        {
            Car car = new Car(id, modelName);
            сarList.Add(car);
        }

        public void Update()
        {

        }
    }
}
