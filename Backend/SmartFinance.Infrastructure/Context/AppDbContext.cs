using Microsoft.EntityFrameworkCore;
using SmartFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Context
{
    public class AppDbContext:DbContext
    {
        //Program.cs(API katmanı) üzerinden veritabanı bağlantılı yolumuz(Connection String) almamızı sağlar
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //DbSet'ler burada tanımlanacak (örneğin: public DbSet<AppUser> AppUsers { get; set; } gibi)
        //tablolarımız

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }    
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<AiInsight> AiInsights { get; set; }
    }
}
