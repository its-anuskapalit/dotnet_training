using System;
using System.Collections.Generic;
using System.Linq;

public enum InstrumentType { Stock, Bond, Option, Future }
public enum Trend { Upward, Downward, Sideways }

public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; set; }
    InstrumentType Type { get; }
}

public class Portfolio<T> where T : IFinancialInstrument
{
    private readonly Dictionary<T, int> _holdings = new();

    public void Buy(T instrument, int quantity, decimal price)
    {
        if (instrument == null || quantity <= 0 || price <= 0)
            throw new ArgumentException();

        if (_holdings.ContainsKey(instrument))
            _holdings[instrument] += quantity;
        else
            _holdings[instrument] = quantity;

        instrument.CurrentPrice = price;
    }

    public decimal? Sell(T instrument, int quantity, decimal currentPrice)
    {
        if (!_holdings.ContainsKey(instrument) || quantity <= 0)
            return null;

        if (_holdings[instrument] < quantity)
            return null;

        _holdings[instrument] -= quantity;

        if (_holdings[instrument] == 0)
            _holdings.Remove(instrument);

        return quantity * currentPrice;
    }

    public decimal CalculateTotalValue()
    {
        return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
    }

    public (T instrument, decimal returnPercentage)? GetTopPerformer(
        Dictionary<T, decimal> purchasePrices)
    {
        if (!purchasePrices.Any())
            return null;

        var best = _holdings
            .Where(h => purchasePrices.ContainsKey(h.Key))
            .Select(h =>
            {
                var buyPrice = purchasePrices[h.Key];
                var ret = ((h.Key.CurrentPrice - buyPrice) / buyPrice) * 100;
                return (h.Key, ret);
            })
            .OrderByDescending(r => r.ret)
            .FirstOrDefault();

        return best.Key == null ? null : best;
    }

    public IEnumerable<T> Instruments => _holdings.Keys;
}

public class Stock : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Stock;
    public string CompanyName { get; set; }
    public decimal DividendYield { get; set; }
}

public class Bond : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Bond;
    public DateTime MaturityDate { get; set; }
    public decimal CouponRate { get; set; }
}

public class TradingStrategy<T> where T : IFinancialInstrument
{
    public void Execute(
        Portfolio<T> portfolio,
        IEnumerable<T> marketData,
        Func<T, bool> buyCondition,
        Func<T, bool> sellCondition)
    {
        foreach (var instrument in marketData)
        {
            if (buyCondition(instrument))
                portfolio.Buy(instrument, 1, instrument.CurrentPrice);

            if (sellCondition(instrument))
                portfolio.Sell(instrument, 1, instrument.CurrentPrice);
        }
    }

    public Dictionary<string, decimal> CalculateRiskMetrics(IEnumerable<T> instruments)
    {
        var prices = instruments.Select(i => i.CurrentPrice).ToList();

        if (prices.Count < 2)
            return new Dictionary<string, decimal>();

        var avg = prices.Average();
        var variance = prices.Sum(p => (p - avg) * (p - avg)) / prices.Count;
        var volatility = (decimal)Math.Sqrt((double)variance);

        return new Dictionary<string, decimal>
        {
            { "Volatility", volatility },
            { "Beta", volatility / avg },
            { "SharpeRatio", avg / volatility }
        };
    }
}

public class PriceHistory<T> where T : IFinancialInstrument
{
    private readonly Dictionary<T, List<(DateTime, decimal)>> _history = new();

    public void AddPrice(T instrument, DateTime timestamp, decimal price)
    {
        if (!_history.ContainsKey(instrument))
            _history[instrument] = new List<(DateTime, decimal)>();

        _history[instrument].Add((timestamp, price));
        instrument.CurrentPrice = price;
    }

    public decimal? GetMovingAverage(T instrument, int days)
    {
        if (!_history.ContainsKey(instrument))
            return null;

        var prices = _history[instrument]
            .OrderByDescending(h => h.Item1)
            .Take(days)
            .Select(h => h.Item2)
            .ToList();

        return prices.Any() ? prices.Average() : null;
    }

    public Trend DetectTrend(T instrument, int period)
    {
        if (!_history.ContainsKey(instrument))
            return Trend.Sideways;

        var prices = _history[instrument]
            .OrderByDescending(h => h.Item1)
            .Take(period)
            .Select(h => h.Item2)
            .ToList();

        if (prices.Count < 2)
            return Trend.Sideways;

        return prices.First() > prices.Last()
            ? Trend.Upward
            : prices.First() < prices.Last()
                ? Trend.Downward
                : Trend.Sideways;
    }
}

public class Program
{
    public static void Main()
    {
        var apple = new Stock { Symbol = "AAPL", CompanyName = "Apple", CurrentPrice = 150 };
        var tesla = new Stock { Symbol = "TSLA", CompanyName = "Tesla", CurrentPrice = 700 };

        var portfolio = new Portfolio<Stock>();
        var history = new PriceHistory<Stock>();

        history.AddPrice(apple, DateTime.Now.AddDays(-2), 145);
        history.AddPrice(apple, DateTime.Now.AddDays(-1), 150);
        history.AddPrice(apple, DateTime.Now, 155);

        history.AddPrice(tesla, DateTime.Now.AddDays(-2), 720);
        history.AddPrice(tesla, DateTime.Now.AddDays(-1), 710);
        history.AddPrice(tesla, DateTime.Now, 700);

        var strategy = new TradingStrategy<Stock>();

        strategy.Execute(
            portfolio,
            new[] { apple, tesla },
            s => history.DetectTrend(s, 2) == Trend.Upward,
            s => history.DetectTrend(s, 2) == Trend.Downward
        );

        Console.WriteLine(portfolio.CalculateTotalValue());
        Console.WriteLine(history.GetMovingAverage(apple, 2));
        Console.WriteLine(history.DetectTrend(tesla, 3));

        var purchasePrices = new Dictionary<Stock, decimal>
        {
            { apple, 145 },
            { tesla, 720 }
        };

        var top = portfolio.GetTopPerformer(purchasePrices);
        Console.WriteLine($"{top?.instrument.Symbol} {top?.returnPercentage}");
    }
}
