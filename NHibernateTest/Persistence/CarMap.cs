using FluentNHibernate.Mapping;

namespace NHibernateTest.Persistence
{
    public class CarMap : ClassMap<Car>
    {
        public CarMap()
        {
            Table("Car");
            Id(x => x.Id).UniqueKey("Id");
            Map(x => x.Name).Nullable();
            Map(x => x.Model).Nullable();
            Map(x => x.Color).Nullable();
            //DiscriminateSubClassesOnColumn("Type");
        }
    }
}
