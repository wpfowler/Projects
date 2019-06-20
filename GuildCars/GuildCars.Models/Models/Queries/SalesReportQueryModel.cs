using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Models.Queries
{
    public class SalesReportQueryModel
    {
        public string User { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalVehicles { get; set; }
    }
}
