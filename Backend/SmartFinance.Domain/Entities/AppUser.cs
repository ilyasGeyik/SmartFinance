using SmartFinance.Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Entities
{
    public class AppUser:BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        //kullanıcının bağlantılı olduğu işlemler (1-N ilişkisi)
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public ICollection<AiInsight> AiInsights { get; set; } = new List<AiInsight>();
    }
}
