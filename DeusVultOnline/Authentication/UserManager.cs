using Microsoft.AspNet.Identity;

namespace DeusVultOnline.Authentication
{
    public class UserManager: UserManager<User>
    {
        public UserManager(IUserStore<User> store) : base(store)
        {
        }

        public static UserManager Create()
        {
            var manager = new UserManager(new UserStore());
            return manager;
        }
    }
}