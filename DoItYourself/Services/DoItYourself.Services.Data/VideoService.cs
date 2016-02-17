namespace DoItYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class VideoService : IVideoService
    {
        private readonly IDbRepository<Video> videos;

        public VideoService(IDbRepository<Video> videos)
        {
            this.videos = videos;
        }

        public IQueryable<Video> AllVideos()
        {
            return this.videos.All();
        }

        public IQueryable<Video> AllVideosWithDeleted()
        {
            return this.videos.AllWithDeleted();
        }

        public Video GetById(int id)
        {
            return this.videos.GetById(id);
        }

        public void DeleteVideo(Video video)
        {
            this.videos.Delete(video);
            this.videos.Save();
        }

        public void HardDeleteVideo(Video video)
        {
            this.videos.HardDelete(video);
            this.videos.Save();
        }

        public void DeleteVideoById(int id)
        {
            var video = this.videos.GetById(id);
            this.videos.Delete(video);
            this.videos.Save();
        }

        public void HardDeleteVideoById(int id)
        {
            var video = this.videos.GetById(id);
            this.videos.HardDelete(video);
            this.videos.Save();
        }

        public void AddVideo(Video video)
        {
            this.videos.Add(video);
            this.videos.Save();
        }
    }
}
