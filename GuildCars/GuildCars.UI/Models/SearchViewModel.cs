using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class SearchViewModel
    {   //Featured Vehicle and Specials information for the home page
        public SearchViewModel()
        {
            PriceMin = new List<SelectListItem>();
            PriceMax = new List<SelectListItem>();
            YearMin = new List<SelectListItem>();
            YearMax =  new List<SelectListItem>();
        }
        public int mnYear { get; set; }
        public int mxYear { get; set; }
        public int mnPrice { get; set; }
        public int mxPrice { get; set; }
        public List<SelectListItem> PriceMin { get; set; }
        public List<SelectListItem> PriceMax { get; set; }
        public List<SelectListItem> YearMin { get; set; }
        public List<SelectListItem> YearMax { get; set; }

        public void SetMinPriceValues(IEnumerable<LookupValue> priceMin)
        {
            foreach (var pm in priceMin)
            {
                PriceMin.Add(new SelectListItem()
                {
                    Value = pm.Description.ToString(),
                    Text = pm.Description.ToString()
                });
            }
        }

        public void SetMaxPriceValues(IEnumerable<LookupValue> priceMax)
        {
            foreach (var pm in priceMax)
            {
                PriceMax.Add(new SelectListItem()
                {
                    Value = pm.Description.ToString(),
                    Text = pm.Description.ToString()
                });
            }
        }

        public void SetMinYearValues(IEnumerable<LookupValue> yearMin)
        {
            foreach (var ym in yearMin)
            {
                YearMin.Add(new SelectListItem()
                {
                    Value = ym.Description.ToString(),
                    Text = ym.Description.ToString()
                });
            }
        }

        public void SetMaxYearValues(IEnumerable<LookupValue> yearMax)
        {
            foreach (var ym in yearMax)
            {
                YearMax.Add(new SelectListItem()
                {
                    Value = ym.Description.ToString(),
                    Text = ym.Description.ToString()
                });
            }
        }
    }
}