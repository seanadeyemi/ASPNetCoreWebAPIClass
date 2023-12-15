
using ASPNetCoreWebAPIClass.Domain.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebAPIClass.Domain.Data;

public class ECommerceContext : DbContext
{
    public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductSize> ProductSizes { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<BannerImage> BannerImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
             .HasKey(p => p.Id);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.AvailableColors)
            .WithOne()
            .IsRequired();

        modelBuilder.Entity<Product>()
            .HasMany(p => p.AvailableSizes)
            .WithOne()
            .IsRequired();


        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryId);
    }
}
