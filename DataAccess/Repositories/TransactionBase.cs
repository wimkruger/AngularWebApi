using NHibernate;
using System;
namespace DataAccess.Repositories
{
    public abstract class TransactionBase
    {
        protected ISession Session;

        public TransactionBase(ISession session)
        {
            this.Session = session;
        }

        protected virtual TResult Transact<TResult>(Func<TResult> func)
        {
            if (!Session.Transaction.IsActive)
            {
                TResult result;
                using (var tx = Session.BeginTransaction())
                {
                    result = func.Invoke();
                    tx.Commit();
                }
                return result;
            }
            return func.Invoke();
        }

        protected virtual void Transact(Action action)
        {
            Transact<bool>(() =>
            {
                action.Invoke();
                return false;
            });
        }
    }
}
