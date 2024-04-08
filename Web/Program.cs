var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<CatCafeContext>(options =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("CatCafeDataBase");
//    options.UseNpgsql(connectionString);
//});

//builder.Services.AddDefaultIdentity<IdentityUser>(options
//    => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<CatCafeContext>();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/login";
//    options.ReturnUrlParameter = "ReturnUrl";
//});

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
    name: "catcafe",
    pattern: "{action}/{id?}",
    defaults: new { controller = "catcafe", action = "main" });

app.MapControllerRoute(
    name: "authentication",
    pattern: "{action}/{id?}",
    defaults: new { controller = "authentication", action = "login" });

app.MapGet("/main", () => { return Results.Redirect("/"); });

//app.MapRazorPages();

app.Run();
