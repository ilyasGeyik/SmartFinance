using SmartFinance.Domain.Comman;
using SmartFinance.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Entities
{
    public class Transaction:BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string? Description { get; set; }

        public TransactionType Type { get; set; }

        //--AI analizleri alanları--
        public bool IsEssential { get; set; } // Temel ihtiyaç mı?
        public string? AiCategorySuggestion { get; set; } // AI:hangi kategoriye uygun

    }
}
