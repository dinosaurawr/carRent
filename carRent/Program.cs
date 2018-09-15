using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Reflection;

namespace carRent
{
    class MainApp
    {
        static void Main(string[] args)
        {
            ICarRepository carRepo = new DBRepo();
            CarManager carManager = new CarManager(carRepo);
            do
            {
                    Console.WriteLine("1)book car\n2)exit");
                    int response = Convert.ToInt32(Console.ReadLine());

                if (response == 2)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("enter start date (dd.mm.yyyy)");
                    DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    Console.WriteLine("enter end date (dd.mm.yyyy)");
                    DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    List<DateTime> dates = carManager.GetDatesBetween(startDate, endDate).ToList();
                    Console.WriteLine("cars that not booked on this dates (enter car ID):");
                    foreach (string car in carManager.GetCarsNotBookedOnThisDates(dates))
                    {
                        Console.WriteLine(car);
                    }
                    response = Convert.ToInt32(Console.ReadLine());
                    carManager.RentCarForDates(response, dates);

                }
            } while (true);

            
            
        }
    }
}
