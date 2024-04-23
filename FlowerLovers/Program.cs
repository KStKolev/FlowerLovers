using FlowerLovers.Core.Contracts.ApplicationServices;
using FlowerLovers.Core.Contracts.IdentityServices;
using FlowerLovers.Core.Services.ApplicationUserService;
using FlowerLovers.Core.Services.IdentityServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity();
builder.Services.AddTransient<IApplicationServiceUser, ApplicationUserService>();
builder.Services.AddTransient<IRegisterService, RegisterService>();
builder.Services.AddTransient<ILogInService, LogInService>();
builder.Services.AddTransient<IResetPasswordService, ResetPasswordService>();
builder.Services.AddTransient<IForgotPasswordService, ForgotPasswordService>();
builder.Services.AddTransient<ILogOutService, LogOutService>();
builder.Services.AddTransient<IChangePasswordService, ChangePasswordService>();
builder.Services.AddTransient<IPersonalDataService, PersonalDataService>();
builder.Services.AddTransient<IDeletePersonalDataService, DeletePersonalDataService>();

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
