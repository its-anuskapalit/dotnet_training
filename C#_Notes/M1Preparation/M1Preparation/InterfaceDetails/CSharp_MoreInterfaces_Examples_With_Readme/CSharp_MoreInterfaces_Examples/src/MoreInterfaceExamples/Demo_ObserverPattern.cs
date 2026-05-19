using System;
using System.Collections.Generic;

namespace MoreInterfaceExamples;

public static class Demo_ObserverPattern
{
    public static void Run()
    {
        Console.WriteLine("---- 10) IObservable<T> + IObserver<T> Demo ----");

        var publisher = new TemperaturePublisher();
        var observer = new TemperatureObserver("Observer-1");

        using var subscription = publisher.Subscribe(observer);

        publisher.Publish(32);
        publisher.Publish(35);
        publisher.Complete();

        Console.WriteLine();
    }

    private sealed class TemperaturePublisher : IObservable<int>
    {
        private readonly List<IObserver<int>> _observers = new();
        private bool _completed;

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (_completed)
            {
                observer.OnCompleted();
                return new Unsubscriber(_observers, observer);
            }

            _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        public void Publish(int value)
        {
            foreach (var o in _observers) o.OnNext(value);
        }

        public void Complete()
        {
            _completed = true;
            foreach (var o in _observers) o.OnCompleted();
            _observers.Clear();
        }

        private sealed class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<int>> _obs;
            private readonly IObserver<int> _observer;

            public Unsubscriber(List<IObserver<int>> obs, IObserver<int> observer)
            {
                _obs = obs;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_obs.Contains(_observer))
                    _obs.Remove(_observer);
            }
        }
    }

    private sealed class TemperatureObserver : IObserver<int>
    {
        private readonly string _name;
        public TemperatureObserver(string name) => _name = name;

        public void OnCompleted() => Console.WriteLine($"{_name}: Completed");
        public void OnError(Exception error) => Console.WriteLine($"{_name}: Error: {error.Message}");
        public void OnNext(int value) => Console.WriteLine($"{_name}: Temperature={value}");
    }
}
