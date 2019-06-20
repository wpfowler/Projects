using GuildCars.Models.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Roles = new List<SelectListItem>();
        }
        public string UserId { get; set; }
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Role { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public string RoleId { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Enter a valid email address")]
        public string Email { get; set; }

        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        public void SetRoles(IEnumerable<Roles> roles)
        {
            foreach (var r in roles)
            {
                Roles.Add(new SelectListItem()
                {  //edit user needs the roleId instead of role name
                    Value = r.RoleId.ToString(),
                    Text = r.Role.ToString()
                });
            }
        }

        public void SetRolesAdd(IEnumerable<Roles> roles)
        { //need the role name to be the value for the add method (//userMgr.AddToRole(user.Id, "sales");)
            foreach (var r in roles) 
            {
                Roles.Add(new SelectListItem()
                {
                    Value = r.Role.ToString(),
                    Text = r.Role.ToString()
                });
            }
        }
    }
}