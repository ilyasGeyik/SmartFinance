using Microsoft.EntityFrameworkCore;
using SmartFinance.Application.Interfaces;
using SmartFinance.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();//hangi tablo (T) gelirse onu hedef alıyoruz
        }
        public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
        public IQueryable<T> Where(Expression<Func<T, bool>> expression) => _dbSet.Where(expression);
        public async Task AddAsync(T entity)=> await _dbSet.AddAsync(entity);
        public void Delete(T entity)=> _dbSet.Remove(entity);
        public void Update(T entity) => _dbSet.Update(entity);
       
    }
}
