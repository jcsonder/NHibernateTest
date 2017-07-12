using FluentNHibernate.Data;

namespace NHibernateTest.Backend.DomainModel
{
    public class Parameter : Entity
    {
        public virtual string Name { get; set; }
    }
}
