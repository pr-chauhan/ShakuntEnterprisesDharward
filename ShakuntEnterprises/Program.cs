using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ShakuntEnterprisesDharward.Models;
using NToastNotify;

//=========================================================



var builder = WebApplication.CreateBuilder(args);
//==========toaster===========
builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
{
    ProgressBar = true,
    Timeout = 5000
});
//==========toaster===========
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<crmDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ShakuntEnterprisesDharwardContext>(options => options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptionAction =>
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
app.UseCors(builder =>
        builder
        .WithOrigins("http://localhost:8080", "http://192.168.1.101:8080", "http://192.168.1.101:9000", "http://localhost:9000")
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        );

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();
//==========toaster===========
app.UseNToastNotify();
app.MapRazorPages();
//==========toaster===========
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
