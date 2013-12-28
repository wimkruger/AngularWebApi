using Domain;
using FluentNHibernate.Mapping;
namespace DataAccess.Mappings
{
    public class AuditableEntityMap<T> : EntityMapping<T> where T : AuditableEntity
    {
        public AuditableEntityMap()
        {
            Map(x => x.ModifiedDate, "AUDIT_DATE");
            Map(x => x.ModifiedUser, "AUDIT_USER_ID");
        }
    }
}
