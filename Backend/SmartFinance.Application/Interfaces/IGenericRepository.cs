using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Interfaces
{
    //'T' Burada herhangi bir tablo yerine geçer(user,category...)
    public interface IGenericRepository<T> where T : class
    {
        //tüm verileri getirmek için(listeleme)
        Task<List<T>> GetAllAsync();

        //id'ye göre tek veri getirmek için(Detay Görme)
        Task<T?> GetByIdAsync(Guid id);

        //Filtrleme yap (örn: Sadece bugün yapılan harcamaları getir)
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        //yeni veri ekleme
        Task AddAsync(T entity);

        //var olan veriyi güncelleme
        void Update(T entity);

        //var olan veriyi silme
        void Delete(T entity);
    }
}
