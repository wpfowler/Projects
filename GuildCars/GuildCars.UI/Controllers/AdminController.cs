using GuildCars.Data.Factories;
using GuildCars.Models.Models.Queries;
using GuildCars.Models.Models.Tables;
using GuildCars.UI.Models;
using GuildCars.UI.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{/// <summary>  
///  All adminsitrative tasks handled here. Requires Admin Role
/// </summary>
/// 
   
    public class AdminController : Controller
    {
        GuildCars.UI.Models.Identity.GuildCarsDbContext context = new GuildCars.UI.Models.Identity.GuildCarsDbContext();
        // GET: Admin
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult Vehicles()
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
        [Authorize(Roles = "admin")]
        public ActionResult EditVehicle(int id)
        {
            var repo = RepositoryFactory.GetRepository();
            var LookupValueRepo = LookupValueFactory.GetRepository();
            VehicleQueryModel vcm = repo.GetVehicleDetail(id);
            AddEditVehicleViewModel aevm = new AddEditVehicleViewModel();

            //Set lookup values
            aevm.SetBodyStyles(LookupValueRepo.GetBodyStyles());
            aevm.SetCondition(LookupValueRepo.GetCondition());
            aevm.SetExteriorColor(LookupValueRepo.GetExteriorColor());
            aevm.SetInteriorColor(LookupValueRepo.GetInteriorColor());
            aevm.SetMakes(repo.GetMakes());
            aevm.SetTransmissions(LookupValueRepo.GetTransmissionTypes());
            aevm.SetYears(LookupValueRepo.GetYears());
            
            //Get the models for the make of this vehicle
            aevm.SetModels(repo.GetModelsByMakeId(vcm.MakeId)); 
            
            // Translate the Vechicle Query model to the AddEditVehicleViewModel
            aevm.Condition = vcm.ConditionType.ToString();
            aevm.Transmission = vcm.TransmissionType.ToString();
            aevm.VIN = vcm.VIN.ToString();
            aevm.Year = vcm.Year;
            aevm.MSRP = vcm.MSRP;
            aevm.SalePrice = vcm.SalePrice;
            aevm.ModelId = vcm.ModelId;
            aevm.MakeId = vcm.MakeId;
            aevm.ImageFileName = vcm.ImageFileName.ToString();
            aevm.Mileage = vcm.Mileage;
            aevm.InteriorColor = vcm.InteriorColor.ToString();
            aevm.ExteriorColor = vcm.ExteriorColor.ToString();
            aevm.Description = vcm.Description.ToString();
            aevm.BodyStyle = vcm.BodyStyle.ToString();
            aevm.VehicleId = vcm.VehicleId;
            aevm.FeaturedFlag = vcm.FeaturedFlag;
            aevm.UserId = vcm.UserId;

            return View(aevm);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditVehicle(AddEditVehicleViewModel aevm)
        {

            string fileName = string.Empty;
            if (aevm.UploadedFile != null && aevm.UploadedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Images"),
                    Path.GetFileName(aevm.UploadedFile.FileName));
                fileName = Path.GetFileName(aevm.UploadedFile.FileName);
                aevm.UploadedFile.SaveAs(path);
            }

            var repo = RepositoryFactory.GetRepository();

            VehicleQueryModel vcm = new VehicleQueryModel();

            if (string.IsNullOrEmpty(aevm.ImageFileName))
            {
                aevm.ImageFileName = string.Empty;
            }

            // Translate the Vechicle Query model to the AddEditVehicleViewModel
            vcm.ConditionType = aevm.Condition.ToString();
            vcm.TransmissionType = aevm.Transmission.ToString();
            vcm.VIN = aevm.VIN.ToString();
            vcm.Year = aevm.Year;
            vcm.MSRP = aevm.MSRP;
            vcm.SalePrice = aevm.SalePrice;
            vcm.ModelId = aevm.ModelId;
            vcm.MakeId = aevm.MakeId;
            vcm.ImageFileName = string.IsNullOrEmpty(fileName) ? aevm.ImageFileName : fileName;
            vcm.Mileage = aevm.Mileage;
            vcm.InteriorColor = aevm.InteriorColor.ToString();
            vcm.ExteriorColor = aevm.ExteriorColor.ToString();
            vcm.Description = aevm.Description.ToString();
            vcm.BodyStyle = aevm.BodyStyle.ToString();
            vcm.VehicleId = aevm.VehicleId;
            vcm.FeaturedFlag = aevm.FeaturedFlag;

            //Find id  of logged in user
            var userName = User.Identity.GetUserName();
            var userId = context.Users.FirstOrDefault(u => u.UserName == userName).Id;
            vcm.UserId = aevm.UserId; 

            repo.EditVehicle(vcm); //Save the changes

            return RedirectToAction("Vehicles","Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult AddVehicle()
        {
            var LookupRepo = LookupValueFactory.GetRepository();
            var repo = RepositoryFactory.GetRepository();
            var model = new AddEditVehicleViewModel();

            //set lookup values
            model.SetBodyStyles(LookupRepo.GetBodyStyles());
            model.SetMakes(repo.GetMakes());
            model.SetCondition(LookupRepo.GetCondition());
            model.SetExteriorColor(LookupRepo.GetExteriorColor());
            model.SetInteriorColor(LookupRepo.GetInteriorColor());
            model.SetTransmissions(LookupRepo.GetTransmissionTypes());
            model.SetYears(LookupRepo.GetYears());

            return View(model);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddVehicle(AddEditVehicleViewModel model)
        {
            string fileName =string.Empty; 
            if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Images"),
                    Path.GetFileName(model.UploadedFile.FileName));
                fileName = Path.GetFileName(model.UploadedFile.FileName);
                model.UploadedFile.SaveAs(path);
            }
            if (string.IsNullOrEmpty(model.ImageFileName))
            {
                model.ImageFileName = string.Empty;
            }
            var repo = RepositoryFactory.GetRepository();

            VehicleQueryModel vcm = new VehicleQueryModel();

            //Translate VehicleAddEditViewModel to VehicleQueryModel
            vcm.BodyStyle = model.BodyStyle.ToString();
            vcm.ConditionType = model.Condition.ToString();
            vcm.Description = model.Description.ToString();
            vcm.ExteriorColor = model.ExteriorColor.ToString();
            vcm.InteriorColor = model.InteriorColor.ToString();
            vcm.MakeId = model.MakeId;
            vcm.ModelId = model.ModelId;
            vcm.MSRP = model.MSRP;
            vcm.SalePrice = model.SalePrice;
            vcm.Mileage = model.Mileage;
            vcm.SoldFlag = false;
            vcm.ImageFileName = string.IsNullOrEmpty(fileName) ? model.ImageFileName : fileName;
            vcm.TransmissionType = model.Transmission;
            vcm.SoldFlag = false;
            vcm.FeaturedFlag = false;
            vcm.FeaturedFlag = model.FeaturedFlag;
            vcm.VIN = model.VIN.ToString();
            vcm.Year = model.Year;
            vcm.UserId = "913dd4f1-4506-4fad-91ae-4539b7a5bdb5"; ///Get the logged in user
            VehicleQueryModel newVehicle = repo.AddVehicle(vcm);
            int id = newVehicle.VehicleId;
            return RedirectToAction("EditVehicle","Admin", new {id});  //Need RouteValues pass id to edit..
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Specials()
        {
            //Displays list of specials and area to add new specials
            var repo = RepositoryFactory.GetRepository();
            List <Specials> model = repo.GetSpecials();
            //display specials
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Specials(Specials model)
        {
            var repo = RepositoryFactory.GetRepository();
            repo.AddSpecial(model);
            return RedirectToAction("Specials", "Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult DeleteSpecial(int SpecialsId)
        {
            var repo = RepositoryFactory.GetRepository();
            Specials model = repo.GetSpecialById(SpecialsId);
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult DeleteSpecial(Specials model)
        {
            var repo = RepositoryFactory.GetRepository();
            repo.DeleteSpecial(model.SpecialsId);

            return RedirectToAction("Specials", "Admin");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult AddMake()
        {   //Displays current list of makes and area to add new makes
            var repo = RepositoryFactory.GetRepository();
            List<Makes> model = repo.GetMakes();
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMake(Makes model)
        {
            var repo = RepositoryFactory.GetRepository();

             model.DateAdded = DateTime.Now.ToString();
            //Find id  of logged in user
            var userName = User.Identity.GetUserName();
            var userId = context.Users.FirstOrDefault(u => u.UserName == userName).Id;
            model.UserId = userId;

            repo.AddMake(model);

            return RedirectToAction("AddMake", "Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult AddModel()
        {
            var repo = RepositoryFactory.GetRepository();
   
            AddModelViewModel model = new AddModelViewModel();
            model.SetMakes(repo.GetMakes());
            model.Models = repo.GetModels();
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddModel(AddModelViewModel model)
        {
            var repo = RepositoryFactory.GetRepository();
            Model newModel = new Model();

            if (!ModelState.IsValid)
            {
                model.SetMakes(repo.GetMakes());
                return View(model);
            }

            newModel.Description = model.ModelDescription;
            newModel.MakeId = model.MakeId;
            newModel.DateAdded = DateTime.Now.ToString();

            //Find id  of logged in user
            var userName = User.Identity.GetUserName();


            var userId = context.Users.FirstOrDefault(u => u.UserName == userName).Id;
            newModel.UserId = userId;

            repo.AddModel(newModel);
            return RedirectToAction("AddModel", "Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Users()
        {
            var repo = RepositoryFactory.GetRepository();

            List<User> users = repo.GetUsers();
            return View(users);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditUser(string UserId)
        {
            var repo = RepositoryFactory.GetRepository();
            User u = repo.GetUserById(UserId); //Find the user

            UserViewModel uvm = new UserViewModel();
            uvm.FirstName = u.FirstName;
            uvm.LastName = u.LastName;
            uvm.Role = u.Role;
            uvm.RoleId = u.RoleId;
            uvm.UserName = u.UserName;
            uvm.Email = u.Email;
            uvm.SetRoles(repo.GetRoles());

            return View(uvm);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(UserViewModel uvm)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));

            var repo = RepositoryFactory.GetRepository();

            //Set pw to empty string if nothing passed in
            if (string.IsNullOrEmpty(uvm.Password))
            {
                uvm.Password = string.Empty;
            }
            if (string.IsNullOrEmpty(uvm.ConfirmPassword))
            {
                uvm.ConfirmPassword = string.Empty;
            }

            //Validate passwords (Matching)
            if (uvm.Password.ToString() != uvm.ConfirmPassword.ToString())
            {
                ModelState.AddModelError("Password", "Passwords do not match");
            }

            if (!ModelState.IsValid)
            {
                uvm.SetRoles(repo.GetRoles());
                return View(uvm);
            }

            User model = new User();
            model.FirstName = uvm.FirstName;
            model.LastName = uvm.LastName;
            model.Email = uvm.Email;
            model.RoleId = uvm.RoleId;
            model.UserId = uvm.UserId;

            //Hash pw if it exists
            if (!string.IsNullOrEmpty(uvm.Password))
            {
                model.password = userMgr.PasswordHasher.HashPassword(uvm.Password);
            }
            repo.EditUser(model);
         
            return RedirectToAction("Users", "Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult AddUser()
        {
            var repo = RepositoryFactory.GetRepository();
            UserViewModel model = new UserViewModel();
            model.SetRolesAdd(repo.GetRoles()); //Populate Roles for drop down
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(UserViewModel uvm)
        {
            var repo = RepositoryFactory.GetRepository();

            //Set pw to empty if nothing passed in
            if (string.IsNullOrEmpty(uvm.Password))
            {
                uvm.Password = string.Empty;
            }
            if (string.IsNullOrEmpty(uvm.ConfirmPassword))
            {
                uvm.ConfirmPassword = string.Empty;
            }

            //If pw have data, it has to match
            if (uvm.Password.ToString() != uvm.ConfirmPassword.ToString())
            {
                ModelState.AddModelError("Password", "Passwords do not match");
            }

            if (!ModelState.IsValid)
            {
                uvm.SetRolesAdd(repo.GetRoles());
                return View(uvm);
            }

            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var userName = uvm.FirstName[0] + uvm.LastName; //set user name to first init of first name + last name

            var user = new AppUser()
            {
                UserName = userName,
                FirstName = uvm.FirstName,
                LastName = uvm.LastName,
                Email = uvm.Email
           };

            ///create the user with the manager class
            userMgr.Create(user, uvm.Password);
            userMgr.AddToRole(user.Id, uvm.RoleId);

            return RedirectToAction("Users", "Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult DeleteVehicle(int id)
        {
            var repo = RepositoryFactory.GetRepository();
            VehicleQueryModel vcm = new VehicleQueryModel();
            vcm = repo.GetVehicleDetail(id);
            return View(vcm);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult DeleteVehicle(VehicleQueryModel vcm)
        {
            var repo = RepositoryFactory.GetRepository();
            repo.DeleteVehicle(vcm.VehicleId);
            return RedirectToAction("Vehicles", "Admin");
        }

        [Authorize(Roles = "admin, sales")]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            return View(model);
        }

        [Authorize(Roles = "admin, sales")]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Find the User
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var userName = User.Identity.GetUserName();
            var userId = context.Users.FirstOrDefault(u => u.UserName == userName).Id;
            
            //Create Hash for new PW
            string hash = userMgr.PasswordHasher.HashPassword(model.Password);

            //Update the pw
            var repo = RepositoryFactory.GetRepository();
            repo.ChangePassword(userId, hash);

            return RedirectToAction("index","Home");
        }
    }
} 