using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateTest.Persistence.Helper
{
    public class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory(string fileName)
        {
            return Fluently.Configure()
              .Database(
                SQLiteConfiguration.Standard
                  .UsingFile(fileName)
              )
              .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Car>())
              .BuildSessionFactory();
        }
    }
}
