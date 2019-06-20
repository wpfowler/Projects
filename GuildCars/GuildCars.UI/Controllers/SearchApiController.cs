using GuildCars.Data.Factories;
using GuildCars.Models.Models.Queries;
using GuildCars.Models.Models.Tables;
using System.Collections.Generic;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class SearchApiController : ApiController
    {
        [AllowAnonymous]
        [Route("api/inventory")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetNew(int minYear, int maxYear, decimal minPrice, decimal maxPrice, string searchTerm, string condition)
        {
            var repo = RepositoryFactory.GetRepository();
            List<VehicleQueryModel> Search = new List<VehicleQueryModel>();
            Search = repo.GetVehicles(minYear, maxYear, minPrice, maxPrice, searchTerm, condition);
            return Ok(Search);
        }
        [AllowAnonymous]
        [Route("api/inventory/used")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetUsed(int minYear, int maxYear, decimal minPrice, decimal maxPrice, string searchTerm, string condition)
        {
            var repo = RepositoryFactory.GetRepository();
            List<VehicleQueryModel> Search = new List<VehicleQueryModel>();
            Search = repo.GetVehicles(minYear, maxYear, minPrice, maxPrice, searchTerm, condition);
            return Ok(Search);
        }
        [AllowAnonymous]
        [Route("api/inventory/details")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDetails(int minYear, int maxYear, decimal minPrice, decimal maxPrice, string searchTerm, string condition)
        {
            var repo = RepositoryFactory.GetRepository();
            List<VehicleQueryModel> Search = new List<VehicleQueryModel>();
            Search = repo.GetVehicles(minYear, maxYear, minPrice, maxPrice, searchTerm, condition);
            return Ok(Search);
        }

        [Route("api/models")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModels(int MakeId)
        {
            var repo = RepositoryFactory.GetRepository();
            List<Model> Search = new List<Model>();
            Search = repo.GetModelsByMakeId(MakeId);
            return Ok(Search);
        }

        [Authorize(Roles = "admin")]
        [Route("api/report/sales")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSalesReport(string userId, string fromDate, string toDate)
        {
            var repo = RepositoryFactory.GetRepository();
            List<SalesReportQueryModel> Search = new List<SalesReportQueryModel>();
            Search = repo.GetSalesReport(fromDate, toDate, userId);
            return Ok(Search);
        }

    }
}
