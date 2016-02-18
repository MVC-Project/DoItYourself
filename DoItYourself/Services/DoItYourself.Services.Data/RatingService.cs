namespace DoItYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class RatingService : IRatingService
    {
        private readonly IDbRepository<Rating> ratings;

        public RatingService(IDbRepository<Rating> ratings)
        {
            this.ratings = ratings;
        }

        public IQueryable<Rating> AllRatings()
        {
            return this.ratings.All();
        }

        public IQueryable<Rating> AllRatingWithDeleted()
        {
            return this.ratings.AllWithDeleted();
        }

        public Rating GetById(int id)
        {
            return this.ratings.GetById(id);
        }

        public void DeleteRating(Rating rating)
        {
            this.ratings.Delete(rating);
            this.ratings.Save();
        }

        public void HardDeleteRating(Rating rating)
        {
            this.ratings.HardDelete(rating);
            this.ratings.Save();
        }

        public void DeleteRatingById(int id)
        {
            var rating = this.ratings.GetById(id);
            this.ratings.Delete(rating);
            this.ratings.Save();
        }

        public void HardDeleteRatingById(int id)
        {
            var rating = this.ratings.GetById(id);
            this.ratings.HardDelete(rating);
            this.ratings.Save();
        }

        public void AddRating(Rating rating)
        {
            this.ratings.Add(rating);
            this.ratings.Save();
        }

        public IQueryable<Rating> AllRatingsByUserId(string userId)
        {
            return this.ratings.All().Where(rating => rating.UserId == userId);
        }

        public IQueryable<Rating> AllRatingsByUser(User user)
        {
            var userId = user.Id;
            return this.ratings.All().Where(rating => rating.UserId == userId);
        }

        public IQueryable<Rating> AllRatingsByProjectId(int projectId)
        {
            return this.ratings.All().Where(rating => rating.ProjectId == projectId);
        }

        public IQueryable<Rating> AllRatingsByProject(Project project)
        {
            var projectId = project.Id;
            return this.ratings.All().Where(rating => rating.ProjectId == projectId);
        }
    }
}
