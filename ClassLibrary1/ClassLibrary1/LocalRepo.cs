using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class LocalRepo
    {
        public string path { get; set; }

        public LocalRepo(string _path)
        {
            path = _path + @"\data.txt";
        }

        public void AddCarToList(Car car)
        {

            //reading and deserialize from file
            string data = this.ReadData(path);
            List<Car> cars = this.Deserialize(data);
            //adding car to a new list
            cars.Add(car);
            //rewriting old data file
            this.UpdateData(cars, path);
        }

        public void DeleteCarFromList(Car car)
        {
            //reading and deserializing to a new list
            string data = this.ReadData(path);
            List<Car> cars = this.Deserialize(data);
            //removing from a new list
            cars.Remove(car);
            //rewrite old data file
            this.UpdateData(cars, path);
        }

        public Car GetCarById(int id)
        {
            //reading and deserializing ti a list
            string data = this.ReadData(path);
            List<Car> cars = this.Deserialize(data);
            //searching for a car with specified id
            return cars.FirstOrDefault(c => c.Id == id);
        }

        public string ReadData(string path)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                if (File.Exists(path))
                {
                    return sr.ReadToEnd();
                }
                else
                {
                    var fs = File.Create(path);
                    fs.Close();
                    return sr.ReadToEnd();
                }
                
            }
        }

        public void UpdateData(List<Car> newList, string path)
        {
            //serializing list which we will write to data file
            string toWrite = this.Serialize(newList);
            var fs = File.Create(path);
            fs.Close();
            //rewriting existing or creating a new data file if not exist
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
