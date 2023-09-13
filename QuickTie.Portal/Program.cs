using DevExpress.Blazor;
using QuickTie.Portal.Models;
using AspNetCore.Identity.Mongo;
using Microsoft.Extensions.Options;
using QuickTie.Data.Models;
using QuickTie.Data;
using QuickTie.Cloud.Repository;
using QuickTie.Portal.Data.Repository.Services;
using QuickTie.Portal.Data.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<ILocalStorageRepository, LocalStorageRepository>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrder, OrderService>();
builder.Services.AddSingleton<HttpClient>(); // Add this line

//MongDB connection
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.AddSingleton(typeof(IMongoRepository<>), typeof(MongoRepository<>));
builder.Services.AddIdentityMongoDbProvider<QuickTieUser, QuickTieRole>(identity =>
{
    identity.Password.RequiredLength = 8;
},
mongo =>
{
    mongo.ConnectionString = builder.Configuration.GetSection("MongoDBSettings")["ConnectionString"];
    mongo.UsersCollection = "users";
    mongo.RolesCollection = "roles";
});

builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
