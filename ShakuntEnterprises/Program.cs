using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ShakuntEnterprises.Models;


//=========================================================

 

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<crmDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ShakuntEnterprisesContext>(options => options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptionAction =>
{
    sqlOptionAction.EnableRetryOnFailure();
}
));

builder.Services.AddControllersWithViews();
//builder.Services.AddMvc(option => option.Filters.Add(new MenuActionFilter(dBContext)));
builder.Services.AddMvc();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option =>
{

    option.IdleTimeout = TimeSpan.FromSeconds(600);
    //option.Cookie.HttpOnly = true;
    //option.Cookie.IsEssential = true;

});
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

//var iHostBulider = builder.Host.ConfigureDefaults(args)
//    .ConfigureWebHostDefaults(webbuilder =>
//    {
//        webbuilder.UseContentRoot(Directory.GetCurrentDirectory());
//        webbuilder.UseWebRoot("wwwroot");
//    });


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
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
