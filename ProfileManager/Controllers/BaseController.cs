using System.Collections.Generic;
using System.Web.Http;
using DataAccess.Dtos;
using DataAccess.Task;
using Domain;


namespace ProfileManager.Controllers
{
    public class BaseController<T, TDto> : ApiController where T : Entity where TDto : BaseDto
    {
        // GET api/base
        public virtual IEnumerable<TDto> Get()
        {
            using (var task = ComponentConfiguration.Container.GetInstance<ITask<T, TDto>>())
            {
                return task.GetAll();
            }
        }

        // GET api/base/5
        public virtual TDto Get(int id)
        {
            using (var task = ComponentConfiguration.Container.GetInstance<ITask<T, TDto>>())
            {
                return task.GetById(id);
            }
        }

        // POST api/base
        public virtual void Post(TDto inputData)
        {
        }

        // PUT api/base/5
        public virtual void Put(TDto inputData)
        {
            using (var task = ComponentConfiguration.Container.GetInstance<ITask<T, TDto>>())
            {
                task.Update(inputData);
            }
        }

        // DELETE api/base/5
        public void Delete(int id)
        {
        }
    }
}
