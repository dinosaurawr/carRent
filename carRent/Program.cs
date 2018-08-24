using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace carRent
{
    class Console
    {
        static void Main(string[] args)
        {
            ConsoleHandler consoleHandler = new ConsoleHandler();
            CarRepo carRepo = new CarRepo();

            carRepo.AddCarToList(1, "nissan");

            consoleHandler.MainMenu(carRepo);
        }
    }
}
