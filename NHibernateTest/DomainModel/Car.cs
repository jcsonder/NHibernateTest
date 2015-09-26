using FluentNHibernate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTest
{
    public class Car : Entity // : ICar
    {
        public virtual string Name { get; set; }
        //public virtual string Model { get; set; }
        //public virtual string Color { get; set; }
        //public abstract string Drive();
    }
}
