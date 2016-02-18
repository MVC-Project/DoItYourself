namespace DoItYourself.Services.Data.Contracts
{
    using System.Linq;

    using DoItYourself.Data.Models;

    public interface IProjectService
    {
        IQueryable<Project> AllProjects();

        IQueryable<Project> AllProjectsWithDeleted();

        IQueryable<Project> AllApprovedProjects();

        IQueryable<Project> AllUnapprovedProjects();

        Project GetById(int id);

        IQueryable<Project> AllProjectsByUser(User user);

        IQueryable<Project> AllProjectsByUserId(string userId);

        IQueryable<Project> AllProjectsByCategory(Category category);

        IQueryable<Project> AllProjectsByCategoryId(int categoryId);

        IQueryable<Project> AllProjectsByCategoryName(string categoryName);

        IQueryable<Project> TopNewestProjects(int take = 3);

        IQueryable<Project> TopCommentedProjects(int take = 6);

        IQueryable<Project> TopRatedProjects(int take = 6);

        int NumberOfVideosForProject(Project project);

        int NumberOfVideosForProjectId(int projectId);

        void ApproveProject(int projectId);

        void DeleteProject(Project project);

        void HardDeleteProject(Project project);

        void DeleteProjectById(int id);

        void HardDeleteProjectById(int id);

        void AddProject(Project project);
    }
}
