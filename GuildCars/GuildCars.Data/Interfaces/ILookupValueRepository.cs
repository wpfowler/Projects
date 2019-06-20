using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ILookupValueRepository
    {
        IEnumerable<LookupValue> GetBodyStyles();
        IEnumerable<LookupValue> GetExteriorColor();
        IEnumerable<LookupValue> GetInteriorColor();
        IEnumerable<LookupValue> GetPrices();
        IEnumerable<LookupValue> GetPurchaseTypes();
        IEnumerable<LookupValue> GetStates();
        IEnumerable<LookupValue> GetTransmissionTypes();
        IEnumerable<LookupValue> GetUserRoles();
        IEnumerable<LookupValue> GetYears();
        IEnumerable<LookupValue> GetCondition();
    }
}
