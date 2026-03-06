using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.DTOs.CategoryDtos
{
    public class CategoryDto
    {
        // Müşteriye (Ön yüze) Kategori ile ilgili sadece neleri göstermek istiyorsak onları yazıyoruz.
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Icon { get; set; }
    }
}
