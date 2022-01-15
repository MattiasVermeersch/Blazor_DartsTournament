using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Pin.DartsTournament.Infrastructure.Data;
using Pin.DartsTournament.Infrastructure.Services;
using Pin.DartsTournament.Core.Interfaces;
using Pin.DartsTournament.Blazor.Interfaces;
using Pin.DartsTournament.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
services.AddRazorPages();
services.AddServerSideBlazor();

services.AddDbContext<DartsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Dependency Injection
services.AddScoped<ITournamentRepository, TournamentRepository>();
services.AddScoped<IPlayerRepository, PlayerRepository>();
services.AddScoped<IRefereeRepository, RefereeRepository>();
services.AddScoped<ILegRepository, LegRepository>();
services.AddScoped<ISetRepository, SetRepository>();
services.AddScoped<IThrowRepository, ThrowRepository>();

services.AddTransient<ITournamentService, TournamentService>();
services.AddTransient<ILegService, LegService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
