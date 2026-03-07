using SmartFinance.Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Entities
{
    public class AiInsight:BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string InsightType { get; set; } = "Suggestion";
        public bool isRead { get; set; } = false;

        //--İlişkiler--
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;
    }
}
