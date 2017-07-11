using FluentNHibernate.Mapping;
using NHibernateTest.Backend.DomainModel;

namespace NHibernateTest.Backend.Persistence
{
    public class CarMap : ClassMap<Car>
    {
        public CarMap()
        {
            Table("Car");
            Id(x => x.Id).UniqueKey("Id");

            DiscriminateSubClassesOnColumn("CarType", (byte)0);

            Map(x => x.Name).Length(100).Nullable();
            Map(x => x.Model).Length(100).Nullable();
            Map(x => x.Color).Length(20).Nullable();

            HasMany(x => x.Owners)
                .Inverse()
                .KeyColumns.Add("CarId", mapping => mapping.Name("CarId"))
                .Cascade.All();
        }
    }
}
