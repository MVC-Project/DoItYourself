namespace DoItYourself.Services.Data.Contracts
{
    using System.Linq;

    using DoItYourself.Data.Models;

    public interface IImageService
    {
        IQueryable<Image> AllImages();

        IQueryable<Image> AllImagesWithDeleted();

        Image GetById(int id);

        void DeleteImage(Image image);

        void HardDeleteImage(Image image);

        void DeleteImageById(int id);

        void HardDeleteImageById(int id);

        void AddImage(Image image);
    }
}
