using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Comman
{
    public abstract class BaseEntity
    {
        //her kaydın dünyadaki tekil kimliği
        public Guid Id { get; set; } = Guid.NewGuid();

        //kaydın oluşturulma tarihi(UTCa formatında saklamak daha profesyonel olur)
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
