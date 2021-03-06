using CorePoint.DAL.Data;
using CorePoint.Service.Interfaces;
using CorePoint.Service.Repostity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CorePoint
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
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConString")));
            services.Configure<PasswordHasherOptions>(options => options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2);
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();//options => options.SignIn.RequireConfirmedAccount = false
            services.AddScoped<ICountryServices, CountryServices>();
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<IStateServices, StateServices>();
            services.AddScoped<ICityServices, CityServices>();
            services.AddScoped<ICrewsServices, CrewsServices>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IAddressServices, AddressServices>();
            services.AddScoped<IIncidentServices, IncidentServices>();
            services.AddControllersWithViews();

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
                options.Lockout.AllowedForNewUsers = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "CorePoint";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/Login?id=1";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "DefaultAreas",
                  pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}