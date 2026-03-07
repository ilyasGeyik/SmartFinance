using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Interfaces
{
    public interface IUnitOfWork
    {
        //Sepette bekleyen tüm işlemleri (ekle,güncelle,sil) veritabanına tek seferde kaydetme emri
        //int döndürmemizin sebebi EF ün işlem sonucunda veritabanında kaç satırın etkilendiğini bize sayı olarak bildirmesidir.
        Task<int> SaveChangesAsync();
    }
}
