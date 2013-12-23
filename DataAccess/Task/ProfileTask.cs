using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess.Dtos;
using Domain;
using Profile = Domain.Profile;

namespace DataAccess.Task
{
    public class ProfileTask : TaskBase<Profile, ProfileDto>, ITask<Profile, ProfileDto>
    {
        public override void CreateMapping()
        {
            base.CreateMapping();
            Mapper.CreateMap<MapService, MapServiceDto>();
        }

        public IEnumerable<MapServiceDto> GetRelatedServices(int profileId)
        {
            var profile = this.Repository.FindById(profileId);
            var services = profile.MapServices.ToList();
            var serviceDtos = services.Select(Mapper.Map<MapServiceDto>);
            return serviceDtos;
        }
    }
}