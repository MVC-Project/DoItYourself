namespace DoItYourself.Services.Data.Contracts
{
    using System.Linq;

    using DoItYourself.Data.Models;

    public interface ICategoryService
    {
        IQueryable<Category> AllCategories();

        IQueryable<Category> AllCategoriesWithDeleted();

        Category GetById(int id);

        void DeleteCategory(Category category);

        void HardDeleteCategory(Category category);

        void DeleteCategoryById(int id);

        void HardDeleteCategoryById(int id);

        void AddCategory(Category category);
    }
}
