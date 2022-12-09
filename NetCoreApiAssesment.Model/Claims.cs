using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiAssesment.Model
{
    public class Claims
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }
        public String Date { get; set; }
        public int Vehicle_Id { get; set; }
    }
}
