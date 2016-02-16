namespace DoItYourself.Services.Data
{
    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class UserService : IUserService
    {
        private readonly IDbRepository<User> users;
    }
}
