using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using RaportHelper.Models;

namespace RaportHelper.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Sessions> Sessions { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }
}