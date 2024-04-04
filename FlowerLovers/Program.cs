using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FlowerLovers.Data.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FlowerLoversDbContextConnection") ?? throw new InvalidOperationException("Connection string 'FlowerLoversDbContextConnection' not found.");

builder.Services.AddDbContext<FlowerLoversDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<FlowerLoversDbContext>();

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

app.Run();
