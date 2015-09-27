using NHibernate;
using NHibernateTest.Persistence.Helper;

namespace NHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new SportCar("Porsche", "356", "silver");
            SaveCar(car);

            Car truck = new Truck("Ford", "F-350", "blue");
            SaveCar(truck);
        }
        
        public static void SaveCar(Car car)
        {
            ISessionFactory sessionFactory = 
                NHibernateHelper.CreateSessionFactory();

            using (ISession session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(car);
                transaction.Commit();
            }
        }
    }
}
