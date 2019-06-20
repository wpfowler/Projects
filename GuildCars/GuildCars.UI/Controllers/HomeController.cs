using GuildCars.Data.Factories;
using GuildCars.UI.Models;
using GuildCars.Models.Models.Tables;
using System.Collections.Generic;
using System.Web.Mvc;
using GuildCars.Models.Models.Queries;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Get Featurd Vehicles
           var repo = RepositoryFactory.GetRepository();
           HomePageQueryModel Home = new HomePageQueryModel();
                     
           repo.GetFeaturedVehicles();
           Home.Specials = repo.GetSpecials();
           List<VehicleQueryModel> vv  = new List<VehicleQueryModel>();
           var featuredVehicles = repo.GetFeaturedVehicles();
           Home.FeaturedVehicles = featuredVehicles;
           var specials = repo.GetSpecials();
           Home.Specials = specials;
           return View(Home);
        }
        public ActionResult NewInventory()
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

        public ActionResult UsedInventory()
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
        public ActionResult Specials()
        {   //Get list of specials
            var repo = RepositoryFactory.GetRepository();
            var specials = repo.GetSpecials();
            return View(specials);
        }

        [HttpGet]
        public ActionResult Contact(int? vehicleId)
        {   //Set message for contact us page
            var id = 0;

            if( vehicleId != null) //Will be null if coming from Home Page Contact link
            {
                id = vehicleId.Value; //Not null if from vehicle search / contact us button
            }

            Contacts model = new Contacts();
            if (id != 0) //Coming from inventory search. VehicleId set. 0 - coming from home page
            {  //custom message - contact about specific vehicle.
                var repo = RepositoryFactory.GetRepository();
                VehicleQueryModel vm = repo.GetVehicleDetail(id);
                string message = $"Hello, Please Contact me about the {vm.Year} {vm.MakeDescription} {vm.ModelDescription}.\n VIN: {vm.VIN}";
                model.Message = message;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(Contacts contact)
        {
            var repo = RepositoryFactory.GetRepository();
            repo.AddContact(contact);
            return RedirectToAction("Index");
        }
    }
}