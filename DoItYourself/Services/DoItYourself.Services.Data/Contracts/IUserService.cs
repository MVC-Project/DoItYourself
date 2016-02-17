namespace DoItYourself.Services.Data.Contracts
{
    using System.Linq;

    using DoItYourself.Data.Models;

    public interface IUserService
    {
        IQueryable<User> AllUsers();

        IQueryable<User> AllUsersWithDeleted();

        User GetById(object id);

        void DeleteUser(User user);

        void HardDeleteUser(User user);

        void DeleteUserById(object id);

        void HardDeleteUserById(object id);
    }
}
