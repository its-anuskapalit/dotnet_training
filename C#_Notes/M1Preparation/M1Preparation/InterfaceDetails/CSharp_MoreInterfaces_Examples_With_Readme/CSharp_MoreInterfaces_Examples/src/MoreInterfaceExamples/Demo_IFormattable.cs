using System;
using System.Globalization;

namespace MoreInterfaceExamples;

public static class Demo_IFormattable
{
    public static void Run()
    {
        Console.WriteLine("---- 1) IFormattable Demo ----");

        var money = new Money(12500.5m);

        Console.WriteLine(money.ToString("INR", CultureInfo.GetCultureInfo("en-IN")));
        Console.WriteLine(money.ToString("USD", CultureInfo.GetCultureInfo("en-US")));
        Console.WriteLine(money.ToString("RAW", CultureInfo.InvariantCulture));

        Console.WriteLine();
    }

    private readonly struct Money : IFormattable
    {
        public decimal Amount { get; }
        public Money(decimal amount) => Amount = amount;

        public override string ToString() => ToString("RAW", CultureInfo.InvariantCulture);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            format = (format ?? "RAW").ToUpperInvariant();

            return format switch
            {
                "INR" => string.Format(formatProvider, "₹{0:N2}", Amount),
                "USD" => string.Format(formatProvider, "${0:N2}", Amount),
                "RAW" => Amount.ToString(formatProvider),
                _ => Amount.ToString(formatProvider)
            };
        }
    }
}
