using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Pin.DartsTournament.Infrastructure.Data;
using Pin.DartsTournament.Infrastructure.Services;
using Pin.DartsTournament.Core.Interfaces;

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
services.AddScoped<ITournamentService, TournamentService>();
services.AddScoped<IPlayerService, PlayerService>();
services.AddScoped<IRefereeService, RefereeService>();
services.AddScoped<IGameService, GameService>();
services.AddScoped<ILegService, LegService>();
services.AddScoped<IThrowService, ThrowService>();

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
