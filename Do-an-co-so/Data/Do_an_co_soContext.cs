using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Do_an_co_so.Models;

namespace Do_an_co_so.Data
{
    public class Do_an_co_soContext : DbContext
    {
        public Do_an_co_soContext (DbContextOptions<Do_an_co_soContext> options)
            : base(options)
        {
        }

        public DbSet<Do_an_co_so.Models.Blog> Blog { get; set; } = default!;

        public DbSet<Do_an_co_so.Models.Product>? Product { get; set; }

        public DbSet<Do_an_co_so.Models.Customer>? Customer { get; set; }

        public DbSet<Do_an_co_so.Models.Categories>? Categories { get; set; }
    }
}
