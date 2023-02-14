using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using WareHouseMVC.Domain.Interface;
using WareHouseMVC.Infrastructure;
using WareHouseMVC.Infrastructure.Repositories;
using WareHouseMVC.Application;
using FluentValidation.AspNetCore;
using FluentValidation;
using WareHouseMVC.Application.ViewModel.Customer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));  //connectionString
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Context>();
builder.Services.AddControllersWithViews();

//builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
//builder.Services.AddTransient<IItemRepository, ItemRepository>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

//builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddRazorPages();

builder.Services.AddTransient<IValidator<NewCustomerVm>, NewCustomerValidation>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

