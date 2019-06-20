using System;
using System.Configuration;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Repositories;
namespace GuildCars.Data.Factories
{

    public class LookupValueFactory 

    {
        public static ILookupValueRepository GetRepository()
        {
            string repoType = ConfigurationManager.AppSettings["LookupRepository"].ToString();

            switch (repoType)
            {
                case "InMemory":
                    return new LookupValueRepository(); 
                default:
                    throw new Exception("Invalid Repository Type");
            }
        }
    }
}
