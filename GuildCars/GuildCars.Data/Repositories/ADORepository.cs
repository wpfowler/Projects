using GuildCars.Data.Interfaces;
using GuildCars.Models.Models.Queries;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GuildCars.Models.Models.Tables;

namespace GuildCars.Data.Repositories
{
    public class ADORepository : IRepository
    {
        string sqlConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

        public Contacts AddContact(Contacts contact)
        {
            try
            {
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddContact";
                    cmd.Parameters.AddWithValue("@ContactName", contact.ContactName.ToString());
                    cmd.Parameters.AddWithValue("@Email", contact.Email.ToString());
                    cmd.Parameters.AddWithValue("@Phone", contact.Phone.ToString());
                    cmd.Parameters.AddWithValue("@Message", contact.Message.ToString());
                    cmd.Parameters.Add(new SqlParameter("@NewID", SqlDbType.Int));
                    cmd.Parameters["@NewID"].Direction = ParameterDirection.Output;
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    contact.ContactId = (int)cmd.Parameters["@NewID"].Value;
                }
                return contact;
            }
            catch
            {
                return null;
            }
        }

        public Makes AddMake(Makes newmodel)
        {
            try
            { 
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddMake";
                    cmd.Parameters.AddWithValue("@Description", newmodel.Description.ToString());
                    cmd.Parameters.AddWithValue("@UserId", newmodel.UserId.ToString());
                    cmd.Parameters.AddWithValue("@DateAdded", newmodel.DateAdded.ToString());
                    cmd.Parameters.Add(new SqlParameter("@NewID", SqlDbType.Int));
                    cmd.Parameters["@NewID"].Direction = ParameterDirection.Output;
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    newmodel.MakeId = (int)cmd.Parameters["@NewID"].Value;
                }
                return newmodel;
            }
            catch
            {
                return null;
            }
        }

        public Model AddModel(Model newModel)
        {
            try
            {
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddModel";
                    cmd.Parameters.AddWithValue("@Description", newModel.Description.ToString());
                    cmd.Parameters.AddWithValue("@MakeId", newModel.MakeId);
                    cmd.Parameters.AddWithValue("@UserId", newModel.UserId).ToString();
                    cmd.Parameters.AddWithValue("@DateAdded", newModel.DateAdded).ToString();
                    cmd.Parameters.Add(new SqlParameter("@NewID", SqlDbType.Int));
                    cmd.Parameters["@NewID"].Direction = ParameterDirection.Output;
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    newModel.ModelId = (int)cmd.Parameters["@NewID"].Value;
                }
                return newModel;
            }
            catch
            {
                return null;
            }
        }

        public Specials AddSpecial(Specials special)
        {
            try
            {
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddSpecial";
                    cmd.Parameters.AddWithValue("@Description", special.Description.ToString());
                    cmd.Parameters.AddWithValue("@Title", special.Title.ToString());
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
                return special;
            }
            catch
            {
                return null;
            }
        }

        public VehicleQueryModel AddVehicle(VehicleQueryModel newVehicle)
        {
            try
            {
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddVehicle";
                    cmd.Parameters.AddWithValue("@ModelId", (int)newVehicle.ModelId);
                    cmd.Parameters.AddWithValue("@Year",(int)newVehicle.Year);
                    cmd.Parameters.AddWithValue("@VIN",  newVehicle.VIN).ToString();
                    cmd.Parameters.AddWithValue("@TransmissionType",  newVehicle.TransmissionType).ToString();
                    cmd.Parameters.AddWithValue("@ConditionType",  newVehicle.ConditionType.ToString());
                    cmd.Parameters.AddWithValue("@BodyStyle", newVehicle.BodyStyle.ToString());
                    cmd.Parameters.AddWithValue("@InteriorColor", newVehicle.InteriorColor.ToString());
                    cmd.Parameters.AddWithValue("@ExteriorColor", newVehicle.ExteriorColor.ToString());
                    cmd.Parameters.AddWithValue("@MSRP", (decimal)newVehicle.MSRP);
                    cmd.Parameters.AddWithValue("@Mileage", (decimal)newVehicle.Mileage);
                    cmd.Parameters.AddWithValue("@Description", newVehicle.Description.ToString());
                    cmd.Parameters.AddWithValue("@ImageFileName", newVehicle.ImageFileName.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", (decimal)newVehicle.SalePrice);
                    cmd.Parameters.AddWithValue("@UserId", newVehicle.UserId.ToString());
                    cmd.Parameters.Add(new SqlParameter("@NewID", SqlDbType.Int));
                    cmd.Parameters["@NewID"].Direction = ParameterDirection.Output;
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    newVehicle.VehicleId = (int)cmd.Parameters["@NewID"].Value;
                }
                return newVehicle;
            }
            catch
            {
                return null;
            }
        }

        public bool ChangePassword(string UserId, string PasswordHash)
        {
            try
            {
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ChangePassword";
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@PasswordHash", PasswordHash);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSpecial(int id)
        {
            try
            {
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteSpecial";
                    cmd.Parameters.AddWithValue("@SpecialsId", id);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteVehicle(int id)
        {
            try
            {
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteVehicle";
                    cmd.Parameters.AddWithValue("@VehicleId", id);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User EditUser(User user)
        {
            try
            {
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EditUser";
                    cmd.Parameters.AddWithValue("@UserId", user.UserId.ToString());
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName.ToString());
                    cmd.Parameters.AddWithValue("@LastName", user.LastName.ToString());
                    cmd.Parameters.AddWithValue("@Email", user.Email.ToString());
                    cmd.Parameters.AddWithValue("@RoleId", user.RoleId.ToString());
                    cmd.Parameters.AddWithValue("@Password", string.IsNullOrEmpty(user.password)? string.Empty: user.password);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
                return user;
            }
            catch
            {
                return null;
            }
        }

        public VehicleQueryModel EditVehicle(VehicleQueryModel editVehicle)
        {
            try
            {
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EditVehicle";
                    cmd.Parameters.AddWithValue("@VehicleId", (int)editVehicle.VehicleId);
                    cmd.Parameters.AddWithValue("@ModelId", (int)editVehicle.ModelId);
                    cmd.Parameters.AddWithValue("@Year", (int)editVehicle.Year);
                    cmd.Parameters.AddWithValue("@VIN", editVehicle.VIN).ToString();
                    cmd.Parameters.AddWithValue("@TransmissionType", editVehicle.TransmissionType).ToString();
                    cmd.Parameters.AddWithValue("@ConditionType", editVehicle.ConditionType.ToString());
                    cmd.Parameters.AddWithValue("@BodyStyle", editVehicle.BodyStyle.ToString());
                    cmd.Parameters.AddWithValue("@InteriorColor", editVehicle.InteriorColor.ToString());
                    cmd.Parameters.AddWithValue("@ExteriorColor", editVehicle.ExteriorColor.ToString());
                    cmd.Parameters.AddWithValue("@MSRP", (decimal)editVehicle.MSRP);
                    cmd.Parameters.AddWithValue("@Mileage", (decimal)editVehicle.Mileage);
                    cmd.Parameters.AddWithValue("@Description", editVehicle.Description.ToString());
                    cmd.Parameters.AddWithValue("@ImageFileName", editVehicle.ImageFileName.ToString());
                    cmd.Parameters.AddWithValue("@FeaturedFlag", (bool)editVehicle.FeaturedFlag);
                    cmd.Parameters.AddWithValue("@SalePrice", (decimal)editVehicle.SalePrice);
                    cmd.Parameters.AddWithValue("@UserId", editVehicle.UserId.ToString());
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                 }
                return editVehicle;
            }
            catch 
            {
                return null;
            }
        }

        public List<Contacts> GetContacts()
        {
            try
            {
                List<Contacts> model = new List<Contacts>();
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetContacts";
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();
                    while (sqlDataRdr.Read())
                    {
                        Contacts contact = new Contacts();
                        contact.ContactName = sqlDataRdr["ContactName"].ToString();
                        contact.Email = sqlDataRdr["Email"].ToString();
                        contact.Message = sqlDataRdr["Message"].ToString();
                        contact.Phone = sqlDataRdr["Phone"].ToString();
                        model.Add(contact);
                    }
                }
                if(model.Count > 0)
                {
                    return model;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<VehicleQueryModel> GetFeaturedVehicles()
        {
            try
            {
                List<VehicleQueryModel> model = new List<VehicleQueryModel>();

                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetFeaturedVehicles";
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    while (sqlDataRdr.Read())
                    {
                        VehicleQueryModel vm = new VehicleQueryModel();
                        vm.VehicleId = (int)sqlDataRdr["VehicleId"];
                        vm.Year = (int)sqlDataRdr["Year"];
                        vm.VIN = sqlDataRdr["VIN"].ToString();
                        vm.TransmissionType = sqlDataRdr["TransmissionType"].ToString();
                        vm.ConditionType = sqlDataRdr["ConditionType"].ToString();
                        vm.BodyStyle = sqlDataRdr["BodyStyle"].ToString();
                        vm.InteriorColor = sqlDataRdr["InteriorColor"].ToString();
                        vm.ExteriorColor = sqlDataRdr["ExteriorColor"].ToString();
                        vm.MSRP = (decimal)sqlDataRdr["MSRP"];
                        vm.Mileage = (decimal)sqlDataRdr["Mileage"];
                        vm.Description = sqlDataRdr["Description"].ToString();
                        if (sqlDataRdr["ImageFileName"] != DBNull.Value)
                        {
                            vm.ImageFileName = sqlDataRdr["ImageFileName"].ToString();
                        }
                        if (sqlDataRdr["FeaturedFlag"] != DBNull.Value)
                        {
                            vm.FeaturedFlag = (bool)sqlDataRdr["FeaturedFlag"];
                        }
                        if (sqlDataRdr["SoldFlag"] != DBNull.Value)
                        {
                            vm.SoldFlag = (bool)sqlDataRdr["SoldFlag"];
                        }

                        vm.MakeId = (int)sqlDataRdr["MakeId"];
                        vm.MakeDescription = sqlDataRdr["MakeDescription"].ToString();
                        vm.ModelId = (int)sqlDataRdr["ModelId"];
                        vm.Description = sqlDataRdr["Description"].ToString();
                        vm.SalePrice = (decimal)sqlDataRdr["SalePrice"];
                        vm.UserId = sqlDataRdr["UserId"].ToString();
                        vm.ModelDescription = sqlDataRdr["ModelDescription"].ToString();
                        model.Add(vm);
                    }
                }
                if(model.Count > 0)
                {
                    return model;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<InventoryReportQueryModel> GetInventoryReport(string conditionType)
        {
            List<InventoryReportQueryModel> model = new List<InventoryReportQueryModel>();
            try
            {
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetInventoryReport";
                    cmd.Parameters.AddWithValue("@ConditionType", conditionType);
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();
                    while (sqlDataRdr.Read())
                    {
                        InventoryReportQueryModel vm = new InventoryReportQueryModel();
                        vm.Make = sqlDataRdr["Make"].ToString();
                        vm.Model = sqlDataRdr["Model"].ToString();
                        vm.Year = (int)sqlDataRdr["Year"];
                        vm.Count = (int)sqlDataRdr["Count"];
                        vm.StockValue = (decimal)sqlDataRdr["StockValue"];
                        model.Add(vm);
                    }
                }
                if(model.Count > 0)
                {
                    return model;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Makes GetMakeById(int id)
        {
            try
            {
                Makes model = null;
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetMakeById";
                    cmd.Parameters.AddWithValue("@MakeId", id);
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    if (sqlDataRdr.Read())
                    {   model = new Makes();
                        model.MakeId = (int)sqlDataRdr["MakeId"];
                        model.Description = sqlDataRdr["Description"].ToString();
                    }
                    return model;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Makes> GetMakes()
        {
            try
            {
                List<Makes> model = new List<Makes>();
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetMakes";
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    while (sqlDataRdr.Read())
                    {
                        Makes newMake = new Makes();
                        newMake.MakeId = (int)sqlDataRdr["MakeId"];
                        newMake.Description = sqlDataRdr["Description"].ToString();
                        newMake.UserId = sqlDataRdr["UserId"].ToString();
                        newMake.DateAdded = sqlDataRdr["DateAdded"].ToString();
                        newMake.UserName = sqlDataRdr["UserName"].ToString();
                        model.Add(newMake);
                    }
                    if(model.Count > 0)
                    {
                        return model;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public Model GetModelById(int id)
        {
            try
            {
                Model model = null;
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetModelById";
                    cmd.Parameters.AddWithValue("@ModelId", id);
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    if (sqlDataRdr.Read())
                    {   model = new Model();
                        model.MakeId = (int)sqlDataRdr["MakeId"];
                        model.ModelId = (int)sqlDataRdr["ModelId"];
                        model.Description = sqlDataRdr["Description"].ToString();
                    }
                    return model;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Model> GetModels()
        {
            try
            {
                List<Model> model = new List<Model>();
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetModels";
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    while (sqlDataRdr.Read())
                    {
                        Model newModel = new Model();
                        newModel.ModelId = (int)sqlDataRdr["ModelId"];
                        newModel.MakeId = (int)sqlDataRdr["MakeId"];
                        newModel.Description = sqlDataRdr["Description"].ToString();
                        newModel.UserId = sqlDataRdr["UserId"].ToString();
                        newModel.MakeDescription = sqlDataRdr["MakeDescription"].ToString();
                        newModel.UserName = sqlDataRdr["UserName"].ToString();
                        newModel.DateAdded = sqlDataRdr["DateAdded"].ToString();
                        model.Add(newModel);
                    }
                    if (model.Count > 0)
                    {
                        return model;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Model> GetModelsByMakeId(int id)
        {
            try
            {
                List<Model> model = new List<Model>();
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetModelsByMakeId";
                    cmd.Parameters.AddWithValue("@MakeId", id);
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    while (sqlDataRdr.Read())
                    {
                        Model newModel = new Model();
                        newModel.ModelId = (int)sqlDataRdr["ModelId"];
                        newModel.MakeId = (int)sqlDataRdr["MakeId"];
                        newModel.Description = sqlDataRdr["Description"].ToString();
                        model.Add(newModel);
                    }
                    if (model.Count > 0)
                    {
                        return model;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Roles> GetRoles()
        {
            try
            {
                List<Roles> model = new List<Roles>();
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetRoles";
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    while (sqlDataRdr.Read())
                    {
                        Roles newRole = new Roles();

                        newRole.RoleId = sqlDataRdr["RoleId"].ToString();
                        newRole.Role = sqlDataRdr["Role"].ToString();
                        model.Add(newRole);
                    }
                    if (model.Count > 0)
                    {
                        return model;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<SalesReportQueryModel> GetSalesReport(string minDate, string MaxDate, string userId)
        {
            try
            {
                List<SalesReportQueryModel> model = new List<SalesReportQueryModel>();
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetSalesReport";
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@minDate", minDate);
                    cmd.Parameters.AddWithValue("@maxDate", MaxDate);
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    while (sqlDataRdr.Read())
                    {
                        SalesReportQueryModel sR = new SalesReportQueryModel();
                        sR.User = sqlDataRdr["User"].ToString();
                        sR.TotalVehicles = (int)sqlDataRdr["TotalVehicles"];
                        sR.TotalSales = (decimal)sqlDataRdr["TotalSales"];
                        
                        model.Add(sR);
                    }
                    if (model.Count > 0)
                    {
                        return model;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public Specials GetSpecialById(int id)
        {
            try
            {
                Specials model = null;
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetSpecialById";
                    cmd.Parameters.AddWithValue("@SpecialId", id);
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    if (sqlDataRdr.Read())
                    {
                        model = new Specials();
                        model.SpecialsId = (int)sqlDataRdr["SpecialsId"];
                        model.Title =  sqlDataRdr["Title"].ToString();
                        model.Description = sqlDataRdr["Description"].ToString();
                    }
                    return model;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Specials> GetSpecials()
        {
            try
            {
                List<Specials> model = new List<Specials>();
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetSpecials";
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    while (sqlDataRdr.Read())
                    {
                        Specials newSpec = new Specials();
                        newSpec.SpecialsId = (int)sqlDataRdr["SpecialsId"];
                        newSpec.Description = sqlDataRdr["Description"].ToString();
                        newSpec.Title = sqlDataRdr["Title"].ToString();
                        model.Add(newSpec);
                    }
                    if (model.Count > 0)
                    {
                        return model;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public User GetUserById(string id)
        {
            try
            {

                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetUserById";
                    cmd.Parameters.AddWithValue("@UserId", id);
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    while (sqlDataRdr.Read())
                    {
                        User newModel = new User();
                        newModel.UserId = sqlDataRdr["UserId"].ToString();
                        newModel.UserName = sqlDataRdr["UserName"].ToString();
                        newModel.FirstName = sqlDataRdr["FirstName"].ToString();
                        newModel.LastName = sqlDataRdr["LastName"].ToString();
                        newModel.Role = sqlDataRdr["Role"].ToString();
                        newModel.RoleId = sqlDataRdr["RoleId"].ToString();
                        newModel.Email = sqlDataRdr["Email"].ToString();
                        return newModel;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                List<User> model = new List<User>();
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetUsers";
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    while (sqlDataRdr.Read())
                    {
                        User newUser = new User();
                        newUser.UserId = sqlDataRdr["UserId"].ToString();
                        newUser.UserName = sqlDataRdr["UserName"].ToString();
                        newUser.FirstName = sqlDataRdr["FirstName"].ToString();
                        newUser.LastName = sqlDataRdr["LastName"].ToString();
                        newUser.RoleId = sqlDataRdr["RoleId"].ToString();
                        newUser.Role = sqlDataRdr["Role"].ToString();
                        newUser.Email = sqlDataRdr["Email"].ToString();
                        model.Add(newUser);
                    }
                    if (model.Count > 0)
                    {
                        return model;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public VehicleQueryModel GetVehicleDetail(int id)
        {
            try
            {
                VehicleQueryModel model = null;
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetVehicleById";
                    cmd.Parameters.AddWithValue("@VehicleId", id);
                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();


                    if (sqlDataRdr.Read())
                    {
                        model = new VehicleQueryModel();
                        model.VehicleId = (int)sqlDataRdr["VehicleId"];
                        model.Year = (int)sqlDataRdr["Year"];
                        model.VIN = sqlDataRdr["VIN"].ToString();
                        model.TransmissionType = sqlDataRdr["TransmissionType"].ToString();
                        model.ConditionType = sqlDataRdr["ConditionType"].ToString();
                        model.BodyStyle = sqlDataRdr["BodyStyle"].ToString();
                        model.InteriorColor = sqlDataRdr["InteriorColor"].ToString();
                        model.ExteriorColor = sqlDataRdr["ExteriorColor"].ToString();
                        model.MSRP = (decimal)sqlDataRdr["MSRP"];
                        model.Mileage = (decimal)sqlDataRdr["Mileage"];
                        model.SalePrice = (decimal)sqlDataRdr["SalePrice"];
                        model.Description = sqlDataRdr["Description"].ToString();
                        if (sqlDataRdr["ImageFileName"] != DBNull.Value)
                        {
                            model.ImageFileName = sqlDataRdr["ImageFileName"].ToString();
                        }
                        if (sqlDataRdr["FeaturedFlag"] != DBNull.Value)
                        {
                            model.FeaturedFlag = (bool)sqlDataRdr["FeaturedFlag"];
                        }
                        if (sqlDataRdr["SoldFlag"] != DBNull.Value)
                        {
                            model.SoldFlag = (bool)sqlDataRdr["SoldFlag"];
                        }

                        model.MakeId = (int)sqlDataRdr["MakeId"];
                        model.MakeDescription = sqlDataRdr["MakeDescription"].ToString();
                        model.ModelId = (int)sqlDataRdr["ModelId"];
                        model.Description = sqlDataRdr["Description"].ToString();
                        model.SalePrice = (decimal)sqlDataRdr["SalePrice"];
                        model.UserId = sqlDataRdr["UserId"].ToString();
                        model.ModelDescription = sqlDataRdr["ModelDescription"].ToString();
                    }
                    return model;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<VehicleQueryModel> GetVehicles(int minYear, int maxYear, decimal minPrice, decimal maxPrice, string searchTerm, string condition)
        {
            try
            {
                List<VehicleQueryModel> model = new List<VehicleQueryModel>();

                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetVehicles";
                    cmd.Parameters.AddWithValue("@MinPrice",(decimal)minPrice);
                    cmd.Parameters.AddWithValue("@MaxPrice", (decimal)maxPrice);
                    cmd.Parameters.AddWithValue("@MinYear", (int)minYear);
                    cmd.Parameters.AddWithValue("@MaxYear", (int)maxYear);
                    cmd.Parameters.AddWithValue("@Condition", string.IsNullOrEmpty(condition) ? null : condition);
                    cmd.Parameters.AddWithValue("@SearchTerm", string.IsNullOrEmpty(searchTerm) ? null : searchTerm);

                    sqlConnection.Open();
                    SqlDataReader sqlDataRdr = cmd.ExecuteReader();

                    while (sqlDataRdr.Read())
                    {
                        VehicleQueryModel vm = new VehicleQueryModel();
                        vm.VehicleId = (int)sqlDataRdr["VehicleId"];
                        vm.Year = (int)sqlDataRdr["Year"];
                        vm.VIN = sqlDataRdr["VIN"].ToString();
                        vm.TransmissionType = sqlDataRdr["TransmissionType"].ToString();
                        vm.ConditionType = sqlDataRdr["ConditionType"].ToString();
                        vm.BodyStyle = sqlDataRdr["BodyStyle"].ToString();
                        vm.InteriorColor = sqlDataRdr["InteriorColor"].ToString();
                        vm.ExteriorColor = sqlDataRdr["ExteriorColor"].ToString();
                        vm.MSRP = (decimal)sqlDataRdr["MSRP"];
                        vm.Mileage = (decimal)sqlDataRdr["Mileage"];
                        vm.Description = sqlDataRdr["Description"].ToString();
                        vm.ModelDescription = sqlDataRdr["ModelDescription"].ToString();

                        if (sqlDataRdr["ImageFileName"] != DBNull.Value)
                        {
                            vm.ImageFileName = sqlDataRdr["ImageFileName"].ToString();
                        }
                        if (sqlDataRdr["FeaturedFlag"] != DBNull.Value)
                        {
                            vm.FeaturedFlag = (bool)sqlDataRdr["FeaturedFlag"];
                        }
                        if (sqlDataRdr["SoldFlag"] != DBNull.Value)
                        {
                            vm.SoldFlag = (bool)sqlDataRdr["SoldFlag"];
                        }

                        vm.MakeId = (int)sqlDataRdr["MakeId"];
                        vm.MakeDescription = sqlDataRdr["MakeDescription"].ToString();
                        vm.ModelId = (int)sqlDataRdr["ModelId"];
                        vm.Description = sqlDataRdr["Description"].ToString();
                        vm.SalePrice = (decimal)sqlDataRdr["SalePrice"];
                        vm.UserId = sqlDataRdr["UserId"].ToString();
                        model.Add(vm);
                    }
                    if (model.Count > 0)
                    {
                        return model;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Sales PurchaseVehicle(Sales model)
        {
            try
            {
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sqlConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PurchaseVehicle";
                    cmd.Parameters.AddWithValue("@CustomerName", model.CustomerName.ToString());
                    cmd.Parameters.AddWithValue("@Street1", model.Street1.ToString());
                    cmd.Parameters.AddWithValue("@Street2", string.IsNullOrEmpty(model.Street2) ? string.Empty : model.Street2.ToString());
                    cmd.Parameters.AddWithValue("@City", model.City.ToString());
                    cmd.Parameters.AddWithValue("@State", model.State.ToString());
                    cmd.Parameters.AddWithValue("@ZipCode", model.ZipCode.ToString());
                    cmd.Parameters.AddWithValue("@VehicleId", model.VehicleId);
                    cmd.Parameters.AddWithValue("@PurchasePrice", model.PurchasePrice);
                    cmd.Parameters.AddWithValue("@PurchaseType", model.PurchaseType.ToString());
                    cmd.Parameters.AddWithValue("@UserId", model.UserId.ToString());
                    cmd.Parameters.Add(new SqlParameter("@NewID", SqlDbType.Int));
                    cmd.Parameters["@NewID"].Direction = ParameterDirection.Output;
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    model.SalesId = (int)cmd.Parameters["@NewID"].Value;
                }
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
