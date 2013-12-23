using FluentNHibernate.Mapping;
using Domain;
namespace DataAccess.Mappings
{
    public class AuditableBusinessEntityMap<T> : SubclassMap<T> where T : AuditableEntity
    {
        public AuditableBusinessEntityMap()
        {
            Map(x => x.ModifiedDate);
        }
    }
}
