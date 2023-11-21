using EcommerceProject.App.Data;
using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Data.Models.Seed;
using EcommerceProject.App.Data.Models.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.IISIntegration;
using Radzen;
using System.Net.Mail;
using EcommerceProject.App.Data.Models.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRadzenComponents();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContextFactory<ApplicationContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddTransient<IProductService,ProductService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IBrandService, BrandService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IBrandLogoService, BrandLogoService>();
builder.Services.AddTransient<IOrderService,OrderService>();
builder.Services.AddTransient<IEmailTemplateService, EmailTemplateService>();

//builder.Services.AddIdentity<User,Role>(options=>options.SignIn.RequireConfirmedAccount=true)
//    .AddRoles<Role>()
//    .AddUserManager<UserManager<User>>()
//    .AddRoleManager<RoleManager<Role>>()
//    .AddEntityFrameworkStores<ApplicationContext>();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = IISServerDefaults.AuthenticationScheme;
//});



//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = options.DefaultPolicy;
//});

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
 



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS s is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host"); // Zde zmìòte na vaši stránku


var scope = app.Services.CreateScope();
//var seeder = new Seeder(app.Services.GetRequiredService<IDbContextFactory<ApplicationContext>>(), scope.ServiceProvider.GetRequiredService<RoleManager<Role>>(),scope.ServiceProvider.GetRequiredService<UserManager<User>>());

//await seeder.SeedDatabase();
app.Run();