using System.Collections.Generic;
namespace UniExamPro.Interfaces
{
    // Generic repository interface
    public interface IRepository<T>
    {
        // Adds a new entity
        void Add(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
