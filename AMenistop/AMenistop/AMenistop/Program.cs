using BAL.AMenistop.Interfaces;
using BAL.AMenistop.Services;
using DAL.AMenistop;
using DAL.AMenistop.Interfaces;
using DAL.AMenistop.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Services
builder.Services.AddTransient<IStoreItemService, StoreItemService>();

// Repositories
//builder.Services.AddTransient<IStoreItemRepository, StoreItemRepository>();
//builder.Services.AddDbContext<AMenistopContext>(options => options.UseSqlServer(@"Server=.\;Database=AMenistop;Trusted_Connection=True;MultipleActiveResultSets=true"));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
