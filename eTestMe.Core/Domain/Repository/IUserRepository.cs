using eTestMe.Core.Domain.Model;

namespace eTestMe.Core.Domain.Repository
{
    public interface IUserRepository
    {
		User GetUser();

		void AddUser(User user);

		void RemoveUser(User activeUser);
    }
}
