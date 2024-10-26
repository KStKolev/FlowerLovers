using FlowerLovers.Core.Contracts.AccountService;
using FlowerLovers.Core.Contracts.AdminServices;
using FlowerLovers.Core.Contracts.ApplicationServices;
using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.Contracts.IdentityServices;
using FlowerLovers.Core.Contracts.SearchServices;
using FlowerLovers.Core.CustomFilters;
using FlowerLovers.Core.Services.AccountServices;
using FlowerLovers.Core.Services.AdminService;
using FlowerLovers.Core.Services.ApplicationUserService;
using FlowerLovers.Core.Services.ArticleServices;
using FlowerLovers.Core.Services.IdentityServices;
using FlowerLovers.Core.Services.SearchServices;
using FlowerLovers.Data.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FlowerLoversDbContext>();

// Add Identity

builder.Services.AddApplicationIdentity();

// Add custom services
builder.Services.AddTransient<IApplicationServiceUser, ApplicationUserService>();
builder.Services.AddTransient<IRegisterService, RegisterService>();
builder.Services.AddTransient<ILogInService, LogInService>();
builder.Services.AddTransient<IResetPasswordService, ResetPasswordService>();
builder.Services.AddTransient<IForgotPasswordService, ForgotPasswordService>();
builder.Services.AddTransient<ILogOutService, LogOutService>();
builder.Services.AddTransient<IChangePasswordService, ChangePasswordService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IEditAccountService, EditAccountService>();
builder.Services.AddTransient<IAddArticleService, AddArticleService>();
builder.Services.AddTransient<IArticleService, ArticleServices>();
builder.Services.AddTransient<ISaveArticleService, SaveArticleService>();
builder.Services.AddTransient<ISavedArticleService, SavedArticleService>();
builder.Services.AddTransient<ILeaveArticleService, LeaveArticleService>();
builder.Services.AddTransient<IDetailsArticleService, DetailsArticleService>();
builder.Services.AddTransient<IRateService, RateService>();
builder.Services.AddTransient<IEditArticleService, EditArticleService>();
builder.Services.AddScoped<AdminFilter>();
builder.Services.AddTransient<IDeleteArticleService, DeleteArticleService>();
builder.Services.AddTransient<IDeleteUserService, DeleteUserService>();
builder.Services.AddTransient<ISearchArticleService, SearchArticleService>();


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
app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => 
{
    endpoints.MapControllerRoute(
        name: "error",
        pattern: "Error/{statusCode}",
        defaults: new { controller = "Error", action = "HttpStatusCodeHandler" }
        );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
