using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartFinance.Infrastructure.Context;// Context klasör adından emin ol (Context mi Contexts mi?)

namespace SmartFinance.Infrastructure
{
    public static class DependencyInjection
    {
        // 'this' anahtar kelimesi burayı bir Extension Method yapar
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}