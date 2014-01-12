using Domain;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings
{
    public class EntityMapping<T> : ClassMap<T> where T : Entity
    {
         public EntityMapping()
         {
             Schema("GEOFIND_META");
             Id(x => x.Id, "OBJECT_ID");
         }
    }
}