using AIAnomaly.Domain.Models;

namespace AIAnomaly.Application.Interfaces;

public interface ILogService
{
    Task<IEnumerable<Log>> GetLogsAsync();

    Task<Log> GetLogByIdAsync(int id);

    Task AddLogAsync(Log log);
}