
using API_.NET.Application.Interfaces;
using API_.NET.Application.Services;
using API_.NET.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace API_.NET.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<AuthService>();
            services.AddScoped<UserService>();
            services.AddScoped<ProductService>();
            services.AddScoped<TokenService>();

            return services;
        }

        //public static IServiceCollection AddServiceAutomatically(this IServiceCollection services)
        //{
        //    var assembly = typeof(AuthService).Assembly;

        //    var types = assembly.GetTypes()
        //        .Where(t => t.IsClass && !t.IsAbstract);

        //    foreach (var type in types )
        //    {
        //        if (type.Name.EndsWith("Service"))
        //        {
        //            services.AddScoped(type);
        //        }
        //    }
        //    return services;
        //}
    }
}
