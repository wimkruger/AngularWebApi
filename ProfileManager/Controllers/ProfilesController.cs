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

        private readonly ITaskFactory<Profile, ProfileDto> _factory;

        public ProfilesController() : this(new TaskFactory<Profile, ProfileDto>())
        {
        }

        public ProfilesController(TaskFactory<Profile, ProfileDto> factory)
        {
            _factory = factory;
        }

        public IEnumerable<ProfileDto> GetAllProfiles()
        {
            using (var task = _factory.CreateTask())
            {
                var profiles =  task.GetAll();
                return profiles;
            }
        }

        public IHttpActionResult GetProfile(int id)
        {
            using (var task = _factory.CreateTask())
            {
                var profile = task.GetById(id);
                if (profile == null)
                    return NotFound();
                return Ok(profile);
            }
        }

        [Route("api/profiles/{id}/mapServices")]
        public IEnumerable<MapServiceDto> GetMapServicesByProfile(int id)
        {
            using (var task = (ProfileTask) _factory.CreateTask())
            {
                var services = task.GetRelatedServices(id);
                return services;
            }
        }
    }
}
