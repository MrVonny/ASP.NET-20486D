using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupcakes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Cupcakes.Data
{
    public class CupcakeContext : DbContext
    {
        public CupcakeContext(DbContextOptions<CupcakeContext> options) : base(options)
        {

        }

        public DbSet<Cupcake> Cupcakes { get; set; }
        public DbSet<Bakery> Bakeries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity(typeof(Bakery)).HasData(
                new { BakeryId = 1, BakeryName = "Gluteus Free", Addres = "635 Brighton Circle Road", Quantity = 8 },
                new { BakeryId = 2, BakeryName = "Cupcakes Break", Addres = "4323 Jerome Avenue", Quantity = 22 },
                new { BakeryId = 3, BakeryName = "Cupcakes Ahead", Addres = "2553 Pin Oak Drive", Quantity = 18 },
                new { BakeryId = 4, BakeryName = "Sugar", Addres = "1608 Charles Street", Quantity = 30 }
               );

            modelBuilder.Entity(typeof(Cupcake)).HasData(
                new { CupcakeId = 1, CupcakeType = CupcakeType.Birthday, Description = "Vanilla cupcake with coconut cream", GlutenFree = true, Price = 2.5d, BakeryId = 1, ImageMimeType = "image/jpeg", ImageName = "birthday-cupcake.jpg" },
                new { CupcakeId = 2, CupcakeType = CupcakeType.Chocolate, Description = "Chocolate cupcake with caramel filling and chocolate butter cream", GlutenFree = false, Price = 3.2d, BakeryId = 2, ImageMimeType = "image/jpeg", ImageName = "chocolate-cupcake.jpg" },
                new { CupcakeId = 3, CupcakeType = CupcakeType.Strawberry, Description = "Chocolate cupcake with straberry cream filling", GlutenFree = false, Price = 4d, BakeryId = 3, ImageMimeType = "image/jpeg", ImageName = "pink-cupcake.jpg" },
                new { CupcakeId = 4, CupcakeType = CupcakeType.Turquoise, Description = "Vanilla cupcake with butter cream", GlutenFree = true, Price = 1.5d, BakeryId = 4, ImageMimeType = "image/jpeg", ImageName = "turquoise-cupcake.jpg" }
               );

        }

    }
}
