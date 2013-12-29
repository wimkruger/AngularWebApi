using System.Linq;

namespace DataAccess.Specifications
{
    public interface ISpecification<T>
    {
        IQueryable<T> IsSatisfiedBy(IQueryable<T> queryable);
    }
}
