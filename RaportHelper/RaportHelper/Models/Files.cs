using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaportHelper.Models
{
    public class Files
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
