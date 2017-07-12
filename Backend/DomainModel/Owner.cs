using FluentNHibernate.Data;
using System.Collections.Generic;

namespace NHibernateTest.Backend.DomainModel
{
    public class Owner : Entity
    {
        public Owner()
        {
            Parameters = new List<Parameter>();
        }

        public virtual string Name { get; set; }
        public virtual int Year { get; set; }
        public virtual Car Car { get; set; }

        public virtual IList<Parameter> Parameters { get; set; }

        public override string ToString()
        {
            return string.Format("Id={0}, Name={1}, Year={2}", Id, Name, Year);
        }
    }
}
