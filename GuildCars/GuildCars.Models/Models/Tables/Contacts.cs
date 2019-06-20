using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Models.Tables
{
    public class Contacts
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string  Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
