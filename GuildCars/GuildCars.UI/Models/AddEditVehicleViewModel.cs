using GuildCars.Models.Models;
using GuildCars.Models.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class AddEditVehicleViewModel
    {
        public AddEditVehicleViewModel()
        {
            Makes = new List<SelectListItem>();
            Conditions = new List<SelectListItem>();
            ExteriorColors = new List<SelectListItem>();
            InteriorColors = new List<SelectListItem>();
            BodyStyles = new List<SelectListItem>();
            Models = new List<SelectListItem>();
            Years = new List<SelectListItem>();
            Transmissions = new List<SelectListItem>();
        }
        public HttpPostedFileBase UploadedFile { get; set; }
        public int VehicleId { get; set; }
        public List<SelectListItem> Makes { get; set; }
        public int MakeId { get; set; }
        public List<SelectListItem> Conditions { get; set; }
        public string Condition { get; set; }
        public List<SelectListItem> Years { get; set; }
        [Required]
        public int Year { get; set; }
        public List<SelectListItem> ExteriorColors { get; set; }
        public string ExteriorColor { get; set; }
        [Required]
        public decimal? Mileage { get; set; }
        [Required]
        public decimal? MSRP { get; set; }
        public List<SelectListItem> Models { get; set; }
        public int ModelId { get; set;  }
        public List<SelectListItem> BodyStyles { get; set; }
        public string BodyStyle { get; set; }
        public List<SelectListItem> InteriorColors { get; set; }
        public string InteriorColor { get; set; }
        public string VIN { get; set; }
        [Required]
        public decimal? SalePrice { get; set; }
        public List<SelectListItem> Transmissions { get; set; }
        public string Transmission { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public bool  FeaturedFlag { get; set; }
        public string UserId { get; set; }
        public void SetMakes(IEnumerable<Makes> makes)
        {
            foreach (var m in makes)
            {
                Makes.Add(new SelectListItem()
                {
                    Value = m.MakeId.ToString(),
                    Text = m.Description.ToString()
                });
            }
        }
        public void SetModels(IEnumerable<Model> models)
        {
            foreach (var m in models)
            {
                Models.Add(new SelectListItem()
                {
                    Value = m.ModelId.ToString(),
                    Text = m.Description.ToString()
                });
            }
        }


        public void SetCondition(IEnumerable<LookupValue> condition)
        {
            foreach (var c in condition)
            {
                Conditions.Add(new SelectListItem()
                {
                    Value = c.Description.ToString(),
                    Text = c.Description.ToString()
                });
            }
        }

        public void SetExteriorColor(IEnumerable<LookupValue> exteriorColors)
        {
            foreach (var ec in exteriorColors)
            {
                ExteriorColors.Add(new SelectListItem()
                {
                    Value = ec.Description.ToString(),
                    Text = ec.Description.ToString()
                });
            }
        }

        public void SetBodyStyles(IEnumerable<LookupValue> bodyStyles)
        {
            foreach (var bs in bodyStyles)
            {
                BodyStyles.Add(new SelectListItem()
                {
                    Value = bs.Description.ToString(),
                    Text = bs.Description.ToString()
                });
            }
        }

        public void SetInteriorColor(IEnumerable<LookupValue> interiorColor)
        {
            foreach (var ic in interiorColor)
            {
                InteriorColors.Add(new SelectListItem()
                {
                    Value = ic.Description.ToString(),
                    Text = ic.Description.ToString()
                });
            }
        }

        public void SetYears(IEnumerable<LookupValue> years)
        {
            foreach (var y in years)
            {
                Years.Add(new SelectListItem()
                {
                    Value = y.Description.ToString(),
                    Text = y.Description.ToString()
                });
            }
        }

        public void SetTransmissions(IEnumerable<LookupValue> transmissions)
        {
            foreach (var t in transmissions)
            {
                Transmissions.Add(new SelectListItem()
                {
                    Value = t.Description.ToString(),
                    Text = t.Description.ToString()
                });
            }
        }

    }
}