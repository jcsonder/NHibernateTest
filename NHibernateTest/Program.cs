using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernateTest.Persistence.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Name = "Porsche";

            SaveCar(car);
        }
        
        public static void SaveCar(Car car)
        {
            ISessionFactory sessionFactory = 
                NHibernateHelper.CreateSessionFactory("firstProject.db");

            using (ISession session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(car);
                transaction.Commit();
            }
        }
    }
}
