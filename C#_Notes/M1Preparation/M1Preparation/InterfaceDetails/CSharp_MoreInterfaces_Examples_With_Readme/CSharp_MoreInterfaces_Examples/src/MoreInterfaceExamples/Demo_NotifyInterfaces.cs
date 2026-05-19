using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MoreInterfaceExamples;

public static class Demo_NotifyInterfaces
{
    public static void Run()
    {
        Console.WriteLine("---- 9) INotifyPropertyChanged + INotifyCollectionChanged Demo ----");

        var emp = new Employee { Name = "Arjun", Salary = 50000 };
        emp.PropertyChanged += (_, e) => Console.WriteLine($"Property changed: {e.PropertyName}");
        emp.Salary = 55000;

        var list = new ObservableCollection<string>();
        list.CollectionChanged += OnCollectionChanged;
        list.Add("A");
        list.Add("B");
        list.Remove("A");

        Console.WriteLine();
    }

    private static void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        Console.WriteLine($"Collection changed: Action={e.Action}");
    }

    private sealed class Employee : INotifyPropertyChanged
    {
        private string _name = "";
        private int _salary;

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public int Salary
        {
            get => _salary;
            set
            {
                if (_salary == value) return;
                _salary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Salary)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
