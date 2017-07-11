using NHibernate;
using NHibernate.Linq;
using NHibernateTest.Backend.DomainModel;
using NHibernateTest.Backend.Persistence.Helper;
using System.Collections.Generic;
using System.Linq;

namespace NHibernateTest.Backend.Service
{
    public class CarService : ICarService
    {
        public void SaveCar(Car car)
        {
            ISessionFactory sessionFactory = NHibernateHelper.CreateSessionFactory();

            using (ISession session = sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(car);
                transaction.Commit();
            }
        }

        public Car LoadCar(long id)
        {
            ISessionFactory sessionFactory = NHibernateHelper.CreateSessionFactory();

            using (ISession session = sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                Car car = session.Query<Car>()
                    .Fetch(x => x.Owners)
                    .ToList()
                    .First();
                //// or:
                ////Car car = session.Get<Car>(id);
                //// NHibernateUtil.Initialize(car.Owners);
                transaction.Commit();

                return car;
            }
        }

        public IList<Car> LoadCars()
        {
            ISessionFactory sessionFactory = NHibernateHelper.CreateSessionFactory();

            using (ISession session = sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                IList<Car> cars = session.Query<Car>()
                    .Fetch(x => x.Owners)
                    .ToList();
                transaction.Commit();

                return cars;
            }
        }
    }
}
