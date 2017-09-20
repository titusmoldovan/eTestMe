using System.Threading.Tasks;
using eTestMe.Core.Domain.Model;

namespace eTestMe.Core.Domain.Service.Data
{
    public interface IUserDataService
    {
        Task<User> Login(string userName, string password);

        User CurrentUser { get; }

        Task LogoutUser();
    }
}