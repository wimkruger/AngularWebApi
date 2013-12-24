using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess.Dtos;
using Domain;

namespace DataAccess.Task
{
    public class ServiceTask : TaskBase<MapService, MapServiceDto>, ITask<MapService, MapServiceDto>
    {
        public override void CreateMapping()
        {
            base.CreateMapping();
            Mapper.CreateMap<MapLayer, MapLayerDto>();
        }

        public IEnumerable<MapLayerDto> GetRelatedLayers(int serviceId)
        {
            var service = this.Repository.FindById(serviceId);
            var layers = service.MapLayers.ToList();
            var dtos = layers.Select(Mapper.Map<MapLayerDto>);
            return dtos;
        }
    }
}