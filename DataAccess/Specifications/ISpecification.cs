using System.Linq;
using AdventureWorks.DataAccess.SearchCriterias;
using NHibernate;
namespace AdventureWorks.DataAccess.Specifications
{
    public interface ISpecification<T>
    {
        IQueryable<T> IsSatisfiedBy(IQueryable<T> queryable);
    }
}
