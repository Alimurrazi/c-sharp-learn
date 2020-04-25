using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<Category> Categories{get;set;}
        public DbSet<Product> Products{get;set;}

        public DbSet<SuperShop> SuperShops{get;set;}

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){

        }
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<SuperShop>().ToTable("SuperShops");
            builder.Entity<SuperShop>().HasKey(p => p.Id);
            builder.Entity<SuperShop>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SuperShop>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<SuperShop>().Property(p => p.Url).IsRequired().HasMaxLength(300);
            builder.Entity<SuperShop>().HasData(
                new SuperShop{Id=100, Name="Daraz", Url="https://www.daraz.com.bd"}
            );

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().Property(p => p.TitleInUrl).HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).
                HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData(
                new Category{Id=100, Name="Fruits and Vegetables"},
                new Category{Id=101, Name="Dairy"},
                new Category{Id=102, SupserShopId=100, Name="Mobiles", TitleInUrl="smartphones"}
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            builder.Entity<Product>().HasData
            (
            new Product
            {
            Id = 100,
            Name = "Apple",
            QuantityInPackage = 1,
            UnitOfMeasurement = EUnitOfMeasurement.Unity,
            Price = "105$",
            CategoryId = 100
            },
            new Product
            {
            Id = 101,
            Name = "Milk",
            QuantityInPackage = 2,
            UnitOfMeasurement = EUnitOfMeasurement.Liter,
            Price = "110$",
            CategoryId = 101,
            }
    );

        }
    }
}