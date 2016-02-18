namespace DoItYourself.Services.Data.Contracts
{
    using System.Linq;

    using DoItYourself.Data.Models;

    public interface IProjectCommentService
    {
        IQueryable<ProjectComment> AllProjectComments();

        IQueryable<ProjectComment> AllProjectCommentsWithDeleted();

        ProjectComment GetById(int id);

        IQueryable<ProjectComment> AllProjectCommentsByUser(User user);

        IQueryable<ProjectComment> AllProjectCommentsByUserId(string userId);

        IQueryable<ProjectComment> AllProjectCommentsForProject(Project project);

        IQueryable<ProjectComment> AllProjectCommentsForProjectId(int projectId);

        IQueryable<ProjectComment> TopNewestProjectComments(int take = 5);

        void DeleteProjectComment(ProjectComment projectComment);

        void HardDeleteProjectComment(ProjectComment projectComment);

        void DeleteProjectCommentById(int id);

        void HardDeleteProjectCommentById(int id);

        void AddProjectComment(ProjectComment projectComment);

        void UpdateProjectCommentContent(int projectCommentId, string updatedContent);
    }
}
