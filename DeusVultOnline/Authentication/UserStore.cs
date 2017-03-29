using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MongoDB.Driver;
namespace DeusVultOnline.Authentication
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>, IUserEmailStore<User>, IUserLockoutStore<User, string>, IUserTwoFactorStore<User, string>
    {
        public void Dispose()
        {
            //Mongo does this pretty good without help 
        }

        public Task CreateAsync(User user)
        {
            return Task.Run(()=>Repository.Instance.GetCollection<User>().InsertOne(user));
        }

        public Task UpdateAsync(User user)
        {
            return Task.Run(() => Repository.Instance.GetCollection<User>().ReplaceOne(Builders<User>.Filter.Eq(u => u.Id, user.Id), user));
        }

        public Task DeleteAsync(User user)
        {
            return Task.Run(() => Repository.Instance.GetCollection<User>().ReplaceOne(Builders<User>.Filter.Eq(u => u.Id, user.Id), user));
        }

        public Task<User> FindByIdAsync(string userId)
        {
            return Task.Run(() => Repository.Instance.GetCollection<User>().FindSync(Builders<User>.Filter.Eq(u => u.Id, userId)).FirstOrDefault());
        }

        public Task<User> FindByNameAsync(string userName)
        {
            var user = Repository.Instance.GetCollection<User>().FindSync(Builders<User>.Filter.Eq(u => u.UserName, userName)).FirstOrDefault();
            return Task.Run(() => user);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return Task.Run(() => user.PasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.Run(() => user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.Run(() => !string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task SetEmailAsync(User user, string email)
        {
            return Task.Run(() => user.EmailAddress = email);
        }

        public Task<string> GetEmailAsync(User user)
        {
            return Task.Run(() => user.EmailAddress);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            return Task.Run(() => user.EmailAddressConfirmed);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            return Task.Run(() => user.EmailAddressConfirmed = confirmed);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return Task.Run(() => Repository.Instance.GetCollection<User>().FindSync(Builders<User>.Filter.Eq(u => u.EmailAddress, email)).FirstOrDefault());
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return Task.Run(() => user.BannedUntil);
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return Task.Run(() => user.AccessFailedCount++);
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            return Task.Run(() => user.AccessFailedCount = 0);
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.Run(() => user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.Run(() => user.LockoutEnabled);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            return Task.Run(() => user.LockoutEnabled = enabled);
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            return Task.Run(() => user.BannedUntil = lockoutEnd);
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return Task.Run(()=>null);
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.Run(() => false);
        }
    }
}