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
            Mapper.CreateMap<ActiveDirectoryGroup, ActiveDirectoryGroupDto>();
            Mapper.CreateMap<SearchEntity, SearchEntityDto>();
        }

        public IEnumerable<MapServiceDto> GetRelatedServices(int profileId)
        {
            var profile = this.Repository.FindById(profileId);
            var services = profile.MapServices.ToList();
            var serviceDtos = services.Select(Mapper.Map<MapServiceDto>);
            return serviceDtos;
        }

        public IEnumerable<ActiveDirectoryGroupDto> GetRelatedActiveDirectoryGroups(int profileId)
        {
            var profile = this.Repository.FindById(profileId);
            var adGroups = profile.ActiveDirectoryGroups.ToList();
            var adGroupDtos = adGroups.Select(Mapper.Map<ActiveDirectoryGroupDto>);
            return adGroupDtos;
        }

        public IEnumerable<SearchEntityDto> GetRelatedSearchEntities(int profileId)
        {
            var profile = this.Repository.FindById(profileId);
            var searchEntities = profile.SearchEntities.ToList();
            var entitiesDto = searchEntities.Select(Mapper.Map<SearchEntityDto>);
            return entitiesDto;
        }

    }
}