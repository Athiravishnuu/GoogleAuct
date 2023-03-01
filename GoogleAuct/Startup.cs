using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoogleAuct;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        
             services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = "<881642255142-iqv0cvfmbh2vvvqag62cru0k68pgcgpb.apps.googleusercontent.com>";
                options.ClientSecret = "<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>";
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}












    //public IConfiguration Configuration { get; }

    //public Startup(IConfiguration configuration)
    //{
    //    Configuration = configuration;
    //}

    //public void ConfigureServices(IServiceCollection services)
    //{
    //    services.AddAuthentication(options =>
    //    {
    //        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    //        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    //    })
    //    .AddCookie()
    //    .AddGoogle(options =>
    //    {
    //        options.ClientId = Configuration["Google:881642255142-iqv0cvfmbh2vvvqag62cru0k68pgcgpb.apps.googleusercontent.com"];
    //        options.ClientSecret = Configuration["Google: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"];
    //    });

    //    services.AddMvc();
    //}

    //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    //{
    //    if (env.IsDevelopment())
    //    {
    //        app.UseDeveloperExceptionPage();
    //    }
    //    else
    //    {
    //        app.UseExceptionHandler("/Home/Error");
    //    }

    //    app.UseStaticFiles();

    //    app.UseAuthentication();

    //    app.UseMvc(routes =>
    //    {
    //        routes.MapRoute(
    //            name: "default",
    //            template: "{controller=Home}/{action=Index}/{id?}");
    //    });
    //}


