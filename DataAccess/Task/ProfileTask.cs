using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess.Dtos;
using DataAccess.Repositories;
using Domain;
using NHibernate;
using Profile = Domain.Profile;

namespace DataAccess.Task
{
    public class ProfileTask : TaskBase<Profile, ProfileDto>, ITask<Profile, ProfileDto>
    {
        public ProfileTask(IReporsitoryFactory<Profile> repositoryFactory, ISessionFactory sessionFactory)
            : base(repositoryFactory, sessionFactory)
        {
            
        }

        public override void CreateMapping()
        {
            base.CreateMapping();
            Mapper.CreateMap<MapService, MapServiceDto>();
            Mapper.CreateMap<ActiveDirectoryGroup, ActiveDirectoryGroupDto>();
            Mapper.CreateMap<Permission, PermissionDto>();
            Mapper.CreateMap<PermissionDto, Permission>();
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

        public IEnumerable<PermissionDto> GetRelatedSearchEntities(int profileId)
        {
            var profile = this.Repository.FindById(profileId);
            var searchEntities = profile.Permissions.ToList();
            var entitiesDto = searchEntities.Select(Mapper.Map<PermissionDto>);
            return entitiesDto;
        }

        public override bool Update(ProfileDto item)
        {
            var trans = Session.BeginTransaction();
            var profile = Repository.FindById(item.Id);
            profile.Name = item.Name;
            profile.Description = item.Description;
            profile.Sequence = item.Sequence;
            Repository.Add(profile);
            trans.Commit();
            return true;
        }

        public bool UpdatePermission(PermissionDto dto)
        {
            var repo = new NHibernateRepository<Permission>(Session);
            var permission = Mapper.Map<Permission>(dto);
            repo.Update(permission);
            return true;
        }

    }
}