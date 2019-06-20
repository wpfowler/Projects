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
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inventory()
        {   //Inventory Reports
            var repo = RepositoryFactory.GetRepository();
            InventoryReportsNewUsedQueryModel model = new InventoryReportsNewUsedQueryModel();
            model.NewInventory = repo.GetInventoryReport("New").ToList();
            model.UsedInventory = repo.GetInventoryReport("Used").ToList();
            return View(model);
        }

        public ActionResult Sales()
        {  //Returns the drop down list of users for the Sales search report
            SalesReportSearchViewModel model = new SalesReportSearchViewModel();
            var repo = RepositoryFactory.GetRepository();
            model.SetUsers(repo.GetUsers());
            return View(model);
        }
    }
}