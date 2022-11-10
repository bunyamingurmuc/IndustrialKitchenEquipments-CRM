using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using IndustrialKitchenEquipmentsCRM.DAL.Configurations;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using IndustrialKitchenEquipmentsCRM.Entities.Card;
using IndustrialKitchenEquipmentsCRM.Entities.Category;
using IndustrialKitchenEquipmentsCRM.Entities.Customer;
using IndustrialKitchenEquipmentsCRM.Entities.Image;
using IndustrialKitchenEquipmentsCRM.Entities.Stock;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IndustrialKitchenEquipmentsCRM.DAL.Context
{
    public class IndustrialKitchenEquipmentsContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public IndustrialKitchenEquipmentsContext(DbContextOptions<IndustrialKitchenEquipmentsContext> options) : base(options)
        {
        }

        public DbSet<Stock>? Stocks { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Card>? Cards { get; set; }
        public DbSet<CardItem>? CardItems { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<CardItem>().Navigation(x => x.Stock).AutoInclude();
            builder.ApplyConfiguration(new StockConfigurations());
            base.OnModelCreating(builder);

        }
    }
}
