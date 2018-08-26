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

        //debug method
        public void FillWithCars()
        {
            Random rnd = new Random();
            string[] carModelNames = new string[5] { "nissan", "toyota", "land rover", "tesla", "volkswagen" };

            for (int i = 1; i < 10; i++)
            {
                this.AddCarToList(i, carModelNames[rnd.Next(0, 4)]);
            }
        }
  

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

        internal List<Car> GetCarsByModel(string modelName)
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

        internal Car GetCarById(int id)
        {
            var car = carList;
            return carList.FirstOrDefault(c => c.Id == id);

        }

        internal int[] GetAllIDs()
        {
            return carList.Select(t => t.Id).ToArray();
        }

        internal void DeleteCar(Car car)
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
