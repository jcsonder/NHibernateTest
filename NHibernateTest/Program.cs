using NHibernate;
using NHibernateTest.Persistence.Helper;

namespace NHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Porsche", "356", "silver");

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
