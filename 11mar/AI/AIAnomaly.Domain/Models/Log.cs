namespace AIAnomaly.Domain.Models;

public class Log
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; }

    public string Level { get; set; }

    public string Message { get; set; }

    public int ServerId { get; set; }

    public Server? Server { get; set; }

    public ICollection<Anomaly>? Anomalies { get; set; }
}