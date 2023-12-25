using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webshop.Models;

    public class WebshopContext : DbContext
    {
        public WebshopContext (DbContextOptions<WebshopContext> options)
            : base(options)
        {
        }

        public DbSet<Webshop.Models.Product> Product { get; set; } = default!;
    }
