using ClassLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTests
{
    [TestFixture]
    public class CarManagerTest
    {
        [Test]
        public void IsBooked_CarWithoutDatesAndUserDates_ReturnsFalse()
        {
            //arrange 
            ICarRepository carRepository = new DBRepo();
            CarManager cm = new CarManager(carRepository);
            var testCar = new Car(1, "testCar");
            carRepository.AddCarToList(testCar);
            List<DateTime> dateFromUser = new List<DateTime>();
            dateFromUser.Add(DateTime.Now);

            //act
            bool result = cm.IsBooked()
        }
    }
}
