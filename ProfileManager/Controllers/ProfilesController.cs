using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataAccess.Dtos;
using DataAccess.Task;
using Profile = Domain.Profile;

namespace ProfileManager.Controllers
{
    public class ProfilesController : BaseController<Profile, ProfileDto>
    {

        
        

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

        [Route("api/profiles/{id}/permissions")]
        public IEnumerable<PermissionDto> GetPermissions(int id)
        {
            using (var task = (ProfileTask)ComponentConfiguration.Container.GetInstance<ITask<Profile, ProfileDto>>())
            {
                var entities = task.GetRelatedSearchEntities(id);
                return entities;
            }
        }

        [Route("api/profiles/{id}/permissions")]
        [AcceptVerbs("PUT")]
        public bool PutPermission(PermissionDto dto)
        {
            using (var task = (ProfileTask)ComponentConfiguration.Container.GetInstance<ITask<Profile, ProfileDto>>())
            {
                var entities = task.UpdatePermission(dto);
                return entities;
            }
        }

        [Route("api/profiles/{id}/menus")]
        public IEnumerable<MenuDto> GetMenus(int id)
        {
            using (var task = (ProfileTask)ComponentConfiguration.Container.GetInstance<ITask<Profile, ProfileDto>>())
            {
                var menus = task.GetRelatedMenus(id);
                return menus;
            }
        }
    }
}
