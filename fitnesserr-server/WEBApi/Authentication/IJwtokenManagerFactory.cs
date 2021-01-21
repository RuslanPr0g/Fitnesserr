using WEBApi.Authentication;

namespace WEBApi
{
    public interface IJwtokenManagerFactory
    {
        IJWTokenManager CreateTokenManager();
    }
}