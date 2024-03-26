namespace RentH2.Infra.Repositories.Base
{
    public interface IHttpParam
    {
        string GetApiUrl();
        string GetToken();
        bool IsAuthentication();
    }
}
