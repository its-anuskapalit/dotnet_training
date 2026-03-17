namespace AIAnomaly.Domain.Models;

public class Anomaly
{
    public int Id { get; set; }

    public int LogId { get; set; }

    public double Score { get; set; }

    public DateTime DetectedAt { get; set; }

    public Log Log { get; set; }
}