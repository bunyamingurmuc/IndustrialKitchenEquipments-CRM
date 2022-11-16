using IndustrialKitchenEquipmentsCRM.DAL.Configurations;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using IndustrialKitchenEquipmentsCRM.Entities.Card;
using IndustrialKitchenEquipmentsCRM.Entities.Customer;
using IndustrialKitchenEquipmentsCRM.Entities.Image;
using IndustrialKitchenEquipmentsCRM.Entities.Stock;
using Microsoft.EntityFrameworkCore;

namespace IndustrialKitchenEquipmentsCRM.DAL.Context
{
    public class IndustrialKitchenEquipmentsContext :DbContext
    {
        public IndustrialKitchenEquipmentsContext(DbContextOptions<IndustrialKitchenEquipmentsContext> options) : base(options)
        {
        }
        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<Stock>? Stocks { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Card>? Cards { get; set; }
        public DbSet<CardItem>? CardItems { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Card>().Navigation(x => x.CardItems).AutoInclude();
            builder.Entity<Card>().Navigation(x => x.Customer).AutoInclude();
            builder.Entity<CardItem>().Navigation(x => x.Stock).AutoInclude();
            builder.Entity<Customer>().Navigation(x => x.Cards).AutoInclude();
            builder.Entity<Image>().Navigation(x => x.Stock).AutoInclude();
            builder.Entity<Stock>().Navigation(x => x.Images).AutoInclude();
            builder.Entity<Stock>().Navigation(x => x.CardItems).AutoInclude();
            builder.ApplyConfiguration(new StockConfigurations());
            base.OnModelCreating(builder);

        }
    }
}
