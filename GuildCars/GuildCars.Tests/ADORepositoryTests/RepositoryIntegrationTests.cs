using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GuildCars.Data.Factories;
using GuildCars.Models.Models.Queries;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Repositories;
using System.Data.SqlClient;
using System.Configuration;
using GuildCars.Models.Models.Tables;
using GuildCars.UI.Models;

namespace GuildCars.Tests.ADORepositoryTests
{   [TestFixture]
    class RepositoryIntegrationTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanGetFeaturedVehicles()
        {
            IRepository ADORepo = new ADORepository();
            List<VehicleQueryModel> model = new List<VehicleQueryModel>();
            model = ADORepo.GetFeaturedVehicles();

            Assert.AreEqual(3, model.Count);
            Assert.AreEqual("Chevrolet", model[0].MakeDescription);
        }

       [TestCase(2000,0,0,0,null,"New")]
       [TestCase(2019,2019,null, null, "Chevrolet", "New")]
        public void CanGetNewVehicles(int minYear, int maxYear, int minPrice, int maxPrice, string searchTerm, string condition)
        {
            IRepository ADORepo = new ADORepository();
            List<VehicleQueryModel> model;
            model = ADORepo.GetVehicles(minYear,maxYear,minPrice,maxPrice,searchTerm, condition);

            Assert.NotNull(model);
            Assert.AreEqual("Chevrolet", model[0].MakeDescription);
            Assert.AreEqual(41000, model[0].SalePrice);
            Assert.AreEqual("Car", model[0].BodyStyle);
            Assert.AreEqual("Manual", model[0].TransmissionType);
            Assert.AreEqual("Tan", model[0].InteriorColor);
            Assert.AreEqual("White", model[0].ExteriorColor);
            Assert.AreEqual("ABCD5678912345999", model[0].VIN);
        }

        [TestCase(null, null, null, null, "BMW", "Used")]
        [TestCase(2017, 2017, 22250, 50000, "BMW", "Used")]
        public void CanGetUsedVehicles(int minYear, int maxYear, int minPrice, int maxPrice, string searchTerm, string condition)
        {
            IRepository ADORepo = new ADORepository();
            List<VehicleQueryModel> model;

            model = ADORepo.GetVehicles(minYear, maxYear, minPrice, maxPrice, searchTerm, condition);

            Assert.NotNull(model);
            Assert.AreEqual("BMW", model[0].MakeDescription);
            Assert.AreEqual(32000, model[0].SalePrice);
            Assert.AreEqual("Car", model[0].BodyStyle);
            Assert.AreEqual("Manual", model[0].TransmissionType);
            Assert.AreEqual("Red", model[0].InteriorColor);
            Assert.AreEqual("Black", model[0].ExteriorColor);
            Assert.AreEqual("EFGH5678912345999", model[0].VIN);
        }

        [TestCase(1,2017,"12345678912345678","Car",29000,10000,"Black", "Acura")]
        [TestCase(2, 2019, "12345678912345999", "Car", 65000.00, 9.00, "Black", "Audi")]
        public void CanGetVehicleById(int id, int year, string vin, string bodyStyle,decimal msrp, decimal mileage,string interiorColor, string description)
        {
            IRepository ADORepo = new ADORepository();
            VehicleQueryModel model;
            model = ADORepo.GetVehicleDetail(id);

            Assert.AreEqual(id, model.VehicleId);
            Assert.AreEqual(year, model.Year);
            Assert.AreEqual(vin, model.VIN);
            Assert.AreEqual(bodyStyle, model.BodyStyle);
            Assert.AreEqual(msrp, model.MSRP);
            Assert.AreEqual(mileage, model.Mileage);
            Assert.AreEqual(interiorColor, model.InteriorColor);
            Assert.AreEqual(description, model.MakeDescription);
        }
        [Test]
        public void GetSpecials()
        {
            IRepository ADORepo = new ADORepository();
            List<Specials> model;
            model = ADORepo.GetSpecials();

            Assert.AreEqual(5, model.Count);
            Assert.AreEqual(1, model[0].SpecialsId);
            Assert.AreEqual("Oil change $29.95", model[0].Description);
            Assert.AreEqual(2, model[1].SpecialsId);
            Assert.AreEqual("Brake Job $59.95 per axle", model[1].Description);
            Assert.AreEqual(3, model[2].SpecialsId);
            Assert.AreEqual("Coolant Flush And Fill $99.99", model[2].Description);
            Assert.AreEqual(4, model[3].SpecialsId);
            Assert.AreEqual("Buy 3 Tires Get 1 Free - Any Brand", model[3].Description);
            Assert.AreEqual(5, model[4].SpecialsId);
            Assert.AreEqual("Free Beer and Pizza while you wait", model[4].Description);
        }

        [Test]
        public void CanGetContacts()
        {
            IRepository ADORepo = new ADORepository();
            List<Contacts> model;
            model = ADORepo.GetContacts();

            Assert.AreEqual("John Smith", model[0].ContactName);
            Assert.AreEqual("(555) 555-5555", model[0].Phone);
            Assert.AreEqual("Contact me about VIN: 12345678912345999", model[0].Message);
            Assert.AreEqual("John@smith.com", model[0].Email);
            Assert.AreNotEqual("John Smith", model[1].ContactName);
            Assert.AreNotEqual("(555) 555-5555", model[1].Phone);
            Assert.AreNotEqual("Contact me about VIN: 12345678912345999", model[1].Message);
            Assert.AreNotEqual("John@smith.com", model[1].Email);
        }

        [TestCase(null, null, null, null, null, null)]
        [TestCase(2010, 2019, null, 100000, null, null)]
        [TestCase(null, null, 10000, 100000, null, null)]
        public void CanGetNewAndUsedVehicles(int minYear, int maxYear, int minPrice, int maxPrice, string searchTerm, string condition)
        {
            IRepository ADORepo = new ADORepository();
            List<VehicleQueryModel> model;

            model = ADORepo.GetVehicles(minYear, maxYear, minPrice, maxPrice, searchTerm, condition);

            Assert.NotNull(model);
            Assert.AreEqual("Chevrolet", model[0].MakeDescription);
            Assert.AreEqual(41000, model[0].SalePrice);
            Assert.AreEqual("Car", model[0].BodyStyle);
            Assert.AreEqual("Manual", model[0].TransmissionType);
            Assert.AreEqual("Tan", model[0].InteriorColor);
            Assert.AreEqual("White", model[0].ExteriorColor);
            Assert.AreEqual("ABCD5678912345999", model[0].VIN);
            Assert.AreEqual("New", model[0].ConditionType);

            Assert.AreEqual("BMW", model[2].MakeDescription);
            Assert.AreEqual(32000, model[2].SalePrice);
            Assert.AreEqual("Car", model[2].BodyStyle);
            Assert.AreEqual("Manual", model[2].TransmissionType);
            Assert.AreEqual("Red", model[2].InteriorColor);
            Assert.AreEqual("Black", model[2].ExteriorColor);

            Assert.AreEqual("EFGH5678912345999", model[2].VIN);
            Assert.AreEqual("Used", model[2].ConditionType);
        }

        [Test]
        public void CanPurchaseVehicle()
        {
            IRepository ADORepo = new ADORepository();
            Sales model = new Sales();

            model.CustomerName = "Ricky Bobby";
            model.Street1 = "11 Talladega Drive";
            model.Street2 = "Next to the Applebees";
            model.City = "Redneck City";
            model.State = "Al";
            model.VehicleId = 2;
            model.UserId = "913dd4f1-4506-4fad-91ae-4539b7a5bdb5";
            model.ZipCode = "88888-9999";
            model.PurchasePrice = 100000;
            model.PurchaseType = "Cash";

            Sales newSale = ADORepo.PurchaseVehicle(model);

            Assert.AreEqual(3, newSale.SalesId);
            Assert.AreEqual(model.Street1, newSale.Street1);
            Assert.AreEqual(model.Street2, newSale.Street2);
            Assert.AreEqual(model.City, newSale.City);
            Assert.AreEqual(model.State, newSale.State);
            Assert.AreEqual(model.ZipCode, newSale.ZipCode);
            Assert.AreEqual(model.CustomerName, newSale.CustomerName);
            Assert.AreEqual(model.PurchasePrice, newSale.PurchasePrice);
            Assert.AreEqual(model.PurchaseType, newSale.PurchaseType);
        }

        [TestCase("Duesenburg", "913dd4f1-4506-4fad-91ae-4539b7a5bdb5","01-01-2019")]
        [TestCase("Desoto", "913dd4f1-4506-4fad-91ae-4539b7a5bdb5","02-20-2019")]
        [TestCase("Willys", "913dd4f1-4506-4fad-91ae-4539b7a5bdb5","01-02-2019")]
        public void CanAddMake(string description,string userId, string dateAdded)
        {
            IRepository ADORepo = new ADORepository();
            Makes model = new Makes();

            model.Description =description;
            model.DateAdded = dateAdded;
            model.UserId = userId;
            Makes newMake = ADORepo.AddMake(model);

            Assert.AreEqual(model.MakeId, newMake.MakeId);
            Assert.AreEqual(model.Description, newMake.Description);
            Assert.AreEqual(model.UserId, newMake.UserId);
            Assert.AreEqual(model.DateAdded, newMake.DateAdded);
        }

        [TestCase("S300",1, "913dd4f1-4506-4fad-91ae-4539b7a5bdb5","01-01/2019")]
        [TestCase("340i",2, "913dd4f1-4506-4fad-91ae-4539b7a5bdb5","02-20-2019")]
        public void CanAddModel(string description,int MakeId, string UserId, string DateAdded)
        {
            IRepository ADORepo = new ADORepository();
            Model model = new Model();

            model.Description = description;
            model.MakeId = MakeId;
            model.UserId = UserId;
            model.DateAdded = DateAdded;
            Model newModel = ADORepo.AddModel(model);

            Assert.AreEqual(newModel.ModelId, model.ModelId);
            Assert.AreEqual(newModel.Description, model.Description);
        }

        [TestCase("S300", -10)]
        [TestCase("340i", -50)]
        [TestCase("X992-10", -60)]
        [TestCase("JunkWagonX3", -41)]
        [TestCase("GasHog3000", -51)]
        public void CanNotAddModelWithNonExistantMake(string description, int MakeId)
        {
            IRepository ADORepo = new ADORepository();
            Model model = new Model();

            model.Description = description;
            model.MakeId = MakeId;

            Model newModel = ADORepo.AddModel(model);
            Assert.Null(newModel);
        }

        [Test]
        public void CanGetMakes()
        {
            List<Makes> model = new List<Makes>();
            IRepository repo = new ADORepository();
            model = repo.GetMakes();

            Assert.AreEqual("Acura", model[0].Description);
            Assert.AreEqual(1, model[0].MakeId);
            Assert.AreEqual("Audi", model[1].Description);
            Assert.AreEqual(7, model[1].MakeId);
            Assert.AreEqual("BMW", model[2].Description);
        }

        [TestCase("Acura", 1)]
        [TestCase("BMW", 2)]
        [TestCase("Toyota", 3)]
        [TestCase("Infinity", 4)]
        [TestCase("Chevrolet", 5)]
        [TestCase("Ford", 6)]
        [TestCase("Audi", 7)]
        public void GetMakeById(string expectedDesc, int expectedId)
        {
            Makes model = new Makes();
            IRepository repo = new ADORepository();
            model = repo.GetMakeById(expectedId);

            Assert.AreEqual(expectedDesc, model.Description);
            Assert.AreEqual(expectedId, model.MakeId);
        }

        [TestCase("Legend", 1)]
        [TestCase("NSX",2)]
        [TestCase("435i", 3)]
        [TestCase("Tacoma", 4)]
        [TestCase("Camaro", 5)]
        [TestCase("G3", 6)]
        [TestCase("S3", 7)]
        public void GetModelById(string expectedDesc, int expectedId)
        {
            Model model = new Model();
            IRepository repo = new ADORepository();
            model = repo.GetModelById(expectedId);

            Assert.AreEqual(expectedDesc, model.Description);
            Assert.AreEqual(expectedId, model.ModelId);
        }

        [Test]
        public void CanAddVehicle()
        {
            IRepository ADORepo = new ADORepository();
            VehicleQueryModel model = new VehicleQueryModel();
            model.ModelId = 1;
            model.Year = 2019;
            model.VIN = "00000000000000000";
            model.TransmissionType = "Automatic";
            model.ConditionType = "New";
            model.BodyStyle = "SUV";
            model.InteriorColor = "Red";
            model.ExteriorColor = "White";
            model.MSRP = 55000;
            model.Mileage = 1;
            model.Description = "Some big SUV";
            model.ImageFileName = "BigSuv.jpg";
            model.SalePrice = 49000;
            model.UserId = "913dd4f1-4506-4fad-91ae-4539b7a5bdb5";

           VehicleQueryModel newModel =  ADORepo.AddVehicle(model);

            Assert.AreEqual(6, newModel.VehicleId);
            Assert.AreEqual("Red", newModel.InteriorColor);
        }

        [Test]
        public void CanEditVehicle()
        {
            IRepository ADORepo = new ADORepository();
            VehicleQueryModel model = new VehicleQueryModel();
            model.VehicleId = 1;
            model.ModelId = 5;
            model.Year = 2019;
            model.VIN = "00000000000000000";
            model.TransmissionType = "Automatic";
            model.ConditionType = "New";
            model.BodyStyle = "SUV";
            model.InteriorColor = "Red";
            model.ExteriorColor = "White";
            model.MSRP = 55000;
            model.Mileage = 1;
            model.Description = "Some big SUV";
            model.ImageFileName = "BigSuv.jpg";
            model.FeaturedFlag = false;
            model.SalePrice = 49000;
            model.UserId = "913dd4f1-4506-4fad-91ae-4539b7a5bdb5";

            VehicleQueryModel newModel = ADORepo.EditVehicle(model);

            Assert.AreEqual(1, newModel.VehicleId);
            Assert.AreEqual("Red", newModel.InteriorColor);
            Assert.AreNotEqual("Car", newModel.BodyStyle.ToString());
            Assert.AreNotEqual("Black", newModel.InteriorColor.ToString());
            Assert.AreNotEqual(1, newModel.ModelId);
        }
        [Test]
        public void CanDeleteVehicle()
        {
            IRepository ADORepo = new ADORepository();

            bool rtrn = ADORepo.DeleteVehicle(3);
            Assert.IsTrue(rtrn);
            VehicleQueryModel model = ADORepo.GetVehicleDetail(3);
            Assert.IsNull(model);
        }

        [Test]
        public void CanGetNewInventoryReport()
        {
            IRepository ADORepo = new ADORepository();
            List<InventoryReportQueryModel> model =  ADORepo.GetInventoryReport("New");
            Assert.NotNull(model);
            Assert.Greater(model.Count(),0);
        }
        [Test]
        public void CanGetUsedInventoryReport()
        {
            IRepository ADORepo = new ADORepository();
            List<InventoryReportQueryModel> model = ADORepo.GetInventoryReport("Used");
            Assert.NotNull(model);
            Assert.Greater(model.Count(), 0);
        }

        [Test]
        public void CanGetModels()
        {
            IRepository ADORepo = new ADORepository();
            List<Model> model = ADORepo.GetModels();
            Assert.Greater(model.Count,0);
        }

       [Test]
       public void CanGetSalesReport()
        {
            IRepository ADORepo = new ADORepository();
            List<SalesReportQueryModel> model = ADORepo.GetSalesReport(null,null, "913dd4f1-4506-4fad-91ae-4539b7a5bdb5");
            Assert.Greater(model.Count, 0);
            Assert.AreEqual("Joe Administrator", model[0].User.Trim());
            Assert.AreEqual(154000.00, model[0].TotalSales);
            Assert.AreEqual(2, model[0].TotalVehicles);
        }

        [Test]
        public void CanGetModelsByMakeId()
        {
            IRepository ADORepo = new ADORepository();
            List<Model> model = ADORepo.GetModelsByMakeId(1);

            Assert.AreEqual(2, model.Count());
        }
        [Test]
        public void CanAddContact()
        {
            IRepository ADORepo = new ADORepository();
            Contacts model = new Contacts();

            model.ContactName = "Joe Smith";
            model.Email = "Joe@smith.com";
            model.Message = "Contact me about VIN: 12354";
            model.Phone = "(502) 222-2222";
            Contacts newContact = ADORepo.AddContact(model);

            Assert.AreEqual(3, newContact.ContactId);
            Assert.AreEqual(model.Email, newContact.Email);
            Assert.AreEqual(model.ContactName, newContact.ContactName);
            Assert.AreEqual(model.Message, newContact.Message);
            Assert.AreEqual(model.Phone, newContact.Phone);
        }

        [Test]
        public void CanGetUsers()
        {
            IRepository ADORepo = new ADORepository();
            List<User> model = ADORepo.GetUsers();

            Assert.NotNull(model);
            Assert.AreEqual(4, model.Count);
        }

        [Test]
        public void CanDeleteSpecial()
        {
            IRepository ADORepo = new ADORepository();
            List<Specials> beforeDelete = ADORepo.GetSpecials();
            bool rtrn = ADORepo.DeleteSpecial(1);
            List<Specials> afterDelete = ADORepo.GetSpecials();

            Assert.AreNotEqual(beforeDelete.Count, afterDelete.Count);
        }
        [Test]
        public void CanAddSpecial()
        {
            IRepository ADORepo = new ADORepository();
            List<Specials> beforeInsert = ADORepo.GetSpecials();

            Specials model = new Specials();
            model.Description = "This is a new special";
            model.Title = "This is Special";
            ADORepo.AddSpecial(model);
            List<Specials> afterInsert = ADORepo.GetSpecials();
            Assert.AreNotEqual(beforeInsert.Count, afterInsert.Count);
            Assert.Less(beforeInsert.Count, afterInsert.Count);
        }
        [Test]
        public void CanGetRoles()
        {
            IRepository ADORepo = new ADORepository();
            List<Roles> roles = ADORepo.GetRoles();

            Assert.NotNull(roles);
            Assert.NotZero(roles.Count);
        }
        [Test]
        public void CanEditUser()
        {
            IRepository ADORepo = new ADORepository();
            User beforeEdit = ADORepo.GetUserById("913dd4f1-4506-4fad-91ae-4539b7a5bdb5");

            User edit = new User();
            edit.FirstName = "Zakk";
            edit.LastName = "Wylde";
            edit.RoleId = "61939f92-10d6-4a77-aa4d-70e57e6382ac";
            edit.UserId = beforeEdit.UserId;
            edit.Email = beforeEdit.Email;
            ADORepo.EditUser(edit);

            User UserRtrn = ADORepo.GetUserById("913dd4f1-4506-4fad-91ae-4539b7a5bdb5");
            Assert.AreEqual(beforeEdit.UserId, UserRtrn.UserId);
            Assert.AreNotEqual(beforeEdit.RoleId, UserRtrn.RoleId);
            Assert.AreNotEqual(beforeEdit.FirstName, UserRtrn.FirstName);

        }
    }
}
