using FluentNHibernate.Mapping;

namespace NHibernateTest.Persistence
{
    public class SportCarMap : SubclassMap<SportCar>
    {
        public SportCarMap()
        {
            DiscriminatorValue(1);
        }
    }
}
