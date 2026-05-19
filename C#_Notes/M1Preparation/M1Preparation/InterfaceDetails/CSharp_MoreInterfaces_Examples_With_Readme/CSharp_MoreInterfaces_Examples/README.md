# C# Console App — Common .NET Interfaces (Pack 2)

This project contains short, beginner-friendly demos for these interfaces:

**Formatting / Conversion**
- `IFormattable`
- `IConvertible`
- `ICloneable` (legacy)

**Iteration / Collections**
- `IEnumerable`, `IEnumerator`
- `IEnumerable<T>`, `IEnumerator<T>`
- `ICollection`, `IList`, `IDictionary`, `IDictionaryEnumerator`
- `ICollection<T>`, `IReadOnlyCollection<T>`, `IList<T>`, `IReadOnlyList<T>`
- `IDictionary<TKey,TValue>`, `IReadOnlyDictionary<TKey,TValue>`
- `ISet<T>`, `IReadOnlySet<T>`

**Sorting / Equality**
- `IComparer<T>`, `IEqualityComparer<T>`

**Concurrency / Async**
- `IProducerConsumerCollection<T>`
- `IAsyncEnumerable<T>`, `IAsyncEnumerator<T>`
- `IProgress<T>`
- `IAsyncResult` (legacy)

**Notifications / Observer**
- `INotifyPropertyChanged`, `INotifyCollectionChanged`
- `IObservable<T>`, `IObserver<T>`

**Generic Parsing**
- `IParsable<TSelf>`, `ISpanParsable<TSelf>`

**DI + Hosting + Logging (for Console apps too)**
- `IServiceCollection`, `IServiceProvider`
- `IHost`, `IHostBuilder`
- `ILogger`, `ILogger<T>`, `ILoggerFactory`

---

## ✅ How to Run

```bash
cd src/MoreInterfaceExamples
dotnet restore
dotnet run
```

---

## Quick exam hints

- Prefer **generic interfaces** (`IEnumerable<T>`, `IList<T>`, `IDictionary<TKey,TValue>`) over non-generic.
- Prefer **IComparable<T> / IComparer<T>** for sorting rules.
- For HashSet/Dictionary keys, think **IEquatable<T> / IEqualityComparer<T>**.
- For async streams, use **IAsyncEnumerable<T>** with `await foreach`.
- For DI in Console, use `Host.CreateDefaultBuilder()` and `services.Add...()`.
