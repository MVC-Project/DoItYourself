namespace DoItYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class ImageService : IImageService
    {
        private readonly IDbRepository<Image> images;

        public ImageService(IDbRepository<Image> images)
        {
            this.images = images;
        }

        public IQueryable<Image> AllImages()
        {
            return this.images.All();
        }

        public IQueryable<Image> AllImagesWithDeleted()
        {
            return this.images.AllWithDeleted();
        }

        public Image GetById(int id)
        {
            return this.images.GetById(id);
        }

        public void DeleteImage(Image image)
        {
            this.images.Delete(image);
            this.images.Save();
        }

        public void HardDeleteImage(Image image)
        {
            this.images.HardDelete(image);
            this.images.Save();
        }

        public void DeleteImageById(int id)
        {
            var image = this.images.GetById(id);
            this.images.Delete(image);
            this.images.Save();
        }

        public void HardDeleteImageById(int id)
        {
            var image = this.images.GetById(id);
            this.images.HardDelete(image);
            this.images.Save();
        }

        public void AddImage(Image image)
        {
            this.images.Add(image);
            this.images.Save();
        }
    }
}
