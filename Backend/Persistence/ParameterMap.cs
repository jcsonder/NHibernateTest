using FluentNHibernate.Mapping;
using NHibernateTest.Backend.DomainModel;

namespace NHibernateTest.Backend.Persistence
{
    public class ParameterMap : ClassMap<Parameter>
    {
        public ParameterMap()
        {
            Table("Parameter");
            Id(x => x.Id).UniqueKey("Id");

            Map(x => x.Name).Length(100).Nullable();
        }
    }
}
