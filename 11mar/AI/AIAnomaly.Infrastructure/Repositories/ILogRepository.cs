using AIAnomaly.Domain.Models;

namespace AIAnomaly.Infrastructure.Repositories;

public interface ILogRepository
{
    Task<IEnumerable<Log>> GetAllLogsAsync();

    Task<Log> GetLogByIdAsync(int id);

    Task AddLogAsync(Log log);

    Task SaveChangesAsync();
}