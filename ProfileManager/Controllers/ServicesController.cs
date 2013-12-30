using System.Collections.Generic;
using System.Web.Http;
using DataAccess.Dtos;
using DataAccess.Task;
using Domain;

namespace ProfileManager.Controllers
{
    public class ServicesController : ApiController
    {

        public IEnumerable<MapServiceDto> GetAllServices()
        {
            using (var task = ComponentConfiguration.Container.GetInstance<ITask<MapService,MapServiceDto>>())
            {
                return task.GetAll();
            }
        }

        public IHttpActionResult GetService(int id)
        {
            using (var task = ComponentConfiguration.Container.GetInstance<ITask<MapService, MapServiceDto>>())
            {
                var service = task.GetById(id);
                if (service == null)
                    return NotFound();
                return Ok(service);
            }
            
        }

        public bool PutService(MapServiceDto mapService)
        {
            using (var task = ComponentConfiguration.Container.GetInstance<ITask<MapService, MapServiceDto>>())
            {
                return task.Update(mapService);
            }
        }


        [Route("api/services/{id}/layers")]
        public IEnumerable<MapLayerDto> GetRelatedLayers(int id)
        {
            var layerController = new MapLayerController();
            return layerController.GetLayersByMapService(id);
        }

    }
}
