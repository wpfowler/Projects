using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Repositories;
namespace GuildCars.Data.Factories
{
    public static class RepositoryFactory
    {
        public static IRepository GetRepository()
        {
            string repoType = ConfigurationManager.AppSettings["RepositoryType"].ToString();

            switch (repoType)
            {
                case "PROD":
                    return new ADORepository(); //Database
                default:
                    throw new Exception("Invalid Repository Type");
            }
        }
    }

}
  
 