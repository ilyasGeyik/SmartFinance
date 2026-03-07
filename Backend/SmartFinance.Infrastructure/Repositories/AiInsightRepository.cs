using SmartFinance.Application.Interfaces;
using SmartFinance.Domain.Entities;
using SmartFinance.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Repositories
{
    public class AiInsightRepository : GenericRepository<AiInsight>, IAiInsightRepository
    {
        public AiInsightRepository(AppDbContext context) : base(context)
        {
        }
    }
}
