using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiAssesment.Model
{
    public class Vehicles
    {
        public int Id { get; set; }
        public String Brand { get; set; }
        public String Vin { get; set; }
        public String Color { get; set; }
        public int Year { get; set; }
        public int Owner_id { get; set; }
    }
}
