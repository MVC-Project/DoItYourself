namespace DoItYourself.Services.Data.Contracts
{
    using System.Linq;

    using DoItYourself.Data.Models;

    public interface IVideoService
    {
        IQueryable<Video> AllVideos();

        IQueryable<Video> AllVideosWithDeleted();

        Video GetById(int id);

        void DeleteVideo(Video video);

        void HardDeleteVideo(Video video);

        void DeleteVideoById(int id);

        void HardDeleteVideoById(int id);

        void AddVideo(Video video);
    }
}
