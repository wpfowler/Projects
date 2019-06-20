using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Models.Queries
{
    public class InventoryReportsNewUsedQueryModel
    {   //allows two reports to be passed to Inventory cshtml for new/used inventory
        public List<InventoryReportQueryModel> NewInventory { get; set; }
        public List<InventoryReportQueryModel> UsedInventory { get; set; }
    }
}
