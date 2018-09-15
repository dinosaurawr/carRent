using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface ICarRepository
    {
        void AddCarToList(Car car);
        void DeleteCarFromList(Car car);

        Car GetCarById(int id);
        List<Car> GetAllCars();

        void Update();
    }
}
