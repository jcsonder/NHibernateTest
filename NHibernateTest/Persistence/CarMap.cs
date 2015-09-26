using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTest.Persistence
{
    public class CarMap : ClassMap<Car>
    {
        public CarMap()
        {
            Table("Car");
            Id(x => x.Id).UniqueKey("Id");
            Map(x => x.Name);

            //Map(x => x.Color);
            //Map(x => x.Model);
            //DiscriminateSubClassesOnColumn("Type");
        }
    }
}
