using Domain;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Repositories
{
    public interface IRepository<T> : IEnumerable<T> where T : Entity
    {
        void Add(T item);
        bool Contains(T item);
        int Count { get; }
        bool Remove(T item);
        T FindById(int id);
        //IQueryable<T> Find(ISpecification<T> specification);
    }
}
