using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartFinance.Application.Interfaces;
using SmartFinance.Infrastructure.Context;
using SmartFinance.Infrastructure.Repositories;// Context klasör adından emin ol (Context mi Contexts mi?)

namespace SmartFinance.Infrastructure
{
    public static class DependencyInjection
    {
        // 'this' anahtar kelimesi burayı bir Extension Method yapar
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //1.Veritabanı bağlantısı için gerekli olan DbContext'i ekliyoruz
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            //2.GenericRepository kaydı
            //bu satır sayesinde  sistem,her tablo için otomatik olarak repository oluşturabilecek
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAiInsightRepository, AiInsightRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            return services;
        }
    }
}