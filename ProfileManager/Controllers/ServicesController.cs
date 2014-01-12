using System.Collections.Generic;
using System.Web.Http;
using DataAccess.Dtos;
using DataAccess.Task;
using Domain;

namespace ProfileManager.Controllers
{
    public class ServicesController : BaseController<MapService, MapServiceDto>
    {


        [Route("api/services/{id}/layers")]
        public IEnumerable<MapLayerDto> GetRelatedLayers(int id)
        {
            var layerController = new MapLayerController();
            return layerController.GetLayersByMapService(id);
        }

    }
}
