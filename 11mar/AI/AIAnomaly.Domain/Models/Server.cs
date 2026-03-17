namespace AIAnomaly.Domain.Models;

public class Server
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IPAddress { get; set; }
    public ICollection<Log> Logs { get; set; }
}