using Domain;
using NHibernate;
namespace DataAccess.Repositories
{
    public interface IReporsitoryFactory<T> where T : Entity
    {
        IRepository<T> CreateRepository(ISession session);
    }
}
