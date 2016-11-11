using NHibernateTest.Backend.DomainModel;
using System.Collections.Generic;

namespace NHibernateTest.Backend.Service
{
    public interface ICarService
    {
        IList<Car> LoadCars();

        Car LoadCar(long id);
        
        void SaveCar(Car car);
    }
}
