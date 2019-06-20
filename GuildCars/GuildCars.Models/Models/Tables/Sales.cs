using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Models.Tables
{
    public class Sales
    {
        public int SalesId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string PurchaseType { get; set; }
        public string UserId { get; set; }
        public int VehicleId { get; set; }
    }
}
