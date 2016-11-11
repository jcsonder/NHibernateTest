using FluentNHibernate.Mapping;
using NHibernateTest.Backend.DomainModel;

namespace NHibernateTest.Backend.Persistence
{
    public class SportCarMap : SubclassMap<SportCar>
    {
        public SportCarMap()
        {
            DiscriminatorValue(1);
        }
    }
}
