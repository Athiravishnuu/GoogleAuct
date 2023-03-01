using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoogleAuct
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
                   .AddCookie(options =>
                   {
                     options.LoginPath = "/account/signin";
                    })
                    .AddGoogle(options =>
                    {
                    options.ClientId = "881642255142-iqv0cvfmbh2vvvqag62cru0k68pgcgpb.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                     });



            //Services.AddAuthentication()

            //    .AddGoogle(googleOptions =>
            //    {
            //        googleOptions.ClientId = "881642255142-iqv0cvfmbh2vvvqag62cru0k68pgcgpb.apps.googleusercontent.com";
            //        googleOptions.ClientSecret = "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";
            //    });

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}