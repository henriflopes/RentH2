namespace RentH2.Infrastructure.Repositories.Base
{
    public interface IHttpParam
    {
        string GetApiUrl();
        string GetToken();
        bool IsAuthentication();
    }
}
