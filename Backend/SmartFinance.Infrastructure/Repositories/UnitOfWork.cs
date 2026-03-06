using SmartFinance.Application.Interfaces;
using SmartFinance.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;

        //veritabanı bağlantımızı içeri alıyoruz
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        //bekleyen tüm işlemleri veritabanına tek seferde işler
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
