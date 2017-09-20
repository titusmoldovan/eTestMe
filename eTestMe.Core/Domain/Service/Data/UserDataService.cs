using System.Threading.Tasks;
using eTestMe.Core.Domain.Model;
using eTestMe.Core.Domain.Repository;

namespace eTestMe.Core.Domain.Service.Data
{
    public class UserDataService : IUserDataService
	{
		readonly IUserRepository _userRepository;
		User _activeUser;

		public User CurrentUser
		{
			get
			{
				_activeUser = _activeUser ?? _userRepository.GetUser();
				return _activeUser;
			}
		}

		public UserDataService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<User> Login(string userName, string password)
		{
			//TODO make api call here for login. return user?

			//   if (userName == "a@a.a" && password == "aaa")
			{
				var user = new User { Username = userName };
				_userRepository.AddUser(user);
				_activeUser = user;
				return user;
			}

			//   throw new Exception();
		}

		public async Task LogoutUser()
		{
			_userRepository.RemoveUser(_activeUser);
			//todo clear other data
			_activeUser = null;
		}
	}
}
