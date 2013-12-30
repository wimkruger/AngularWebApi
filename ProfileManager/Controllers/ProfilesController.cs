using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataAccess.Dtos;
using DataAccess.Task;
using Profile = Domain.Profile;

namespace ProfileManager.Controllers
{
    public class ProfilesController : ApiController
    {

        
        public IEnumerable<ProfileDto> GetAllProfiles()
        {
            using (var task = ComponentConfiguration.Container.GetInstance<ITask<Profile, ProfileDto>>())
            {
                var profiles =  task.GetAll();
                return profiles;
            }
        }

        public IHttpActionResult GetProfile(int id)
        {
            using (var task = ComponentConfiguration.Container.GetInstance<ITask<Profile, ProfileDto>>())
            {
                var profile = task.GetById(id);
                if (profile == null)
                    return NotFound();
                return Ok(profile);
            }
        }

        public bool Put(ProfileDto profile)
        {
            using (var task = (ProfileTask)ComponentConfiguration.Container.GetInstance<ITask<Profile, ProfileDto>>())
            {
                var result = task.Update(profile);
                return (result);
            }
        }

        [Route("api/profiles/{id}/mapServices")]
        public IEnumerable<MapServiceDto> GetMapServicesByProfile(int id)
        {
            using (var task = (ProfileTask) ComponentConfiguration.Container.GetInstance<ITask<Profile, ProfileDto>>())
            {
                var services = task.GetRelatedServices(id);
                return services;
            }
        }

        [Route("api/profiles/{id}/adGroups")]
        public IEnumerable<ActiveDirectoryGroupDto> GetActiveDirectoryGroupsByProfile(int id)
        {
            using (var task = (ProfileTask) ComponentConfiguration.Container.GetInstance<ITask<Profile, ProfileDto>>())
            {
                var services = task.GetRelatedActiveDirectoryGroups(id);
                return services;
            }
        }

        [Route("api/profiles/{id}/searchEntities")]
        public IEnumerable<PermissionDto> GetSearchEntitiesByProfile(int id)
        {
            using (var task = (ProfileTask)ComponentConfiguration.Container.GetInstance<ITask<Profile, ProfileDto>>())
            {
                var entities = task.GetRelatedSearchEntities(id);
                return entities;
            }
        }

        [Route("api/profiles/{id}/searchEntities")]
        [AcceptVerbs("PUT")]
        public bool PutSearchEntitiesByProfile(PermissionDto dto)
        {
            using (var task = (ProfileTask)ComponentConfiguration.Container.GetInstance<ITask<Profile, ProfileDto>>())
            {
                var entities = task.Update(dto);
                return entities;
            }
        }
    }
}
