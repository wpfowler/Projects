using GuildCars.Models.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class AddModelViewModel
    {
        public AddModelViewModel()
        {
            Makes = new List<SelectListItem>();
        }
        public int MakeId { get; set; }
        public List<SelectListItem> Makes { get; set; }
        public string ModelDescription { get; set; }
        public string DateAdded { get; set; }
        public string UserId { get; set; }
        public List<Model> Models { get; set; }

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
    }
}