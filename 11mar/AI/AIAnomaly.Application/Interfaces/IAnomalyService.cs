using AIAnomaly.Domain.Models;

namespace AIAnomaly.Application.Interfaces;

public interface IAnomalyService
{
    Task<Anomaly?> DetectAnomalyAsync(Log log);
}