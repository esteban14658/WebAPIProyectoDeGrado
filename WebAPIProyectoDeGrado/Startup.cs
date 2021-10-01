using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PG.Bussiness.Services;
using PG.Bussiness.Services.Implements;
using PG.Models.Repositories;
using PG.Models.Repositories.Implements;
using PG.Presentation.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Filters;
using WebAPIProyectoDeGrado.Repositories;
using WebAPIProyectoDeGrado.Repositories.Implements;
using WebAPIProyectoDeGrado.Services;
using WebAPIProyectoDeGrado.Services.Implements;
using WebAPIProyectoDeGrado.Utilitys;

namespace WebAPIProyectoDeGrado
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

            services.AddControllers(opciones =>
            {
                opciones.Filters.Add(typeof(ExceptionFilter));
            }).AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIProyectoDeGrado", Version = "v1" });
            });

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("defaultConnection")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(op => op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["keyJwt"])),
                    ClockSkew = TimeSpan.Zero
                });

            //services.AddScoped(typeof(AutoMapperProfile));
            
            //services.AddScoped(typeof(IGenericService<>), typeof(GenericService<,>));
            services.AddScoped(typeof(IRecyclerService), typeof(RecyclerService));
            services.AddScoped(typeof(IAddressService), typeof(AddressService));
            services.AddScoped(typeof(ICollectionPointService), typeof(CollectionPointService));
            services.AddScoped(typeof(IResidentService), typeof(ResidentService));
            services.AddScoped(typeof(IShopService), typeof(ShopService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(ICommentService), typeof(CommentService));
            services.AddScoped(typeof(IRouteService), typeof(RouteService));

            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IRecyclerRepository), typeof(RecyclerRepository));
            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));
            services.AddScoped(typeof(ICollectionPointRepository), typeof(CollectionPointRepository));
            services.AddScoped(typeof(IResidentRepository), typeof(ResidentRepository));
            services.AddScoped(typeof(IShopRepository), typeof(ShopRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));
            services.AddScoped(typeof(IRouteRepository), typeof(RouteRepository));

            services.AddCors(opciones =>
            {
                opciones.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:8100").AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIProyectoDeGrado v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            //app.UseMiddleware<handler>();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
