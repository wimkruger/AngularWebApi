using NHibernate.Event;
using Domain;
using System;
using NHibernate.Persister.Entity;
namespace DataAccess.Utils
{
    public class AuditEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        public bool OnPreInsert(PreInsertEvent @event)
        {
            var audit = @event.Entity as AuditableEntity;
            if (audit == null)
                return false;
            var date = SystemTime.Now();
            var user = Environment.UserName;
            Set(@event.Persister, @event.State, "ModifiedDate", date);
            Set(@event.Persister, @event.State, "ModifiedUser", user);
            audit.ModifiedDate = date;
            audit.ModifiedUser = user;
            return false;
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var audit = @event.Entity as AuditableEntity;
            if (audit == null)
                return false;
            var date = SystemTime.Now();
            var user = Environment.UserName;
            Set(@event.Persister, @event.State, "ModifiedDate", date);
            Set(@event.Persister, @event.State, "ModifiedUser", user);
            audit.ModifiedDate = date;
            audit.ModifiedUser = user;
            return false;
        }

        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }

    }
}
