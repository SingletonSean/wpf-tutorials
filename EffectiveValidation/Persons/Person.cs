namespace EffectiveValidation.Persons
{
    public class Person : IPerson
    {
        private readonly string _fullName;

        public string FullName => _fullName;

        public Person(string fullName)
        {
            _fullName = fullName;
        }
    }
}
