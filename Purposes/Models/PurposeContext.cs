using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purposes.Models
{
    public class PurposeContext : DbContext
    {
        public DbSet<Purpose> Purposes { get; set; }

        public PurposeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
