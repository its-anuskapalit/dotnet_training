using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterpriseGenericEngine
{
    class Program
    {
        static void Main()
        {
            var repo = new GenericRepository<Student>();
            var processor = new GenericProcessor<Student>(repo, new StudentValidator());

            processor.OnEntityAdded += (s) => Console.WriteLine($"Event: {s.Name} added.");

            var student = new Student { Id = 1, Name = "Anuska", Marks = 95 };

            processor.Add(student);

            processor.DisplayAll();

            Console.WriteLine("Sorted by Marks:");
            processor.SortBy(x => x.Marks);

            Console.WriteLine("Filtered:");
            var topStudents = processor.Filter(x => x.Marks > 90);
            foreach (var s in topStudents)
                Console.WriteLine(s.Name);
        }
    }

    // ---------------- BASE ENTITY ----------------
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }

    // ---------------- ENTITY ----------------
    public class Student : BaseEntity, IComparable<Student>
    {
        public string Name { get; set; }
        public int Marks { get; set; }

        public int CompareTo(Student other)
        {
            return Marks.CompareTo(other.Marks);
        }
    }

    // ---------------- GENERIC INTERFACE ----------------
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
    }

    // ---------------- GENERIC REPOSITORY ----------------
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly List<T> _data = new();
        public void Add(T entity)
        {
            _data.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _data;
        }
    }

    // ---------------- GENERIC VALIDATOR ----------------
    public interface IEntityValidator<T>
    {
        bool Validate(T entity);
    }

    public class StudentValidator : IEntityValidator<Student>
    {
        public bool Validate(Student entity)
        {
            return entity.Marks >= 0;
        }
    }

    // ---------------- GENERIC PROCESSOR ----------------
    public class GenericProcessor<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private readonly IEntityValidator<T> _validator;
        public delegate void EntityAddedHandler(T entity);
        public event EntityAddedHandler OnEntityAdded;
        public GenericProcessor(IRepository<T> repo, IEntityValidator<T> validator)
        {
            _repository = repo;
            _validator = validator;
        }

        public void Add(T entity)
        {
            if (_validator.Validate(entity))
            {
                _repository.Add(entity);
                OnEntityAdded?.Invoke(entity);
            }
        }
        public void DisplayAll()
        {
            foreach (var item in _repository.GetAll())
                Console.WriteLine(item.Id);
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return _repository.GetAll().Where(predicate);
        }

        public void SortBy<TKey>(Func<T, TKey> keySelector)
        {
            var sorted = _repository.GetAll().OrderBy(keySelector);
            foreach (var item in sorted)
                Console.WriteLine(item.Id);
        }
    }
    // ---------------- GENERIC FACTORY ----------------
    public static class EntityFactory<T> where T : new()
    {
        public static T Create()
        {
            return new T();
        }
    }
    // ---------------- GENERIC EXTENSION METHOD ----------------
    public static class GenericExtensions
    {
        public static void PrintAll<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Console.WriteLine(item);
        }
    }
    // ---------------- COVARIANCE ----------------
    public interface IReadOnlyRepository<out T>
    {
        T Get();
    }

    // ---------------- CONTRAVARIANCE ----------------
    public interface IProcessor<in T>
    {
        void Process(T item);
    }
}
