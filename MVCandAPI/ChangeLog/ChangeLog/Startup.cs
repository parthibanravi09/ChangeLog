using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeLog.Data;
using ChangeLog.Helpers;
using ChangeLog.Model.User;
using ChangeLog.Service.Log;
using ChangeLog.Service.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace ChangeLog
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            using (var db = new ChangeLogDbContext())
            {
                db.Database.EnsureCreated();
                db.Database.Migrate();
            }

            
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.IsEssential = true;
            });

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = _configuration["Jwt:Issuer"],
            //        ValidAudience = _configuration["Jwt:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
            //    };
            //});

            //services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlite("Data Source=AppIdentityDb.db"));
            //services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            services.AddAuthentication(o =>
            {
                o.DefaultScheme = "Application";
                o.DefaultSignInScheme = "External";
            })
    .AddCookie("Application")
    .AddCookie("External").AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = _configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = _configuration["Authentication:Google:ClientSecret"];
                
            });

            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlite().AddDbContext<ChangeLogDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChangeLogService, ChangeLogService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
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
}
