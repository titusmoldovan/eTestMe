using eTestMe.Core.Domain.Model;
namespace eTestMe.Core.Data.RealmModels
{
    public class RealmUser //: RealmObject
	{
		public string Username { get; set; }

		public RealmUser()
		{

		}

		public RealmUser(User user)
		{
			Username = user.Username;
		}
	}
}
