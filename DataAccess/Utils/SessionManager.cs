
using FluentNHibernate.Cfg;
using DataAccess.Mappings;
using NHibernate;
using NHibernate.Event;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
namespace DataAccess.Utils
{
    public static class SessionManager
    {
        static SessionManager()
        {
            log4net.Config.XmlConfigurator.Configure();
            var cfg = new ConfigurationBuilder().Build();
            var nhConfig = Fluently.Configure(cfg);
            
            nhConfig.Mappings(m =>
                m.FluentMappings.AddFromAssemblyOf<SystemTime>()
                .Conventions.Add<EnumConvention>())
                .ExposeConfiguration(x => x.EventListeners.PreInsertEventListeners = new IPreInsertEventListener[] { new AuditEventListener()})
                .ExposeConfiguration(x => x.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[] { new AuditEventListener()})
                .BuildConfiguration();
            SessionFactory = nhConfig.BuildSessionFactory();
            /* to show the sql generation , just enable this code
            var schema = new SchemaExport(cfg);
            schema.Execute(true, false, false);*/
        }


        public static ISessionFactory SessionFactory { get; set; }

    }
}
