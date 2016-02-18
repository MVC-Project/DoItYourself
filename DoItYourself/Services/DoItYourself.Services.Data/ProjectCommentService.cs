namespace DoItYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class ProjectCommentService : IProjectCommentService
    {
        private readonly IDbRepository<ProjectComment> projectComments;

        public ProjectCommentService(IDbRepository<ProjectComment> projectComments)
        {
            this.projectComments = projectComments;
        }

        public IQueryable<ProjectComment> AllProjectComments()
        {
            return this.projectComments.All();
        }

        public IQueryable<ProjectComment> AllProjectCommentsWithDeleted()
        {
            return this.projectComments.AllWithDeleted();
        }

        public ProjectComment GetById(int id)
        {
            return this.projectComments.GetById(id);
        }

        public IQueryable<ProjectComment> AllProjectCommentsByUser(User user)
        {
            var userId = user.Id;
            return this.projectComments.All()
                .Where(projectComment => projectComment.UserId == userId);
        }

        public IQueryable<ProjectComment> AllProjectCommentsByUserId(string userId)
        {
            return this.projectComments.All()
                .Where(projectComment => projectComment.UserId == userId);
        }

        public IQueryable<ProjectComment> AllProjectCommentsForProject(Project project)
        {
            var projectId = project.Id;
            return this.projectComments.All()
                .Where(projectComment => projectComment.ProjectId == projectId);
        }

        public IQueryable<ProjectComment> AllProjectCommentsForProjectId(int projectId)
        {
            return this.projectComments.All()
                .Where(projectComment => projectComment.ProjectId == projectId);
        }

        public IQueryable<ProjectComment> TopNewestProjectComments(int take = 5)
        {
            return this.projectComments.All()
                .OrderByDescending(projectComment => projectComment.CreatedOn)
                .Take(take);
        }

        public void DeleteProjectComment(ProjectComment projectComment)
        {
            this.projectComments.Delete(projectComment);
            this.projectComments.Save();
        }

        public void HardDeleteProjectComment(ProjectComment projectComment)
        {
            this.projectComments.HardDelete(projectComment);
            this.projectComments.Save();
        }

        public void DeleteProjectCommentById(int id)
        {
            var projectComment = this.projectComments.GetById(id);
            this.projectComments.Delete(projectComment);
            this.projectComments.Save();
        }

        public void HardDeleteProjectCommentById(int id)
        {
            var projectComment = this.projectComments.GetById(id);
            this.projectComments.HardDelete(projectComment);
            this.projectComments.Save();
        }

        public void AddProjectComment(ProjectComment projectComment)
        {
            this.projectComments.Add(projectComment);
            this.projectComments.Save();
        }

        public void UpdateProjectCommentContent(int projectCommentId, string updatedContent)
        {
            var projectComment = this.projectComments.All()
                .Where(prComment => prComment.Id == projectCommentId)
                .FirstOrDefault();

            projectComment.Content = updatedContent;
            this.projectComments.Update(projectComment);
            this.projectComments.Save();
        }
    }
}
