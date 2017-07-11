using FluentNHibernate.Data;

namespace NHibernateTest.Backend.DomainModel
{
    public class Owner : Entity
    {
        public Owner()
        { }

        public virtual string Name { get; set; }
        public virtual int Year { get; set; }
        public virtual Car Car { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", Id, Name, Year);
        }
    }
}
