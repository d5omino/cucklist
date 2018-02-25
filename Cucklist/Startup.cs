using System;

using Cucklist.Data;
using Cucklist.Models;
using Cucklist.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WebPWrecover.Services;

namespace Cucklist
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

        string Stage = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        string ProdDb=Environment.GetEnvironmentVariable("ProdDb");
        string DevDb=Configuration["DevDb"];



        if ( Stage == "Development" )
        {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(DevDb));
        }
        else
        {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(ProdDb));
        }


        services.AddIdentity<ApplicationUser,IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

        // Add application services.
        services.AddTransient<IEmailSender,EmailSender>();
        services.Configure<AuthMessageSenderOptions>(Configuration);

        services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,IHostingEnvironment env)
        {
        if ( env.IsDevelopment() )
        {
        app.UseBrowserLink();
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();

        }
        else
        {
        app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();

        app.UseAuthentication();

        app.UseMvc(routes =>
        {
        routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });
        }
    }
}
