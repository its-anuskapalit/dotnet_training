// Summary: Tracks wait-time statistics for a check-in simulation.
// Records individual wait samples (capped to 10,000), maintains running total and count,
// and provides the average wait time and the 95th percentile from the recorded samples.

namespace CheckInSimulation.Metrics;

public class StatisticsTracker
{
    // Running total of all recorded wait times.
    private long _totalWait = 0;

    // Number of recorded wait entries.
    private long _count = 0;

    // Stored samples for percentile calculations (limited to first 10,000 samples to bound memory).
    private List<long> _samples = new();

    // Record a new wait sample.
    public void Record(long wait)
    {
        _totalWait += wait; // update running total
        _count++; // increment count

        // Add to sample buffer if under the cap to keep memory bounded.
        if (_samples.Count < 10000)
            _samples.Add(wait);
    }

    // Average wait across all recorded samples.
    // Note: current implementation will throw DivideByZeroException if _count == 0.
    public double AverageWait => (double)_totalWait / _count;

    // Compute the 95th percentile from the collected samples.
    public long Percentile95()
    {
        // If no samples recorded, return 0 as a sensible default.
        if (_samples.Count == 0)
            return 0;

        // Sort samples in-place to prepare for percentile selection.
        _samples.Sort();

        // Compute index for 95th percentile (floor of 0.95 * count).
        int index = (int)(0.95 * _samples.Count);

        // Clamp index to valid range in case multiplication yields equal to Count.
        if (index >= _samples.Count)
            index = _samples.Count - 1;

        return _samples[index];
    }
}
