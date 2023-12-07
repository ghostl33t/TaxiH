namespace TaxiHereMobile.Services;

public interface IRequestService
{
    public string GetRoute();
    public string PrepareEndPoint(string endPoint);
    public StringContent PrepareRequest(object dtoObject);
}
