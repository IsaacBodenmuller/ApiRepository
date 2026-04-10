
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
            services.AddScoped<ICashRegisterRepository, CashRegisterRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();

            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            services.AddScoped<IStateRepository, StateRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<AuthService>();

            services.AddScoped<CashRegisterService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<CityService>();
            //services.AddScoped<CustomerService>();

            services.AddScoped<ProductService>();
            services.AddScoped<ProfileService>();

            services.AddScoped<StateService>();

            services.AddScoped<TokenService>();

            services.AddScoped<UserService>();

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
