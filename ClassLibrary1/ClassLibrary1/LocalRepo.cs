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

        public void AddCarToList(Car car)
        {
            string data = this.ReadData(CarManager.path);
            List<Car> cars = this.Deserialize(data);

            cars.Add(car);

            this.UpdateData(cars, CarManager.path);
        }

        public void DeleteCarFromList(Car car)
        {
            string data = this.ReadData(CarManager.path);
            List<Car> cars = this.Deserialize(data);

            cars.Remove(car);

            this.UpdateData(cars, CarManager.path);
        }

        public Car GetCarById(int id)
        {
            string data = this.ReadData(CarManager.path);
            List<Car> cars = this.Deserialize(data);

            return cars.FirstOrDefault(c => c.Id == id);
        }

        public string ReadData(string path)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                return sr.ReadToEnd();
            }
        }

        public void UpdateData(List<Car> newList, string path)
        {
            var oldList = this.Deserialize(this.ReadData(path));

            var union = newList.Union(oldList).ToList();

            string toWrite = this.Serialize(union);

            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(toWrite);
            }
        }

        public string Serialize(List<Car> cars)
        {
            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public List<Car> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<List<Car>>(json);
        }

        
        
    }
}
