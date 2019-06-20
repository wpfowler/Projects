using GuildCars.Models.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using GuildCars.Models.Models.Queries;
using System.ComponentModel.DataAnnotations;
namespace GuildCars.UI.Models
{
    public class PurchaseViewModel
    {
        public PurchaseViewModel()
        {
            PurchaseTypes = new List<SelectListItem>();
            States = new List<SelectListItem>();
        }

        public VehicleQueryModel VehicleDetail { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [Required] //Validate Phone
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid Phone Number")]
        public string Phone { get; set; }
        [Required] //Validate Email 
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Enter a valid email address")]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street1 { get; set; }
        [MaxLength(50)]
        public string Street2 { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(2)]
        public string State { get; set; }
        [Required]
        public string PurchaseType { get; set; }
        [Required]
        public decimal? PurchasePrice { get; set; }
        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }
        public List<SelectListItem> States { get; set; }

        public void SetStates(IEnumerable<LookupValue> sTypes)
        {
            foreach (var st in sTypes)
            {
                States.Add(new SelectListItem()
                {
                    Value = st.Description.ToString(),
                    Text = st.Description.ToString()
                });
            }
        }

        public List<SelectListItem> PurchaseTypes { get; set; }
        public void SetPurchaseTypes(IEnumerable<LookupValue> pTypes)
        {
            foreach (var type in pTypes)
            {
                PurchaseTypes.Add(new SelectListItem()
                {
                    Value = type.Description.ToString(),
                    Text = type.Description.ToString()
                });
            }
        }

    }
}