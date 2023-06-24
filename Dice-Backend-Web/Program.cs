using Dice_Backend_Console.Data;
using Dice_Backend_Console.Business;
using Microsoft.Extensions.DependencyInjection;
using Dice_Backend_Console.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DiceContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Replace with your React frontend URL
               .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var connectionString = @"Server=.\SQLEXPRESS;Database=DiceDB;Trusted_Connection=True;Encrypt=False;";

builder.Host.ConfigureServices( //Bayad ghabl az builder neveshte she
    services =>
    services.AddDbContext<DiceContext>(options => options.UseSqlServer(connectionString))
            .AddScoped<IDiceRepository, DiceRepository>()
            .AddScoped<DiceManager>());

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
app.UseRouting();
app.UseAuthorization();
app.UseCors("AllowReact");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
