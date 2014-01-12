using AutoMapper;
using DataAccess.Dtos;
using DataAccess.Repositories;
using Domain;
using NHibernate;

namespace DataAccess.Task
{
    public class MenuTask : TaskBase<Menu, MenuDto>
    {
        public MenuTask(IReporsitoryFactory<Menu> repositoryFactory, ISessionFactory sessionFactory) : base(repositoryFactory, sessionFactory)
        {
        }

        public override void CreateMapping()
        {
            base.CreateMapping();
            Mapper.CreateMap<MenuItem, MenuItemDto>();
        }
    }
}