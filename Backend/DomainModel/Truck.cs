namespace NHibernateTest.Backend.DomainModel
{
    public class Truck : Car
    {
        public Truck()
        { }

        public override string Drive()
        {
            return ("grrrrrrrrrrrr i'm a sports truck - " + Name);
        }
    }
}
