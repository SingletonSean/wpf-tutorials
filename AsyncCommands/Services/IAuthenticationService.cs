using System.Threading.Tasks;

namespace AsyncCommands.Services
{
    public interface IAuthenticationService
    {
        Task Login(string username);
    }
}