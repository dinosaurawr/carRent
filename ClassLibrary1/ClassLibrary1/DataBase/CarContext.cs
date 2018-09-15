using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class CarContext : DbContext
    {
        public CarContext() : base("DbConnection")
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
