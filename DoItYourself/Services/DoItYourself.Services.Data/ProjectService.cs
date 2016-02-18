namespace DoItYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class ProjectService : IProjectService
    {
        private readonly IDbRepository<Project> projects;

        public ProjectService(IDbRepository<Project> projects)
        {
            this.projects = projects;
        }

        public IQueryable<Project> AllProjects()
        {
            return this.projects.All();
        }

        public IQueryable<Project> AllProjectsWithDeleted()
        {
            return this.projects.AllWithDeleted();
        }

        public IQueryable<Project> AllApprovedProjects()
        {
            return this.projects.All()
                .Where(project => project.IsApproved == true);
        }

        public IQueryable<Project> AllUnapprovedProjects()
        {
            return this.projects.All()
                .Where(project => project.IsApproved == false);
        }

        public Project GetById(int id)
        {
            return this.projects.GetById(id);
        }

        public IQueryable<Project> AllProjectsByUser(User user)
        {
            var userId = user.Id;
            return this.projects.All()
                .Where(project => project.UserId == userId);
        }

        public IQueryable<Project> AllProjectsByUserId(string userId)
        {
            return this.projects.All()
                .Where(project => project.UserId == userId);
        }

        public IQueryable<Project> AllProjectsByCategory(Category category)
        {
            var categoryId = category.Id;
            return this.projects.All()
                .Where(project => project.CategoryId == categoryId);
        }

        public IQueryable<Project> AllProjectsByCategoryId(int categoryId)
        {
            return this.projects.All()
                .Where(project => project.CategoryId == categoryId);
        }

        public IQueryable<Project> AllProjectsByCategoryName(string categoryName)
        {
            return this.projects.All()
                .Where(project => project.Category.Name == categoryName);
        }

        public IQueryable<Project> TopNewestProjects(int take = 3)
        {
            return this.projects.All()
                .OrderByDescending(project => project.CreatedOn)
                .Take(take);
        }

        public IQueryable<Project> TopCommentedProjects(int take = 6)
        {
            return this.projects.All()
                .OrderByDescending(project => project.ProjectComments.Count())
                .Take(take);
        }

        public IQueryable<Project> TopRatedProjects(int take = 6)
        {
            return this.projects.All()
                .OrderByDescending(project => project.Ratings.Average(pr => pr.Value));
        }

        public int NumberOfVideosForProject(Project project)
        {
            var projectId = project.Id;
            return this.projects.All()
                .Where(pr => pr.Id == projectId)
                .FirstOrDefault()
                .Videos
                .Count();
        }

        public int NumberOfVideosForProjectId(int projectId)
        {
            return this.projects.All()
                .Where(pr => pr.Id == projectId)
                .FirstOrDefault()
                .Videos
                .Count();
        }

        public void ApproveProject(int projectId)
        {
            var project = this.projects.All()
                .Where(pr => pr.IsApproved == false && pr.Id == projectId)
                .FirstOrDefault();

            project.IsApproved = true;
            this.projects.Update(project);
            this.projects.Save();
        }

        public void DeleteProject(Project project)
        {
            this.projects.Delete(project);
            this.projects.Save();
        }

        public void HardDeleteProject(Project project)
        {
            this.projects.HardDelete(project);
            this.projects.Save();
        }

        public void DeleteProjectById(int id)
        {
            var project = this.projects.GetById(id);
            this.projects.Delete(project);
            this.projects.Save();
        }

        public void HardDeleteProjectById(int id)
        {
            var project = this.projects.GetById(id);
            this.projects.HardDelete(project);
            this.projects.Save();
        }

        public void AddProject(Project project)
        {
            this.projects.Add(project);
            this.projects.Save();
        }
    }
}
