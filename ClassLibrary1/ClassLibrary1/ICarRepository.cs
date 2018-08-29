using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface ICarRepository
    {
        void AddCarToList(int id, string modelName);
        void DeleteCar(int id);
        int[] GetAllIDs();
        Car GetCarById(int id);
        void Update();
    }
}
