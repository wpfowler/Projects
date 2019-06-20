using GuildCars.Data.Interfaces;
using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories
{
    public class LookupValuesRepository : ILookupValuesRepository
    {
        private List<LookupValue> _bodyStyles;
        private List<LookupValue> _exteriorColors;
        private List<LookupValue> _interiorColors;
        private List<LookupValue> _purchaseTypes;
        private List<LookupValue> _states;
        private List<LookupValue> _transmissionTypes;
        private List<LookupValue> _userRoles;
        private List<LookupValue> _years;

        public LookupValuesRepository()
        {
            _bodyStyles = new List<LookupValue>
                {
                    new LookupValue { Description="Car" },
                    new LookupValue { Description="SUV"},
                    new LookupValue { Description="Truck" },
                    new LookupValue { Description="Van" },
                };

            _exteriorColors = new List<LookupValue>
            {
                new LookupValue { Description = "Black"  },
                new LookupValue { Description = "Blue"  },
                new LookupValue { Description = "Brown" },
                new LookupValue { Description = "Green" },
                new LookupValue { Description = "Red" },
                new LookupValue { Description = "Orange" },
                new LookupValue { Description = "Yeallow" },
            };

            _interiorColors = new List<LookupValue>
            {
                new LookupValue { Description = "Black"  },
                new LookupValue { Description = "Blue"  },
                new LookupValue { Description = "Red" },
                new LookupValue { Description = "Tan" },
            };

            _purchaseTypes = new List<LookupValue>
                {
                    new LookupValue { Description="Bank Finance"  },
                    new LookupValue { Description="Cash"},
                    new LookupValue { Description="Dealer Finance" },
                };

            _states = new List<LookupValue>
            {
                new LookupValue { Description="IN" },
                new LookupValue { Description="KY" },
                new LookupValue { Description="MN" },
                new LookupValue { Description="OH" },
                new LookupValue { Description="TN" },
            };

            _transmissionTypes = new List<LookupValue>
            {
                new LookupValue { Description="Automatic"  },
                new LookupValue { Description="Manual"  },
            };

            _userRoles = new List<LookupValue>
            {
                new LookupValue { Description="Admin"  },
                new LookupValue { Description="Sales"  },
                new LookupValue { Description="Disabled" },
            };

            _years = new List<LookupValue>();
            //Generate years between 2000 and current year + 1 as per app specs.
            List<int> listYears = Enumerable.Range(2000, DateTime.Now.Year - 2001 + 1).ToList();

            foreach (var i in listYears)
            {
                var x = new LookupValue { Description = i.ToString() };
                _years.Add(x);
            }

        }

        public IEnumerable<LookupValue> GetBodyStylesAll()
        {
            return _bodyStyles;
        }

        public IEnumerable<LookupValue> GetExteriorColorsAll()
        {
            return _exteriorColors;
        }

        public IEnumerable<LookupValue> GetInteriorColorsAll()
        {
            return _interiorColors;
        }

        public IEnumerable<LookupValue> GetPurchaseTypeAll()
        {
            return _purchaseTypes;
        }

        public IEnumerable<LookupValue> GetStatesAll()
        {
            return _states;
        }

        public IEnumerable<LookupValue> GetTransmissionTypesAll()
        {
            return _transmissionTypes;
        }

        public IEnumerable<LookupValue> GetUserRolesAll()
        {
            return _userRoles;
        }

        public IEnumerable<LookupValue> GetYearsAll()
        {
            return _years;
        }
    }
}
