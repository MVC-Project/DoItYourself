namespace DoItYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class CategoryService : ICategoryService
    {
        private readonly IDbRepository<Category> categories;

        public CategoryService(IDbRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> AllCategories()
        {
            return this.categories.All();
        }

        public IQueryable<Category> AllCategoriesWithDeleted()
        {
            return this.categories.AllWithDeleted();
        }

        public Category GetById(int id)
        {
            return this.categories.GetById(id);
        }

        public void DeleteCategory(Category category)
        {
            this.categories.Delete(category);
            this.categories.Save();
        }

        public void HardDeleteCategory(Category category)
        {
            this.categories.HardDelete(category);
            this.categories.Save();
        }

        public void DeleteCategoryById(int id)
        {
            var category = this.categories.GetById(id);
            this.categories.Delete(category);
            this.categories.Save();
        }

        public void HardDeleteCategoryById(int id)
        {
            var category = this.categories.GetById(id);
            this.categories.HardDelete(category);
            this.categories.Save();
        }

        public void AddCategory(Category category)
        {
            this.categories.Add(category);
            this.categories.Save();
        }
    }
}
