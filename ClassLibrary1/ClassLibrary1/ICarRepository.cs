using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface ICarRepository
    {
        void AddCarToList(Car car);
        void DeleteCarFromList(Car car);

        Car GetCarById(int id);

        string ReadData(string path);
        void UpdateData(List<Car> newList, string path);

        string Serialize(List<Car> cars);
        List<Car> Deserialize(string json);
    }
}
