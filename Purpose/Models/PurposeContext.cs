using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purpose.Models
{
    public class PurposeContext : DbContext
    {
        DbSet<Purpose> Purposes { get; set; }

        public PurposeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
