using GuildCars.Data.Factories;
using GuildCars.Models.Models.Queries;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {   
        // GET: New Inventory
        public ActionResult New()
        {
            var LookupValueRepo = LookupValueFactory.GetRepository();

            //Populates the dropdown list values for Years and Price
            SearchViewModel model = new SearchViewModel();
            model.SetMinYearValues(LookupValueRepo.GetYears());
            model.SetMaxYearValues(LookupValueRepo.GetYears());
            model.SetMinPriceValues(LookupValueRepo.GetPrices());
            model.SetMaxPriceValues(LookupValueRepo.GetPrices());
            return View(model);
        }

        //Get Used Inventory
        public ActionResult Used()
        {
            var LookupValueRepo = LookupValueFactory.GetRepository();

            //Populates the dropdown list values for Years and Price
            SearchViewModel model = new SearchViewModel();
            model.SetMinYearValues(LookupValueRepo.GetYears());
            model.SetMaxYearValues(LookupValueRepo.GetYears());
            model.SetMinPriceValues(LookupValueRepo.GetPrices());
            model.SetMaxPriceValues(LookupValueRepo.GetPrices());

            return View(model);
        }

        //Invetory Detail
        public ActionResult Detail(int id)
        {
            var repo = RepositoryFactory.GetRepository();
            VehicleQueryModel model = repo.GetVehicleDetail(id);
            return View(model);
        }
    }
}