using SmartFinance.Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Entities
{
    public class Subscription:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Frequency { get; set; } = string.Empty; //abonelik sıklığı (örneğin: "Aylık", "Yıllık" gibi)
        public DateTime NextPaymentDate { get; set; }

        //--İlişkiler--
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;
    }
}
