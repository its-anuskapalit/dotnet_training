using AIAnomaly.Domain.Models;
using AIAnomaly.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AIAnomaly.Infrastructure.Repositories;

public class LogRepository : ILogRepository
{
    private readonly AppDbContext _context;

    public LogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Log>> GetAllLogsAsync()
    {
        return await _context.Logs
            .Include(l => l.Server)
            .ToListAsync();
    }

    public async Task<Log> GetLogByIdAsync(int id)
    {
        return await _context.Logs
            .Include(l => l.Server)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task AddLogAsync(Log log)
    {
        await _context.Logs.AddAsync(log);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}