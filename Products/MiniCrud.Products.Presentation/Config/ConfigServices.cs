using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Hosting.Internal;
using MiniCrud.Products.Application.DTOs;
using MiniCrud.Products.Application.Queries;
using MiniCrud.Products.Application.Queries.Handlers;
using MiniCrud.Products.Domain.Interfaces;
using MiniCrud.Products.Domain.Interfaces.Repositories;
using MiniCrud.Products.Infrastructure.Data;
using MiniCrud.Products.Infrastructure.Data.Repositories; 

namespace MiniCrud.Products.Presentation.Config
{
    public static class ConfigServices
    {
        public static IServiceCollection Config(this IServiceCollection services, IConfiguration configuration)
        {
            // Database Context
            services.AddDbContext<MiniCrudDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            // Dependency Injection
            services.AddTransient<IUnityOfWork, UnityOfWork>();
            services.AddTransient<IMediator, Mediator>();
            services.AddTransient<IProductRepository, ProductRepository>();
            
            // Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddTransient<IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>, GetProductsQueryHandler>();

            return services;
        }
    }
}