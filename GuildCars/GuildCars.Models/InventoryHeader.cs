using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models
{
   public class InventoryHeader
    {
        public InventoryHeader()
        {
            years = new List<SelectListItem>();
        }
        public List<SelectListItem> years { get; set; }

        public void SetUserRoles(IEnumerable<LookupValue> years)
        {
            foreach (var userRole in uRoles)
            {
                years.Add(new SelectListItem()
                {
                    Value = userRole.Description.ToString(),
                    Text = userRole.Description.ToString()
                });
            }
        }
    }
}
