namespace EffectiveValidation.Persons
{
    public class PersonViewModel : IPerson
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public string FullName => $"{FirstName} {LastName}";
    }
}
