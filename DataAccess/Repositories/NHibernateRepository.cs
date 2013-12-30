using DataAccess.Specifications;
using Domain;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace DataAccess.Repositories
{
    public class NHibernateRepository<T> : TransactionBase, IRepository<T> where T : Entity
    {
        public NHibernateRepository(ISession session)
            : base(session)
        {
        }

        public T Add(T item)
        {
            Transact(() => Session.Save(item));
            return item;
        }

        public bool Update(T item)
        {
            bool result = false;
            Transact(() =>
                {
                    Session.Update(item);
                    result = true;
                });
            return result;
        }
        
        public bool Contains(T item)
        {
            if (item.Id == 0)
                return false;
            return Transact(() => Session.Get<T>(item.Id)) != null;
        }

        public int Count
        {
            get
            {
                return Transact(() => Session.Query<T>().Count());
            }
        }

        public bool Remove(T item)
        {
            Transact(() => Session.Delete(item));
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Transact(() => Session.Query<T>().GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Transact(() => GetEnumerator());
        }

        public T FindById(int id)
        {
            return Transact(() => Session.Get<T>(id));
        }

        public IQueryable<T> Find(ISpecification<T> specification)
        {
            var query = Session.Query<T>();
            return Transact(() =>
                specification.IsSatisfiedBy(query));
        }

        //public PagedResult<T> Search<TCriteria>(TCriteria criteria)
        //{
        //    throw new System.NotImplementedException();
        //}



        //public IQueryable<T> Find(ISpecification<T> specification, BaseSearchCriteria criteria)
        //{
        //    return Transact(() => specification.IsSatisfiedBy(session, criteria));
        //}

    }
}
