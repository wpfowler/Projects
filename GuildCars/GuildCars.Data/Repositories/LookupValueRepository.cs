using GuildCars.Data.Interfaces;
using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories
{
    public class LookupValueRepository : ILookupValueRepository
    {   //In memory lookups. OK per design discussion with M.Brodsky
        private List<LookupValue> _BodyStyles;
        private List<LookupValue> _exteriorColors;
        private List<LookupValue> _interiorColors;
        private List<LookupValue> _price;
        private List<LookupValue> _purchaseTypes;
        private List<LookupValue> _states;
        private List<LookupValue> _transmissionTypes;
        private List<LookupValue> _userRoles;
        private List<LookupValue> _years;
        private List<LookupValue> _condition;

        public LookupValueRepository()
        {
            _BodyStyles = new List<LookupValue>
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
                new LookupValue { Description = "Yellow" },
                new LookupValue { Description = "White" },
            };

            _interiorColors = new List<LookupValue>
            {
                new LookupValue { Description = "Black"  },
                new LookupValue { Description = "Blue"  },
                new LookupValue { Description = "Red" },
                new LookupValue { Description = "Tan" },
            };

            _price = new List<LookupValue>();
            List<string> listPrice = new List<string>();
            for (int i = 10000; i <= 100000; i++)
            {
                if (i % 5000 == 0) //5000 dollar increments
                {
                    var x = new LookupValue { Description = i.ToString() };
                    _price.Add(x);
                }
            }
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
            List<int> listYears = Enumerable.Range(2000, DateTime.Now.Year - 1998).ToList();

            foreach (var i in listYears)
            {
                var x = new LookupValue { Description = i.ToString() };
                _years.Add(x);
            }

            _condition = new List<LookupValue>
                {
                    new LookupValue { Description="New" },
                    new LookupValue { Description="Used"}
                };
        }
    
        public IEnumerable<LookupValue> GetExteriorColor()
        {
            return _exteriorColors;
        }

        public IEnumerable<LookupValue> GetBodyStyles()
        {
            return _BodyStyles;
        }

        public IEnumerable<LookupValue> GetPrices()
        {
            return _price;
        }

        public IEnumerable<LookupValue> GetInteriorColor()
        {
            return _interiorColors;
        }

        public IEnumerable<LookupValue> GetPurchaseTypes()
        {
            return _purchaseTypes;
        }

        public IEnumerable<LookupValue> GetStates()
        {
            return _states;
        }

        public IEnumerable<LookupValue> GetTransmissionTypes()
        {
            return _transmissionTypes;
        }

        public IEnumerable<LookupValue> GetUserRoles()
        {
            return _userRoles;
        }

        public IEnumerable<LookupValue> GetYears()
        {
            return _years;
        }

        public IEnumerable<LookupValue> GetCondition()
        {
            return _condition;
        }
    }
}
