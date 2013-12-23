using NHibernate;
using Domain;
namespace DataAccess.Repositories
{
    public class RepositoryFactory<T> : IReporsitoryFactory<T> where T : Entity
    {
        public IRepository<T> CreateRepository(ISession session)
        {
            return new NHibernateRepository<T>(session);
        }
    }
}
