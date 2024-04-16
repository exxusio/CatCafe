using BusinessLayer;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PresentationLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataBaseContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

//builder.Services.AddSession();

AddTransient();


//======
//builder.Services.AddDefaultIdentity<IdentityUser>(options
//    => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<DataBaseContext>();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/login";
//    options.ReturnUrlParameter = "ReturnUrl";
//});
//======


builder.Services.AddControllersWithViews();

var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404)
    {
        context.Response.Redirect("/");
    }
});

app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value;
    if (path.StartsWith("/identity"))
    {
        context.Response.Redirect("/login");
        return;
    }
    await next();
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Main",
    pattern: "{action}/{id?}",
    defaults: new { controller = "Main", action = "main" });

app.MapControllerRoute(
    name: "Authentication",
    pattern: "{action}/{id?}",
    defaults: new { controller = "Authentication", action = "login" });

app.MapControllerRoute(
    name: "AdminPanel",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "AdminPanel" });

app.MapGet("/main", () => { return Results.Redirect("/"); });


//======
//app.MapRazorPages();
//======


app.Run();



void AddTransient()
{
    builder.Services.AddTransient<IVisitorsRepository, VisitorsRepository>();
    builder.Services.AddTransient<IAccountsRepository, AccountsRepository>();

    builder.Services.AddTransient<ICatsRepository, CatsRepository>();
    builder.Services.AddTransient<IBreedsRepository, BreedsRepository>();

    builder.Services.AddTransient<IReservationsRepository, ReservationsRepository>();
    builder.Services.AddTransient<IReservationCatsRepository, ReservationCatsRepository>();
    builder.Services.AddTransient<IReservationTablesRepository, ReservationTablesRepository>();

    builder.Services.AddTransient<IEmployeesRepository, EmployeesRepository>();
    builder.Services.AddTransient<IPositionsRepository, PositionsRepository>();

    builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
    builder.Services.AddTransient<IProductTypesRepository, ProductTypesRepository>();

    builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();
    builder.Services.AddTransient<IContentsRepository, ContentsRepository>();

    builder.Services.AddTransient<IReviewsRepository, ReviewsRepository>();

    builder.Services.AddTransient<ITablesRepository, TablesRepository>();

    builder.Services.AddTransient<IEventsRepository, EventsRepository>();

    builder.Services.AddScoped<DataManager>();


    builder.Services.AddScoped<ServicesManager>();
}
