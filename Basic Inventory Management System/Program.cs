using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.IRepository.Auth;
using DataAccessLayer.Repository.Auth;
using ServicesLayer.IService.Auth;
using ServicesLayer.Service.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<IMSDbContext>();

builder.Services.AddDbContext<IMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


//For User Register and Login
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();


//For User Role Management
builder.Services.AddScoped<IRoleManagementRepository, RoleManagementRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
