namespace EffectiveValidation.UpdateAddress
{
    public interface IAddress
    {
        string AddressLine1 { get; }
        string AddressLine2 { get; }
        string City { get; }
        string State { get; }
        string ZipCode { get; }
    }
}