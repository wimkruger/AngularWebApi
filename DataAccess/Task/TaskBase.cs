using System.Linq;
using AutoMapper;
using DataAccess.Dtos;
using DataAccess.Specifications;
using NHibernate;
using DataAccess.Utils;
using System;
using DataAccess.Repositories;
using Domain;
using System.Collections.Generic;
namespace DataAccess.Task
{
    public class TaskBase<T, TDto> : ITask<T, TDto> where T : Entity where TDto : BaseDto
    {
        private readonly IReporsitoryFactory<T> _repositoryFactory;
        private readonly ISessionFactory _sessionFactory;

        protected IRepository<T> Repository {get; set;}
        protected ISession Session { get; set; }

        public TaskBase(IReporsitoryFactory<T> repositoryFactory, ISessionFactory sessionFactory)
        {
            this._repositoryFactory = repositoryFactory;
            this._sessionFactory= sessionFactory;
            this.Session = this._sessionFactory.OpenSession();
            this.Repository = this._repositoryFactory.CreateRepository(Session);
            CreateMapping();
        }

        public TaskBase() : this(new RepositoryFactory<T>(), SessionManager.SessionFactory) { }

        public  virtual  void CreateMapping()
        {
            Mapper.CreateMap<T, TDto>();
            Mapper.CreateMap<TDto, T>();
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            var values = this.Repository.GetEnumerator();
            var list = new List<T>();
            while (values.MoveNext())
            {
                list.Add(values.Current);
            }
            var dtoList = list.Select(Mapper.Map<TDto>);
            return dtoList;
        }

        public virtual TDto GetById(int id)
        {
            var data = this.Repository.FindById(id);
            var dataDto = Mapper.Map<TDto>(data);
            return dataDto;
        }

        public virtual TDto Add(TDto item)
        {
            var data = Mapper.Map<T>(item);
            this.Repository.Add(data);
            var backDto = Mapper.Map<TDto>( data);
            return backDto;
        }

        public virtual bool Update(TDto item)
        {
            var data = Mapper.Map<T>(item);
            if (!this.Repository.Contains(data))
                return false;
            this.Repository.Add(data);
            return true;
        }

        public IEnumerable<TDto> FindByCriteria(ISpecification<T> spec)
        {
            var values = this.Repository.Find(spec).ToList();
            return  values.Select(Mapper.Map<TDto>);
        }

        #region disposable
        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                Session.Close();
                Session.Dispose();
            }
        }

        ~TaskBase() 
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        #endregion 

    }
}
