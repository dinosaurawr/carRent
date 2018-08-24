using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    public class ConsoleHandler
    {
        public void MainMenu(CarRepo carRepo)
        {
            Console.WriteLine("1) book car \n2) exit");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                CarRenting(carRepo);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public void CarRenting(CarRepo carRepo)
        { 

            Console.WriteLine("enter start date dd.mm.yyyy");
            string input = Console.ReadLine();
            DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime startDate);

            Console.WriteLine("enter end date dd.mm.yyyy");
            input = Console.ReadLine();
            DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime endDate);

            CarManager carManager = new CarManager();

            List<DateTime> dates = carManager.GetDatesBetween(startDate, endDate);
            Console.WriteLine("your choosed dates:");
            foreach(var date in dates)
            {
                Console.WriteLine(date.ToShortDateString());
            }
            carRepo.WriteAllCars();

            Console.WriteLine("write car id:");

            int choosedId = Convert.ToInt32(Console.ReadLine());

            carManager.RentCarForDates(carRepo.GetCarById(choosedId), dates);
            Console.ReadKey();
        }
    }   
}
