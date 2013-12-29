
using Domain;
using FluentNHibernate.Mapping;
namespace DataAccess.Mappings
{
    public class MapServiceMapping : EntityMapping<MapService>
    {
        public MapServiceMapping() :base()
        {
            Table("MAP_SERVICE");
            Map(x => x.Name, "SERVICE_NAME");
            Map(x => x.LayerOrder, "LAYER_ORDER");
            Map(x => x.MaximumResolution, "MAX_RESOLUTION");
            Map(x => x.MinimunResolution, "MIN_RESOLUTION");
            Map(x => x.Url, "SERVICE_URL");
            Map(x => x.ServiceType, "SERVICE_TYPE").CustomType<MapServiceType>();
            Map(x => x.Opacity, "OPACITY");
            Map(x => x.SupportMapOperations, "SUPPORTS_MAP");
            Map(x => x.SupportQueryOperations, "SUPPORTS_QUERY");
            Map(x => x.SupportDataOperations, "SUPPORTS_DATA");
            Map(x => x.VisibleByDefault, "VISIBLE_BY_DEFAULT");
        }
    }
}
