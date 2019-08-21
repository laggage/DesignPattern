namespace BuilderPattern.DrawPerson
{
    public class PersonDirector
    {
        private PersonBuilder _personBuilder;

        public PersonDirector(PersonBuilder builder)
        {
            _personBuilder = builder;
        }

        public void CreatePerson()
        {
            _personBuilder.BuildHead();
            _personBuilder.BuildBody();
            _personBuilder.BuildArmLeft();
            _personBuilder.BuildArmRight();
            _personBuilder.BuildLegLeft();
            _personBuilder.BuildLegRight();
        }
    }
}
