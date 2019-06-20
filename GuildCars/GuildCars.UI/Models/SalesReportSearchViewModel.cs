using GuildCars.Models.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class SalesReportSearchViewModel
    {//populates drop down list with a list of users - it is a Sales Report search filter
        public SalesReportSearchViewModel()
        {
            Users = new List<SelectListItem>();
        }

        public string userId { get; set; }
        public List<SelectListItem> Users { get; set; }

        public void SetUsers(IEnumerable<User> users)
        {
            foreach (var u in users)
            {
                Users.Add(new SelectListItem()
                {
                    Value = u.UserId.ToString(),
                    Text = u.UserName.ToString()
                });
            }
        }
    }
}