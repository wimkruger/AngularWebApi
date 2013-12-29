using DataAccess.Dtos;
using Domain;

namespace DataAccess.Task
{
    public interface ITaskFactory<T, TDto> where T : Entity where TDto : BaseDto
    {
        ITask<T, TDto> CreateTask();
    }
}