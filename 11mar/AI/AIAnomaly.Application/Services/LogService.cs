using AIAnomaly.Application.Interfaces;
using AIAnomaly.Domain.Models;
using AIAnomaly.Infrastructure.Repositories;

namespace AIAnomaly.Application.Services;

public class LogService : ILogService
{
    private readonly ILogRepository _logRepository;
    private readonly IAnomalyRepository _anomalyRepository;
    private readonly IAnomalyService _anomalyService;

    public LogService(
        ILogRepository logRepository,
        IAnomalyRepository anomalyRepository,
        IAnomalyService anomalyService)
    {
        _logRepository = logRepository;
        _anomalyRepository = anomalyRepository;
        _anomalyService = anomalyService;
    }

    public async Task<IEnumerable<Log>> GetLogsAsync()
    {
        return await _logRepository.GetAllLogsAsync();
    }

    public async Task<Log> GetLogByIdAsync(int id)
    {
        return await _logRepository.GetLogByIdAsync(id);
    }

    public async Task AddLogAsync(Log log)
    {
        await _logRepository.AddLogAsync(log);
        await _logRepository.SaveChangesAsync();

        var anomaly = await _anomalyService.DetectAnomalyAsync(log);

        if (anomaly != null)
        {
            await _anomalyRepository.AddAnomalyAsync(anomaly);
            await _anomalyRepository.SaveChangesAsync();
        }
    }
}