using AIAnomaly.Domain.Models;

namespace AIAnomaly.Infrastructure.Repositories;

public interface IAnomalyRepository
{
    Task<IEnumerable<Anomaly>> GetAllAnomaliesAsync();

    Task AddAnomalyAsync(Anomaly anomaly);

    Task SaveChangesAsync();
}