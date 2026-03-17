using AIAnomaly.Domain.Models;
using AIAnomaly.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AIAnomaly.Infrastructure.Repositories;

public class AnomalyRepository : IAnomalyRepository
{
    private readonly AppDbContext _context;

    public AnomalyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Anomaly>> GetAllAnomaliesAsync()
    {
        return await _context.Anomalies
            .Include(a => a.Log)
            .ToListAsync();
    }

    public async Task AddAnomalyAsync(Anomaly anomaly)
    {
        await _context.Anomalies.AddAsync(anomaly);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}