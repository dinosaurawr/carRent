using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class LocalRepo : ICarRepository
    {
        private readonly string path = @"C:\Users\Alexander\Desktop\cars\ClassLibrary1\ClassLibrary1\data.txt";

        public void AddCarToList(int id, string modelName)
        {
            List<Car> cars = DeserializeAndGetList();
            cars.Add(new Car(id, modelName));
            this.SerializeAndWrite(cars);
        }

        public void DeleteCar(int id)
        {
            List<Car> cars = DeserializeAndGetList();
            cars.Remove(this.GetCarById(id));
            this.SerializeAndWrite(cars);
        }

        public Car GetCarById(int id)
        {
            return this.DeserializeAndGetList().FirstOrDefault(c => c.Id == id);
        }

        public int[] GetAllIDs()
        {
            return this.DeserializeAndGetList().Select(t => t.Id).ToArray();
        }

        public void SerializeAndWrite(List<Car> cars)
        {
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(JsonConvert.SerializeObject(cars));
            }
        }

        public List<Car> DeserializeAndGetList()
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(sr.ReadToEnd());

                return cars;
            }
  
        }

        public void Update(Car car)
        {
            List<Car> cars = this.DeserializeAndGetList();
            Car toReplace = cars.FirstOrDefault(c => c.Id == car.Id);
            toReplace.BookedDates = car.BookedDates;
        }
    }
}
