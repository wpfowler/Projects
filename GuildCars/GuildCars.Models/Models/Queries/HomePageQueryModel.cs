using GuildCars.Models.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Models.Queries
{
    public class HomePageQueryModel
    {   //Used on Home page to pass two models to one cshtml
        public List<VehicleQueryModel> FeaturedVehicles { get; set; }
        public List<Specials> Specials { get; set; }
    }
}
