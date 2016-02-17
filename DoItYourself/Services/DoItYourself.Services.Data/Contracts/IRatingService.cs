namespace DoItYourself.Services.Data.Contracts
{
    using System.Linq;

    using DoItYourself.Data.Models;

    public interface IRatingService
    {
        IQueryable<Rating> AllRatings();

        IQueryable<Rating> AllRatingWithDeleted();

        Rating GetById(int id);

        void DeleteRating(Rating rating);

        void HardDeleteRating(Rating rating);

        void DeleteRatingById(int id);

        void HardDeleteRatingById(int id);

        void AddRating(Rating rating);

        IQueryable<Rating> AllRatingsByUserId(string userId);

        IQueryable<Rating> AllRatingsByUser(User user);

        IQueryable<Rating> AllRatingsByProjectId(int projectId);

        IQueryable<Rating> AllRatingsByProject(Project project);
    }
}
