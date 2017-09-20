using System.Linq;
using eTestMe.Core.Data.RealmModels;
using eTestMe.Core.Domain.Model;
using eTestMe.Core.Domain.Repository;
using Realms;

namespace eTestMe.Core.Data.RealmRepository
{
    public class RealmUserRepository : IUserRepository
    {
        public User GetUser()
        {
            using (var realm = Realm.GetInstance())
            {
                var realmUser = realm.All<RealmUser>().FirstOrDefault();

                if (realmUser != null)
                {
                    return new User { Username = realmUser.Username };
                }

                return null;
            }
        }

        public void AddUser(User user)
        {
            using (var realm = Realm.GetInstance())
            {
                realm.Write(() =>
                {
                    realm.Add(new RealmUser(user));
                });
            }
        }

        public void RemoveUser(User user)
        {
            using (var realm = Realm.GetInstance())
            {
                var realmUser = realm.All<RealmUser>().Where(u => u.Username == user.Username).FirstOrDefault();

                if (realmUser != null)
                {
                    realm.Write(() =>
                    {
                        realm.Remove(realmUser);
                    });
                }
            }
        }
    }
}
