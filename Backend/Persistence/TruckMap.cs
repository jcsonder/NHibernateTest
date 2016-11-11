using FluentNHibernate.Mapping;
using NHibernateTest.Backend.DomainModel;

namespace NHibernateTest.Backend.Persistence
{
    public class TruckMap : SubclassMap<Truck>
    {
        public TruckMap()
        {
            DiscriminatorValue(2);
        }
    }
}
