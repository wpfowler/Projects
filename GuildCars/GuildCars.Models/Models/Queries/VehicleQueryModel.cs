using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Models.Queries
{
    public class VehicleQueryModel
    {
        public int VehicleId { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public string TransmissionType { get; set; }
        public string ConditionType { get; set; }
        public string BodyStyle { get; set; }
        public string InteriorColor { get; set; }
        public string ExteriorColor { get; set; }
        public decimal? MSRP { get; set; }
        public decimal? Mileage { get; set; }
        public string ImageFileName { get; set; }
        public bool FeaturedFlag { get; set; }
        public bool SoldFlag { get; set; }
        public decimal? SalePrice { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public int MakeId { get; set; }
        public string MakeDescription { get; set; }
        public int ModelId { get; set; }
        public string ModelDescription { get; set; }
    }
}
