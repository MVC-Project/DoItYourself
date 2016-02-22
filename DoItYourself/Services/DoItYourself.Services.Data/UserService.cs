namespace DoItYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class UserService : IUserService
    {
        private readonly IDbRepository<User> users;

        public UserService(IDbRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> AllUsers()
        {
            return this.users.All();
        }

        public IQueryable<User> AllUsersWithDeleted()
        {
            return this.users.AllWithDeleted();
        }

        public User GetById(object id)
        {
            return this.users.GetById(id);
        }

        public void DeleteUser(User user)
        {
            this.users.Delete(user);
            this.users.Save();
        }

        public void HardDeleteUser(User user)
        {
            this.users.HardDelete(user);
            this.users.Save();
        }

        public void DeleteUserById(object id)
        {
            var user = this.users.GetById(id);
            this.users.Delete(user);
            this.users.Save();
        }

        public void HardDeleteUserById(object id)
        {
            var user = this.users.GetById(id);
            this.users.HardDelete(user);
            this.users.Save();
        }

        public IQueryable<User> TopActiveUsers(int take = 5)
        {
            return this.users.All()
                .OrderByDescending(user => (user.ProjectComments.Count() + user.QuestionComments.Count()))
                .Take(take);
        }
    }
}
