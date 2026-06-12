using Journey.Services;
using Journey.Services.Contracts;
using Journey.Storage.Contracts;
using Journey.Storage.EFStorage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<JourneyContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddScoped<IReader, JourneyContext>();
builder.Services.AddScoped<IWriter, JourneyContext>();
builder.Services.AddScoped<IToursRepository, ToursRepository>();
builder.Services.AddScoped<ITourService, ToursService>();


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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tours}/{action=Collection}/{id?}")
    .WithStaticAssets();


app.Run();
