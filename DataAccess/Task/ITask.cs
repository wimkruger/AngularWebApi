using System;
using System.Collections.Generic;
using Domain;

namespace DataAccess.Task
{
    public interface ITask<T, out TDto> : IDisposable  
        where T : Entity 
        where TDto : BaseDto
    {
        IEnumerable<TDto> GetAll();
        TDto GetById(int id);
    }
}