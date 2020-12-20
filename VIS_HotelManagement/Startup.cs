using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer.Bookings;
using ServiceLayer;
using DataLayer.DataMappers;
using DataLayer;
using VIS_HotelManagement.Factories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace VIS_HotelManagement
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
            services.AddControllersWithViews();
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/User/Login";
                });

            services.AddScoped<IDatabase, Database>();
            services.AddScoped<IRoomMapper, RoomMapper>();
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IRoomTypeMapper, RoomTypeMapper>();
            services.AddScoped<IRoomBookingMapper, RoomBookingMapper>();
            services.AddScoped<IInvoiceMapper, InvoiceMapper>();
            services.AddScoped<IRoomKeyMapper, RoomKeyMapper>();
            services.AddScoped<IUserXmlMapper, UserXmlMapper>();

            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IRoomService, RoomService>();
            
            services.AddScoped<IUserService, UserService>();


            services.AddScoped<IRoomFactory, RoomFactory>();
            services.AddScoped<IRoomFactory, RoomFactory>();
            services.AddScoped<IBookingFactory, BookingFactory>();
            services.AddScoped<IUserFactory, UserFactory>();
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

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
