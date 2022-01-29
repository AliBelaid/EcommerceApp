using API.Errors;
using API.Extensions;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using Infrastructure.Identity;

namespace API {
    public class Startup {
        private readonly IConfiguration _conf;

        public Startup (IConfiguration configuration) {
            _conf = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddControllers();
            services.AddDbContext<StoreContext>(x => x.UseSqlite(_conf.GetConnectionString("DefaultConnection")));
             services.AddDbContext<AppIdentityDbContext>(x=>x.UseSqlite(_conf.GetConnectionString("IdentityConnection")));
              services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration = 
                ConfigurationOptions.Parse(_conf.GetConnectionString("Redis"),true);
                return ConnectionMultiplexer.Connect(configuration);
            }
                );
    //   services.AddControllersWithViews()
	// 	.AddNewtonsoftJson(options =>
	// 	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
	// );
    //   services.AddControllers().AddJsonOptions(option => { option.JsonSerializerOptions.PropertyNamingPolicy = null; option.JsonSerializerOptions.MaxDepth = 256; });
            services.AddApplicationServices(_conf);
            services.AddIdentityServices(_conf);
  
            services.AddSwaggerDocumentation();
            services.AddCors(
                opt => {
                    opt.AddPolicy("CorsPolicy",policy=> {
                        policy.AllowAnyHeader().AllowCredentials().AllowAnyMethod().WithOrigins("https://localhost:4200");
                        
                    });
                }
            );
//             services.AddControllers().AddNewtonsoftJson(x => 
//  x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseSwaggerDocumentation ();

            if (env.IsDevelopment ()) {

                app.UseMiddleware<ExceptionMiddleware> ();

            }
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}

