using application.Catalog.Categorires;
using application.Catalog.Products;
using application.Common;
using application.System.Languages;
using application.System.Roles;
using application.System.User;
using application.System.Users;
using application.Utilities.Slides;
using FluentValidation.AspNetCore;
using library.Data;
using library.Models.ESHOP;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using view_model.System.Users;

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
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>())
                .AddNewtonsoftJson(
                    options => options.SerializerSettings.Formatting = Formatting.Indented
                );
            
            services.AddDbContext<EShopDbContext>(options => 
                options.UseSqlServer(_configurationRoot.GetConnectionString("EShopConnection"))    
            );
            services.AddDbContext<IdentityEShopDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("IdentityEShopConnection"))
            );
            services.AddTransient<IStorageService, FileStorageService>();

            services.AddTransient<IPublicProductService, PublicProductService>();
            services.AddTransient<IManageProductService, ManageProductService>();
            services.AddTransient<ICategoryService,CategoryService>();
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<ISlideService, SlideService>();
            services.AddTransient<IRoleService, RoleService>();
            //services.AddTransient<IValidator<LoginRequest>,LoginRequestValidator>();
            //services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Swagger eshop solution", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });
           
            
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 5;

            }).AddEntityFrameworkStores<IdentityEShopDbContext>().AddDefaultTokenProviders();

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
            #region appdbcontext
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection"))
            //);
            //services.AddScoped<IUserRepository, UserRepository>();

            //services.AddTransient<IDoiTacRepository, DoiTacRepository>();
            //services.AddTransient<IHopDongRepository, HopDongRepository>();
            //services.AddTransient<ICuaHangRepository, CuaHangRepository>();
            //services.AddTransient<IChiNhanhRepository, ChiNhanhRepository>();
            //services.AddTransient<IGiamDocRepository, GiamDocRepository>();
            //services.AddTransient<IGiamSatRepository, GiamSatRepository>();
            //services.AddTransient<IKhachHangRepository, KhachHangRepository>();
            //services.AddTransient<IKinhDoanhRepository, KinhDoanhRepository>();
            //services.AddTransient<IMatHangRepository, MatHangRepository>();
            //services.AddTransient<IMuaRepository, MuaRepository>();
            //services.AddTransient<INhanVienRepository, NhanVienRepository>();
            //services.AddTransient<ITinhThanhRepository, TinhThanhRepository>();
            //services.AddTransient<INhanVienBaoVeRepository, NhanVienBaoVeRepository>();
            //services.AddTransient<INhanVienQuanLyRepository, NhanVienQuanLyRepository>();
            //services.AddTransient<INhanVienDaiDienRepository, NhanVienDaiDienRepository>();
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
            app.UseSwagger();
            app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json","Swagger eshop solution"));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
