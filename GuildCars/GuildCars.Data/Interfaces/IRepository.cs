using System.Collections.Generic;
using GuildCars.Models.Models.Queries;
using GuildCars.Models.Models.Tables;

namespace GuildCars.Data.Interfaces
{
    public interface IRepository
    { 
        //Note: Should have made multiple repositories - Single Responseibility Principle
        Specials AddSpecial(Specials special);
        Contacts AddContact(Contacts contact);
        VehicleQueryModel AddVehicle(VehicleQueryModel newVehicle);
        Model AddModel(Model newModel);
        Makes AddMake(Makes newmodel);
        VehicleQueryModel EditVehicle(VehicleQueryModel editVehicle);
        bool DeleteVehicle(int id);
        bool DeleteSpecial(int id);
        Makes GetMakeById(int id);
        Model GetModelById(int id);
        List<User> GetUsers();
        User GetUserById(string id);
        List<VehicleQueryModel> GetFeaturedVehicles();
        List<VehicleQueryModel> GetVehicles(int minYear, int maxYear, decimal minPrice, decimal maxPrice, string searchTerm, string Condition);
        VehicleQueryModel GetVehicleDetail(int id);
        List<Specials> GetSpecials();
        Specials GetSpecialById(int id);
        List<Contacts> GetContacts();
        List<Model> GetModels();
        List<Makes> GetMakes();
        List<Model> GetModelsByMakeId(int id);
        List<InventoryReportQueryModel> GetInventoryReport(string conditionType);
        List<SalesReportQueryModel> GetSalesReport(string minDate, string MaxDate, string userId);
        Sales PurchaseVehicle(Sales model);
        List<Roles> GetRoles();
        User EditUser(User user);
        bool ChangePassword(string UserId, string PasswordHash);
    }
}
