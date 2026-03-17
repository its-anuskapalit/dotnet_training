using AIAnomaly.Application.Interfaces;
using AIAnomaly.Domain.Models;

namespace AIAnomaly.Application.Services;

public class AnomalyService : IAnomalyService
{
    public async Task<Anomaly?> DetectAnomalyAsync(Log log)
    {
        double score = CalculateAnomalyScore(log);

        if (score > 0.8)
        {
            return new Anomaly
            {
                LogId = log.Id,
                Score = score,
                DetectedAt = DateTime.UtcNow
            };
        }

        return null;
    }

    private double CalculateAnomalyScore(Log log)
    {
        double score = 0.0;

        if (log.Level == "ERROR")
            score += 0.5;

        if (log.Message.ToLower().Contains("failed"))
            score += 0.3;

        if (log.Message.ToLower().Contains("timeout"))
            score += 0.2;

        return score;
    }
}