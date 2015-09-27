using FluentNHibernate.Mapping;

namespace NHibernateTest.Persistence
{
    public class TruckMap : SubclassMap<Truck>
    {
        public TruckMap()
        {
            DiscriminatorValue(2);
        }
    }
}
