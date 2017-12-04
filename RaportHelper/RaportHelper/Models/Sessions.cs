using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaportHelper.Models
{
    public class Sessions
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public string Administrator { get; set; }
        public string Token { get; set; }
        public bool Ready { get; set; }
        public DateTime Deadline { get; set; }

    }
}
