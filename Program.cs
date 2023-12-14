using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ReinosAcoWebApp.Data;
using ReinosAcoWebApp.Services;
using ReinosAcoWebApp.Services.Data;
using System.Globalization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options => {
                                    options.Conventions.AuthorizeFolder("/Autenticidades");
                                    options.Conventions.AuthorizeFolder("/Materiais");
                                    })
                                    .AddNToastNotifyToastr(new ToastrOptions()
                                    {
                                        ProgressBar = true,
                                        PositionClass = ToastPositions.BottomRight
                                    });

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IArmaduraService, ArmaduraService>();
builder.Services.AddDbContext<ArmaduraDbContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ArmaduraDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;

    options.Lockout.MaxFailedAccessAttempts = 30;
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;
});

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

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
