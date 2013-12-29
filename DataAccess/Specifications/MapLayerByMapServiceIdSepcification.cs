using System.Linq;
using Domain;

namespace DataAccess.Specifications
{
    public class MapLayerByMapServiceIdSepcification : ISpecification<MapLayer>
    {
        private readonly int _mapServiceId;
        public MapLayerByMapServiceIdSepcification(int mapServiceId)
        {
            _mapServiceId = mapServiceId;
        }
        public IQueryable<MapLayer> IsSatisfiedBy(IQueryable<MapLayer> queryable)
        {
            return queryable.Where(x => x.MapServiceId == _mapServiceId);
        }
    }
}