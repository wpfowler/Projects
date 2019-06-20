using GuildCars.Data.Factories;
using GuildCars.Models.Models.Tables;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    /// <summary>  
    ///  Controller for all Admin functions  
    /// </summary>  
    /// 
    // [AuthorizeAttribute(Roles = "admin")]
    [Authorize(Roles ="sales")]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
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

        [HttpGet]
        public ActionResult Purchase(int id)
        {    
            var LookupValueRepo = LookupValueFactory.GetRepository();
            var ADORep = RepositoryFactory.GetRepository();

            PurchaseViewModel model = new PurchaseViewModel();
            model.VehicleDetail = ADORep.GetVehicleDetail(id);
            model.SetPurchaseTypes(LookupValueRepo.GetPurchaseTypes());
            model.SetStates(LookupValueRepo.GetStates());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Purchase(PurchaseViewModel model)
        {
            var LookupValueRepo = LookupValueFactory.GetRepository();
            var ADORep = RepositoryFactory.GetRepository();

            //Apply Rule purchase price must be no less than 95% of Sale price
            decimal? salePrice = model.VehicleDetail.SalePrice;
            
            if(model.PurchasePrice < (salePrice * 0.95m))
            {
                ModelState.AddModelError("PurchasePrice", "Purchase Price must be no less than 95% of sale price");
            }
            decimal? MSRP = model.VehicleDetail.MSRP;

            //MSRP Rule. Purchase must not exceed MSRP
            if (model.PurchasePrice > MSRP)
            {
                ModelState.AddModelError("PurchasePrice", "Purchase Price must not exceed MSRP");
            }

            if (!ModelState.IsValid)  //Reload vehicle and set states and purchase types
            {
                model.SetPurchaseTypes(LookupValueRepo.GetPurchaseTypes());
                model.SetStates(LookupValueRepo.GetStates());
                model.VehicleDetail = ADORep.GetVehicleDetail(model.VehicleDetail.VehicleId);
                return View(model);
            }

            //Set sales model  
            Sales sales = new Sales();
            sales.CustomerName = model.CustomerName;
            sales.Phone = model.Phone;
            sales.Street1 = model.Street1;
            sales.Street2 = model.Street2;
            sales.City = model.City;
            sales.State = model.State;
            sales.ZipCode = model.ZipCode;
            sales.VehicleId = model.VehicleDetail.VehicleId;
            sales.PurchaseType = model.PurchaseType;
            sales.PurchasePrice = model.PurchasePrice;

            //Find id  of logged in user
            var userName = User.Identity.GetUserName();
            GuildCars.UI.Models.Identity.GuildCarsDbContext context = new GuildCars.UI.Models.Identity.GuildCarsDbContext();
            var userId = context.Users.FirstOrDefault(u=> u.UserName == userName).Id;
            sales.UserId = userId;
            
            ADORep.PurchaseVehicle(sales); //update/Make purchase
            return  View(model);
        }
    }
}