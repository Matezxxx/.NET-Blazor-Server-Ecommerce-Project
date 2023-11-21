
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EcommerceProject.App.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace EcommerceProject.App.Data.Models.Entities;


public class ApplicationContext : IdentityDbContext<User,Role,int>{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<BrandLogo> BrandLogos { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<EmailTemplate> EmailTemplates { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

}
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    //  {
    // Order product
    //   modelBuilder.Entity<ProductOrder>()
    //.HasKey(op => new { op.OrderId, op.ProductId });
    //modelBuilder.Entity<ProductOrder>()
    //  .HasOne(op => op.Order)
    //.WithMany(o => o.ProductOrders)
    //.HasForeignKey(op => op.OrderId)
    //.OnDelete(DeleteBehavior.Restrict);

    //        modelBuilder.Entity<ProductOrder>()
    //          .HasOne(op => op.Product)
    //        .WithMany(p => p.ProductOrders)
    //      .HasForeignKey(op => op.ProductId)
    //    .OnDelete(DeleteBehavior.Restrict);
    // base.OnModelCreating(modelBuilder);
    //}




