using FluentNHibernate.Data;
using NHibernate.Util;
using System.Collections.Generic;

namespace NHibernateTest.Backend.DomainModel
{
    public abstract class Car : Entity
    {
        public Car()
        {
            Owners = new List<Owner>();
        }

        public virtual string Name { get; set; }
        public virtual string Model { get; set; }
        public virtual string Color { get; set; }
        public virtual IList<Owner> Owners { get; set; }

        public abstract string Drive();

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}-{3}", Id, Name, Color, Owners.Any() ? Owners.First() : "none" );
        }
    }
}
