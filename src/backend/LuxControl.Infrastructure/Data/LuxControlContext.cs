using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LuxControl.Core.Models.Management;
using LuxControl.Core.Models.HybridApp;

namespace LuxControl.Infrastructure.Data
{
    public class LuxControlContext : DbContext
    {
        public LuxControlContext(DbContextOptions<LuxControlContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } 
        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<ClientSale> ClientSales { get; set; } 
        public DbSet<Item> Items { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; } 
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<Service> Services { get; set; } 
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ForeignKey de la tabla User.RoleId
            modelBuilder.Entity<User>()
                .HasOne<Role>(r => r.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(r => r.RoleId);


            // ForeignKey de la tabla Client.DevieId
            // modelBuilder.Entity<Client>()
            //     .HasOne<Device>(d => d.Device)
            //     .WithMany(c => c.Clients)
            //     .HasForeignKey(d => d.DeviceId);

            // ForeignKey de la tabla Sale.ClientSaleId
            modelBuilder.Entity<Sale>()
                .HasOne<ClientSale>(cs => cs.ClientSales)
                .WithMany(s => s.Sales)
                .HasForeignKey(cs => cs.ClientSaleId);

            // ForeignKey de la tabla Sale.ItemId
            modelBuilder.Entity<Sale>()
                .HasOne<Item>(i => i.Item)
                .WithMany(s => s.Sales)
                .HasForeignKey(i => i.ItemId);
            
            // ForeignKey de la tabla Item.CategoryId
            modelBuilder.Entity<Item>()
                .HasOne<Category>(c => c.Category)
                .WithMany(i => i.Items)
                .HasForeignKey(c => c.CategoryId);

            // ForeignKey de la tabla Sale.ServiceId
            modelBuilder.Entity<Sale>()
                .HasOne<Service>(sr => sr.Service)
                .WithMany(s => s.Sales)
                .HasForeignKey(sr => sr.ServiceId);

            // ForeignKey de la tabla Sale.SaleDetail
            modelBuilder.Entity<Sale>()
                .HasOne<Item>(i => i.Item)
                .WithMany(s => s.Sales)
                .HasForeignKey(i => i.ItemId);




            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}


