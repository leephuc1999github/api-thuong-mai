using library;
using library.Data;
using library.Interfaces;
using library.Interfaces.Auth;
using library.Models.ESHOP;
using library.Repositories;
using library.Repositories.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Text;

namespace api
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
        public Startup(IHostEnvironment hostEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath)
               .AddJsonFile("appsettings.json")
               .Build();
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(
                    options => options.SerializerSettings.Formatting = Formatting.Indented
                );
            
            services.AddDbContext<EShopDbContext>(options => 
                options.UseSqlServer(_configurationRoot.GetConnectionString("EShopConnection"))    
            );
            services.AddDbContext<IdentityEShopDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("IdentityEShopConnection"))
            );
            //services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<IdentityEShopDbContext>();
            #region appdbcontext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection"))
            );
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 5;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(auth => 
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => 
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = _configurationRoot["AuthSettings:Audience"],
                    ValidIssuer = _configurationRoot["AuthSettings:Issuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurationRoot["AuthSettings:Key"])),
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddTransient<IDoiTacRepository, DoiTacRepository>();
            services.AddTransient<IHopDongRepository, HopDongRepository>();
            services.AddTransient<ICuaHangRepository, CuaHangRepository>();
            services.AddTransient<IChiNhanhRepository, ChiNhanhRepository>();
            services.AddTransient<IGiamDocRepository, GiamDocRepository>();
            services.AddTransient<IGiamSatRepository, GiamSatRepository>();
            services.AddTransient<IKhachHangRepository, KhachHangRepository>();
            services.AddTransient<IKinhDoanhRepository, KinhDoanhRepository>();
            services.AddTransient<IMatHangRepository, MatHangRepository>();
            services.AddTransient<IMuaRepository, MuaRepository>();
            services.AddTransient<INhanVienRepository, NhanVienRepository>();
            services.AddTransient<ITinhThanhRepository, TinhThanhRepository>();
            services.AddTransient<INhanVienBaoVeRepository, NhanVienBaoVeRepository>();
            services.AddTransient<INhanVienQuanLyRepository, NhanVienQuanLyRepository>();
            services.AddTransient<INhanVienDaiDienRepository, NhanVienDaiDienRepository>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
