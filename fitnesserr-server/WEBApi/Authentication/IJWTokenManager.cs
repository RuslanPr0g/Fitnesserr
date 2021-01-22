using System.Threading;
using System.Threading.Tasks;

namespace WEBApi.Authentication
{
    public interface IJWTokenManager
    {
        Task<string> Authorize(string email, string password, CancellationToken cancellation = default);
    }
}