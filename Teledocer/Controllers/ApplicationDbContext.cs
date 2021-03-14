using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teledocer.Models;

namespace Teledocer.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Clients> Clients { get; set; }
        public DbSet<founder> founder { get; set; }
        public DbSet<Types> Types { get; set; }
    
}
}
