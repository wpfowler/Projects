using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
   public interface ILookupValuesRepository
    {
        IEnumerable<LookupValue> GetStatesAll();
        IEnumerable<LookupValue> GetBodyStylesAll();
        IEnumerable<LookupValue> GetExteriorColorsAll();
        IEnumerable<LookupValue> GetInteriorColorsAll();
        IEnumerable<LookupValue> GetPurchaseTypeAll();
        IEnumerable<LookupValue> GetTransmissionTypesAll();
        IEnumerable<LookupValue> GetUserRolesAll();
        IEnumerable<LookupValue> GetYearsAll();

    }
}
