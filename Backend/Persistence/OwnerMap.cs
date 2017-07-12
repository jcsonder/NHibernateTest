using FluentNHibernate.Mapping;
using NHibernateTest.Backend.DomainModel;

namespace NHibernateTest.Backend.Persistence
{
    public class OwnerMap : ClassMap<Owner>
    {
        public OwnerMap()
        {
            Table("Owner");
            Id(x => x.Id).UniqueKey("Id");

            Map(x => x.Name).Length(100).Nullable();
            Map(x => x.Year).Nullable();

            References(x => x.Car);
            ////.Columns("CarId");  // Define the FK name manually

            HasManyToMany(x => x.Parameters)
                .Not.LazyLoad()
                .ParentKeyColumn("OwnerParameter_Id")
                .ChildKeyColumn("Parameter_Id")
                .Cascade.AllDeleteOrphan()
                .Fetch.Join();
        }
    }
}
