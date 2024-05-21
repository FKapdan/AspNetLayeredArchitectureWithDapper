using Business.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Web.Filters;

namespace Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddAutoMapper(typeof(Program));
        // Add services to the container.
        builder.Services.AddControllersWithViews();//.AddRazorRuntimeCompilation();
        //Add application services.

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
        {
            options.Cookie = new CookieBuilder()
            {
                Name = builder.Configuration["CookieKeys:CookineName"],
                HttpOnly = true,
                MaxAge = TimeSpan.FromMinutes(30),
                SameSite = SameSiteMode.Lax
            };
            options.LoginPath = builder.Configuration["CookieKeys:LoginPath"];
            options.LogoutPath = builder.Configuration["CookieKeys:LogoutPath"];
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            options.SlidingExpiration = true;
            options.AccessDeniedPath = builder.Configuration["CookieKeys:LoginPath"];
        });
        //builder.Services.AddAuthorization();
        builder.Services.AddControllersWithViews(options =>
        {
            //options.Filters.Add(typeof(GeneralExceptionFilter));//api global exception yakalar.
            options.Filters.Add(typeof(GeneralModelValidationAttribute));//api metod validationlarýný yapar.
        });

        builder.Services.AddBusinessServices(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseCookiePolicy();
        app.UseAuthentication();// who are you?  
        app.UseAuthorization();// are you allowed?  
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Login}/{action=Index}/{id?}");

        app.Run();
    }
}
