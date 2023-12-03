using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ReinosAcoWebApp.Data;
using ReinosAcoWebApp.Services;
using ReinosAcoWebApp.Services.Data;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
                .AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = true,
    PositionClass = ToastPositions.BottomRight
});

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IArmaduraService, ArmaduraService>();
builder.Services.AddDbContext<ArmaduraDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    SupportedCultures = new[] { new CultureInfo("pt-BR") },
});

var context = new ArmaduraDbContext();
context.Database.Migrate();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseNToastNotify();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
