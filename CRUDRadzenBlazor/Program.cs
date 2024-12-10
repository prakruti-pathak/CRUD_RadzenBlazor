using CRUDRadzenBlazor.Components;
using CRUDRadzenBlazor.Models;
using CRUDRadzenBlazor.Repositories;
using CRUDRadzenBlazor.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<DialogService>();

builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("mydb"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
