using Domain;
using FluentNHibernate.Mapping;
namespace DataAccess.Mappings
{
    public class AuditableEntityMap<T> : ClassMap<T> where T : AuditableEntity
    {
        public AuditableEntityMap()
        {
            Map(x => x.ModifiedDate);
        }
    }
}
