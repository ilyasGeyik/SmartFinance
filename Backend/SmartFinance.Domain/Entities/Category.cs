using SmartFinance.Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Icon { get; set; } //kategoriye ait ikon bilgisi (örneğin: "fa-solid fa-utensils" gibi)

        //kategorinin bağlantılı olduğu işlemler (1-N ilişkisi)
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}
