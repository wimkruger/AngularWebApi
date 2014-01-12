using System.Collections.Generic;
using System.Web.Http;
using DataAccess.Dtos;
using DataAccess.Specifications;
using DataAccess.Task;
using Domain;

namespace ProfileManager.Controllers
{
    public class MapLayerController : BaseController<MapLayer, MapLayerDto>
    {

        [ActionName("GetLayersByMapService")]
        public IEnumerable<MapLayerDto> GetLayersByMapService(int mapServiceId)
        {
            using (var task = ComponentConfiguration.Container.GetInstance<ITask<MapLayer, MapLayerDto>>())
            {
                var spec = new MapLayerByMapServiceIdSepcification(mapServiceId);
                return task.FindByCriteria(spec);
            }
        }


    }
}
