using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Car>())
              .BuildSessionFactory();
        }
    }
}
