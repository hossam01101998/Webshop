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
        public DbSet<Webshop.Models.ShoppingCar> ShoppingCar { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShoppingCar>()
            .HasKey(sc => sc.ProductId);

        modelBuilder.Entity<ShoppingCar>()
            .HasOne(sc => sc.Product)
            .WithMany(p => p.ShoppingCarItems)
            .HasForeignKey(sc => sc.ProductId);
    }


}
