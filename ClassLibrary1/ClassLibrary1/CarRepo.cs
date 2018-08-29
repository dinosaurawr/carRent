using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class CarRepo : ICarRepository
    {
        private List<Car> carList;

        //debug method
        //public void FillWithCars()
        //{
        //    Random rnd = new Random();
        //    string[] carModelNames = new string[5] { "nissan", "toyota", "land rover", "tesla", "volkswagen" };

        //    for (int i = 1; i < 10; i++)
        //    {
        //        this.AddCarToList(i, carModelNames[rnd.Next(0, 4)]);
        //    }
        //}


        public CarRepo()
        {
            carList = new List<Car>();
        }

        public Car GetCarById(int id)
        {
            var car = carList;
            return carList.FirstOrDefault(c => c.Id == id);

        }

        public int[] GetAllIDs()
        {
            return carList.Select(t => t.Id).ToArray();
        }

        public void DeleteCar(int id)
        {   
            carList.Remove(this.GetCarById(id));
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
