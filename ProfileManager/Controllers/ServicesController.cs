﻿using System;
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

        private readonly ITaskFactory<MapService, MapServiceDto> _factory;

        public ServicesController(ITaskFactory<MapService, MapServiceDto> factory)
        {
            _factory = factory;
        }
        public ServicesController() : this(new TaskFactory<MapService, MapServiceDto>())
        {
            
        }

        public IEnumerable<MapServiceDto> GetAllServices()
        {
            using (var task = _factory.CreateTask())
            {
                return task.GetAll();
            }
        }

        public IHttpActionResult GetService(int id)
        {
            using (var task = _factory.CreateTask())
            {
                var service = task.GetById(id);
                if (service == null)
                    return NotFound();
                return Ok(service);
            }
            
        }

        [Route("api/services/{id}/layers")]
        public IEnumerable<MapLayerDto> GetLayersByServiceId(int id)
        {
            using (var task = (ServiceTask)_factory.CreateTask())
            {
                var entities = task.GetRelatedLayers(id);
                return entities;
            }
        }
        
    }
}
