using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Models.Tables
{
    public class Model
    {
        public int ModelId { get; set; }
        public int MakeId { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string DateAdded { get; set; }
        public string MakeDescription { get; set; }
    }
}
