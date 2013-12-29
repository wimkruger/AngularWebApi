using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Dtos;
using DataAccess.Specifications;
using DataAccess.Task;
using Domain;

namespace ProfileManager.Controllers
{
    public class MapLayerController : ApiController
    {
        private readonly ITaskFactory<MapLayer, MapLayerDto> _factory = new TaskFactory<MapLayer, MapLayerDto>();
        // GET api/maplayer
        public IEnumerable<MapLayerDto> Get()
        {
            using (var task = _factory.CreateTask())
            {
                return task.GetAll();
            }
        }

        // GET api/maplayer/5
        public MapLayerDto Get(int id)
        {
            using (var task = _factory.CreateTask())
            {
                return task.GetById(id);
            }
        }

        [ActionName("GetByMyService")]
         public IEnumerable<MapLayerDto> GetLayersByMapService(int mapServiceId)
        {
            using (var task = _factory.CreateTask())
            {
                var spec = new MapLayerByMapServiceIdSepcification(mapServiceId);
                return task.FindByCriteria(spec);
            }
        }


        // POST api/maplayer
        public void Post([FromBody]string value)
        {
        }

        // PUT api/maplayer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/maplayer/5
        public void Delete(int id)
        {
        }
    }
}
