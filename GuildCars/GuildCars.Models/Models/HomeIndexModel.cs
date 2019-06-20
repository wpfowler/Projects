using GuildCars.Models.Models.Queries;
using GuildCars.Models.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Models
{
    public class HomeIndexModel
    {
       public List<VehicleViewModel> FeaturedList;
        public List<Specials> Specials;
    }
}
