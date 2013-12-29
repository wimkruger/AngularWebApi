using DataAccess.Dtos;
using Domain;

namespace DataAccess.Task
{
    public class TaskFactory<T, TDto> : ITaskFactory<T, TDto> where T : Entity where TDto : BaseDto
    {
        public ITask<T, TDto> CreateTask()
        {

            if (typeof (T) == typeof (Profile))
                return new ProfileTask() as ITask<T, TDto>;
            return new TaskBase<T, TDto>();
        }
    }
}