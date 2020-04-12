using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPizza.Models;

namespace PPizza.Data
{
    public class MvcOrderContext : IdentityDbContext
    {
        public MvcOrderContext(DbContextOptions<MvcOrderContext> options)
            : base(options)
        {
        }

        public DbSet<MvcOrder> Order{ get; set; }
    }
}
