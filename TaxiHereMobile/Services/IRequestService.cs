namespace TaxiHereMobile.Services;

public interface IRequestService
{
    public StringContent PrepareRequest(object dtoObject);
}
