using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.Implementation;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;
using UTB.Eshop.Infrastructure.Database;
using UTB.Eshop.Infrastructure.Identity;
using UTB.Eshop.Infrastructure.Repository;
using UTB.Eshop26.Web.Validations.Adapters.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = MySqlServerVersion.AutoDetect(connectionString);
if (serverVersion == null)
{
    //if the AutoDetect() does not work, you can specify the version manually
    serverVersion = new MySqlServerVersion("8.0.43");
}
builder.Services.AddDbContext<EshopDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));

//Configuration for Identity
builder.Services.AddIdentity<User, Role>()
     .AddEntityFrameworkStores<EshopDbContext>()
     .AddDefaultTokenProviders();

//validation adapter providers registration
builder.Services.AddSingleton<ValidationAttributeAdapterProvider>();
builder.Services.AddSingleton<IValidationAttributeAdapterProvider, ClientValidationAttributeAdapterProvider>();

//repository registration
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICarouselRepository, CarouselRepository>();

//registration of application services
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<ICarouselAppService, CarouselAppService>();
builder.Services.AddScoped<IHomeService, HomeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
