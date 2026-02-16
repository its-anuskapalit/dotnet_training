using System;
using System.Collections.Generic;
using System.Linq;

public class TimeSeriesPoint
{
    public DateTime Time { get; set; }
    public double Value { get; set; }
}
public class TimeSeriesDatabase
{
    private List<TimeSeriesPoint> data = new List<TimeSeriesPoint>();
    public void AddPoint(TimeSeriesPoint point)
    {
        data.Add(point);
    }
    public double GetAverage(DateTime start, DateTime end)
    {
        var values = data.Where(p => p.Time >= start && p.Time <= end).Select(p => p.Value);
        if (!values.Any())
            return 0;
        return values.Average();
    }
}
class Program
{
    static void Main()
    {
        TimeSeriesDatabase db = new TimeSeriesDatabase();
        db.AddPoint(new TimeSeriesPoint { Time = DateTime.Now.AddMinutes(-10), Value = 20 });
        db.AddPoint(new TimeSeriesPoint { Time = DateTime.Now.AddMinutes(-5), Value = 30 });
        db.AddPoint(new TimeSeriesPoint { Time = DateTime.Now, Value = 40 });
        double avg = db.GetAverage(DateTime.Now.AddMinutes(-15), DateTime.Now);
        Console.WriteLine("Average Value: " + avg);
    }
}
