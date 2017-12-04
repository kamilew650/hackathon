using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaportHelper.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public bool Ready { get; set; }
        public ICollection<Users> AssignedTo { get; set; }
    }

}
