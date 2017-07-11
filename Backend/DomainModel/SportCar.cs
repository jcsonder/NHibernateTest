namespace NHibernateTest.Backend.DomainModel
{
    public class SportCar : Car
    {
        public SportCar()
        { }

        public override string Drive()
        {
            return ("vroooomvroooomvroooomvroooom i'm a sports car - " + Name);
        }
    }
}
