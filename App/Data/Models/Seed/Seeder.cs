using Microsoft.EntityFrameworkCore;
using Bogus;
using EcommerceProject.App.Data;
using EcommerceProject.App.Data.Models.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace EcommerceProject.App.Data.Models.Seed
{
    public class Seeder
    {
        private List<string> roles = new List<string>() { "Admin", "User" };
        private IDbContextFactory<ApplicationContext> _ctx { get; set; }
        private RoleManager<Role> _roleManager { get; set; }
        private UserManager<User>_userManager { get; set; }
        public Seeder(IDbContextFactory<ApplicationContext> ctx, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _ctx = ctx;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task SeedDatabase()
        {
            using var dbContext = _ctx.CreateDbContext();
            {
                dbContext.RemoveRange(dbContext.UserRoles.ToList());
                dbContext.RemoveRange(dbContext.Users.ToList());
                dbContext.RemoveRange(dbContext.Roles.ToList());
                dbContext.RemoveRange(dbContext.Categories.ToList());
                dbContext.RemoveRange(dbContext.Brands.ToList());
                dbContext.RemoveRange(dbContext.Customers.ToList());
                dbContext.RemoveRange(dbContext.Products.ToList());
                dbContext.RemoveRange(dbContext.Orders.ToList());
               await dbContext.SaveChangesAsync();

                var userGenerator = GetUserGenerator();
                var generatedUsers = userGenerator.Generate(10);

                var categoryGenerator = GetCategoryGenerator();
                var generatedCategories = categoryGenerator.Generate(10);
                dbContext.Categories.AddRange(generatedCategories);
                await dbContext.SaveChangesAsync();

                var brandGenerator = GetBrandGenerator();
                var generatedBrands = brandGenerator.Generate(10);
                dbContext.Brands.AddRange(generatedBrands);
                await dbContext.SaveChangesAsync();

                var customerGenerator = GetCustomerGenerator();
                var generatedCustomers = customerGenerator.Generate(10);
                dbContext.Customers.AddRange(generatedCustomers);
                await dbContext.SaveChangesAsync();

                

                await SeedRolesAsync();
                await SeedUsersAsync(generatedUsers);
                
                await AssignToRolesAsync(dbContext.Users.ToList());
                await dbContext.SaveChangesAsync();

                var productGenerator = GetProductGenerator(dbContext);
                var generatedProducts = productGenerator.Generate(15);
                dbContext.Products.AddRange(generatedProducts);
                await dbContext.SaveChangesAsync();

                var orderGenerator = GetOrderGenerator(dbContext,generatedProducts);
                var generatedOrders = orderGenerator.Generate(10);
                dbContext.Orders.AddRange(generatedOrders);
                await dbContext.SaveChangesAsync();

               

            }

        }
        private static Faker<User> GetUserGenerator()
        {
            var userIds = 1;
            return new Faker<User>()
                .RuleFor(v => v.UserName, f => f.Name.FirstName());
        }
        private static Faker<Product> GetProductGenerator(ApplicationContext dbContext)
        {

            var BrandIds = dbContext.Brands.Select(b => b.BrandId).ToList();
            var CatIds = dbContext.Categories.Select(b => b.CategoryId).ToList();
            var OrdIds = dbContext.Orders.Select(b => b.OrderId).ToList();
            var productIds = dbContext.Products.Select(c => c.ProductId).ToList();

            return new Faker<Product>()
            .RuleFor(v => v.CategoryId, f => f.PickRandom(CatIds))
             
            .RuleFor(v => v.BrandId, f => f.PickRandom(BrandIds))
            .RuleFor(v => v.ProductName, f => f.Commerce.ProductName())
            .RuleFor(v => v.Price, f => f.Random.Decimal(1,999))


             .RuleFor(v => v.StockQuantity, f => f.PickRandom(1,2,3));

        }
        private static Faker<Category> GetCategoryGenerator()
        {
            var catIds = 1;
            return new Faker<Category>().RuleFor(v => v.CategoryName, f => f.Commerce.ProductName());

        }
        private static Faker<Brand> GetBrandGenerator()
        {
            var brandIds = 1;
            return new Faker<Brand>().RuleFor(v => v.BrandName, f => f.Commerce.ProductName());

        }
        private static Faker<Customer> GetCustomerGenerator()
        {
            var custIds = 1;
            return new Faker<Customer>().RuleFor(v => v.CustomerName, f => f.Person.UserName)
            .RuleFor(v => v.CustomerPhone, f => "+420" + f.Random.Number(100000000, 999999999).ToString())
            .RuleFor(v => v.CustomerEmail, f => f.Person.Email);

        }
        private static Faker<Order> GetOrderGenerator(ApplicationContext dbContext, List<Product>products)
         {
            var customerIds = dbContext.Customers.Select(c => c.CustomerId).ToList();

            var ProductIds = dbContext.Products.ToList();
            var custIds = dbContext.Customers.ToList();
         var ordIds = 1;
            return new Faker<Order>()
                .RuleFor(v => v.Processed, f => f.PickRandom((int)Processed2.CekaNaZpracovani, (int)Processed2.Zpracovano))
                .RuleFor(v => v.CustomerId, f => f.PickRandom(custIds).CustomerId)
                .RuleFor(o => o.Customer, f => f.PickRandom(custIds))
                .RuleFor(v => v.Products, f => f.PickRandom(products, f.Random.Number(1,2)).ToList());


        }
        private async Task SeedRolesAsync()
        {
            
            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(new Role(role));
            }
        }
        private async Task SeedUsersAsync(List<User> Users)
        {
            foreach (var user in Users) 
            {
            await _userManager.CreateAsync(user);
            }
        }
        private async Task AssignToRolesAsync(List<User> dbUsers)
        {
            foreach (var dbuser in dbUsers)
            {
                var user = await _userManager.FindByIdAsync(dbuser.Id.ToString());
                await _userManager.AddToRoleAsync(user, roles.First());
            }
        }
    }
}



