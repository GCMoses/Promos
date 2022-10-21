using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Promo.Consumables;
using Promo.Data.AppData;
using Promo.Data.AppData.Initializer;
using Promo.Data.Repos.IRepo;
using Promo.Data.Repos.Repo;
using Stripe;

namespace Promos;

public class Program
{
    public Program(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var configuration = builder.Configuration;


        // Add services to the container.
        builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
            ));
        builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppDbContext>();
        builder.Services.AddSingleton<IEmailSender, EmailSender>();
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = $"/Identity/Account/Login";
            options.LogoutPath = $"/Identity/Account/Logout";
            options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
        });

        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(100);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        services.AddAuthentication()
            .AddFacebook(facebookOptions =>
             {
                 facebookOptions.AppId = configuration.GetSection("Facebook:AppId").Get<string>();
                 facebookOptions.AppSecret = configuration.GetSection("Facebook:AppSecret").Get<string>();
             })
            .AddGoogle(googleOptions =>
             {
                 googleOptions.ClientId = configuration.GetSection("Google:ClientId").Get<string>();
                 googleOptions.ClientSecret = configuration.GetSection("Google:ClientSecret").Get<string>();
             });

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
        builder.Services.AddScoped<IDbInitializer, DbInitializer>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

        SeedDatabase();

        app.UseAuthentication();

        app.UseAuthorization();
        app.UseSession();
        app.MapRazorPages();
        app.MapControllerRoute(
            name: "default",
            pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

        app.Run();

        void SeedDatabase()
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                dbInitializer.Initialize();
            }
        }
    }
}