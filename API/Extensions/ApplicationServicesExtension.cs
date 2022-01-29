using System.Linq;
using API.Errors;
using API.Helpers;
using Core.Entities;
using Core.interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static  class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration config)
        {    
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IPhotoServices,PhotoServices>();
            services.AddScoped<ITokenService,TokenService>();
             services.AddScoped<IProductRepository, ProductRepository>();
             services.AddScoped<IBasketRepository,BasketRepository>();
             services.AddScoped<IOrderService,OrderService>();
              services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped(typeof (IGenericRepository<>), (typeof (GenericRepository<>)));
            services.AddAutoMapper(typeof (MappingProfiles));
             services.Configure<ApiBehaviorOptions>(option => {
                option.InvalidModelStateResponseFactory = actionContext => {
                    var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                        .Select (x => x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidationErrorResponse {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}