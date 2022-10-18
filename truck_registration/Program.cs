using truck_registration;
using Microsoft.EntityFrameworkCore;
using truck_registration.Repositories.Interfaces;
using truck_registration.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ITruckRepository, TruckRepository>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
