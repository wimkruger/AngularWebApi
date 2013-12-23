
using Domain;
using FluentNHibernate.Mapping;
namespace DataAccess.Mappings
{
    public class MapServiceMapping : ClassMap<MapService>
    {
        public MapServiceMapping()
        {
            Schema("PROFILEDATA");
            Table("MAP_SERVICE");
            Id(x => x.Id, "OBJECT_ID");
            Map(x => x.Name, "SERVICE_NAME");
            Map(x => x.LayerOrder, "LAYER_ORDER");
            Map(x => x.MaximumResolution, "MAX_RESOLUTION");
            Map(x => x.MinimunResolution, "MIN_RESOLUTION");
            Map(x => x.Url, "SERVICE_URL");
            Map(x => x.ServiceType, "SERVICE_TYPE").CustomType<MapServiceType>();
        }
    }
}
