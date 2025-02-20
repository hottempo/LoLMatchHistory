using LoLMatchHistory.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LoLMatchHistory.Infrastructure.Repositories
{
    public class ApiRequestLogRepository(LoLMatchHistoryContext context)
    {
        private readonly LoLMatchHistoryContext _context = context;

        public async Task LogRequestAsync(ApiRequestLog log)
        {
            await _context.ApiRequestLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}
