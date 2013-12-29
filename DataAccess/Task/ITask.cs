using System;
using System.Collections.Generic;
using DataAccess.Dtos;
using DataAccess.Specifications;
using Domain;

namespace DataAccess.Task
{
    public interface ITask<T, TDto> : IDisposable  
        where T : Entity 
        where TDto : BaseDto
    {
        IEnumerable<TDto> GetAll();
        TDto GetById(int id);
        TDto Add(TDto item);
        bool Update(TDto item);
        IEnumerable<TDto> FindByCriteria(ISpecification<T> spec);
    }
}