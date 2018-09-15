using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DBRepo : ICarRepository
    {
        //car adding
        public void AddCarToList(Car car)
        {
            using (CarContext db = new CarContext())
            {
                db.Cars.Add(car);
                db.SaveChanges();
            }
        }

        //car deleting
        public void DeleteCarFromList(Car car)
        {
            using (CarContext db = new CarContext())
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }
        }

        //finding car by id
        public Car GetCarById(int id)
        {
            using (CarContext db = new CarContext())
            {
                return db.Cars.Find(id);
            }
        }

        //getting all cars
        public List<Car> GetAllCars()
        {
            using (CarContext db = new CarContext())
            {
                List<Car> cars = new List<Car>();
                foreach(var car in db.Cars)
                {
                    cars.Add(car);
                }
                return cars;
            }
        }

        //data updating
        public void Update()
        {
            using (CarContext db = new CarContext())
            {
                db.SaveChanges();
            }
        }
    }
}
