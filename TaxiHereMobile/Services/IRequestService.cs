namespace TaxiHereMobile.Services;

public interface IRequestService
{
    public string GetRoute(RequestTo reqTo);
    public string PrepareEndPoint(RequestTo reqTo, string endPoint);
    public StringContent PrepareRequest(object dtoObject);
}
