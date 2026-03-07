using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Shared.Constants
{
    public static class Messages
    {
        // Kategori İşlemleri
        public const string CategoryAdded = "Kategori başarıyla eklendi.";
        public const string CategoryDeleted = "Kategori başarıyla silindi.";
        public const string CategoryUpdated = "Kategori başarıyla güncellendi.";
        public const string CategoryListed = "Kategoriler başarıyla listelendi.";
        public const string CategoryNotFound = "İşlem yapılmak istenen kategori bulunamadı.";

        // Genel Sistem Mesajları
        public const string ValidationError = "Lütfen girdiğiniz bilgileri kontrol edin.";
        public const string SystemError = "Sistemsel bir hata oluştu, lütfen daha sonra tekrar deneyin.";
    }

}
