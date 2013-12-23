using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            using (TaskBase<MapService, MapServiceDto> _task = new TaskBase<MapService, MapServiceDto>())
            {
                return _task.GetAll();
            }
        }

        public IHttpActionResult GetService(int id)
        {
            using (TaskBase<MapService, MapServiceDto> _task = new TaskBase<MapService, MapServiceDto>())
            {
                var profile = _task.GetById(id);
                if (profile == null)
                    return NotFound();
                return Ok(profile);
            }
        }
    }
}
