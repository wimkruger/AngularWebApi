using DataAccess.Dtos;
using DataAccess.Repositories;
using DataAccess.Task;
using DataAccess.Utils;
using Domain;
using NHibernate;
using StructureMap;

namespace ProfileManager
{
    public static class ComponentConfiguration
    {
        private static IContainer _container;
        public static IContainer Container
        {
            get { return _container ?? (_container = ConfigureDependencies()); }
        }

        public static IContainer ConfigureDependencies()
        {
            return new Container(x =>
            {
                x.For(typeof(ITask<,>)).Use(typeof(TaskBase<,>));
                x.For(typeof (IReporsitoryFactory<>)).Use(typeof (RepositoryFactory<>));
                x.For<ISessionFactory>().Use(SessionManager.SessionFactory);
                x.For<ITask<Profile, ProfileDto>>().Use<ProfileTask>();
            });
        }

    }
}