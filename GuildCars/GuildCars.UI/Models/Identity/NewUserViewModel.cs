using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models.Identity
{
    public class NewUserViewModel
    {
        public NewUserViewModel()
        {
            userRoles = new List<SelectListItem>();
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public List<SelectListItem> userRoles { get; set; }

        public void SetUserRoles(IEnumerable<LookupValue> uRoles)
        {
            foreach (var userRole in uRoles)
            {
                userRoles.Add(new SelectListItem()
                {
                    Value = userRole.Description.ToString(),
                    Text = userRole.Description.ToString()
                });
            }
        }

    }
}