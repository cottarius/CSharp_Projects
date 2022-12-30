using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Database
{
    internal class Data
    {
        public int carID { get; set; }
        public string carBrand { get; set; }
        public string carModel { get; set; }
        public string carColor { get; set; }
        public int release { get; set; }

        public int customerId { get; set; }
        public string customerLastName { get; set; }
        public string customerFirstName { get; set; }
        public string customerBorn { get; set; }
        public string customerPhone { get; set; }
        public int customer_carID { get; set; }
    }
}
