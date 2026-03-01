using SmartFinance.Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Entities
{
    public class Budget:BaseEntity
    {
        public decimal LimitAmount { get; set; }
        public int Month { get; set; } //1-12 arasında değer alır
        public int Year { get; set; }

        //--İlişkiler--
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
