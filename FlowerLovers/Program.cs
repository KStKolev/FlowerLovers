using FlowerLovers.Core.Contracts;
using FlowerLovers.Core.Services.ApplicationUserService;
using FlowerLovers.Core.Services.IdentityServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity();
builder.Services.AddTransient<IApplicationServiceUser, ApplicationUserService>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<ILogInService, LogInService>();
builder.Services.AddScoped<IResetPasswordService, ResetPasswordService>();
builder.Services.AddScoped<IForgotPasswordService, ForgotPasswordService>();

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

// Use default static files from www.root folder.
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
