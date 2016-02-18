namespace DoItYourself.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Common.Models;
    using DoItYourself.Common.Constants;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<ProjectComment> projectComments;
        private ICollection<QuestionComment> questionComments;
        private ICollection<Question> questions;
        private ICollection<Project> projects;

        public User()
        {
            this.projectComments = new HashSet<ProjectComment>();
            this.questionComments = new HashSet<QuestionComment>();
            this.questions = new HashSet<Question>();
            this.projects = new HashSet<Project>();
            this.CreatedOn = DateTime.Now;
        }

        [Required]
        [StringLength(DataModelConstants.UserFirstNameMaxLength)]
        [MinLength(DataModelConstants.UserFirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(DataModelConstants.UserLastNameMaxLength)]
        [MinLength(DataModelConstants.UserLastNameMinLength)]
        public string LastName { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<ProjectComment> ProjectComments
        {
            get { return this.projectComments; }
            set { this.projectComments = value; }
        }

        public virtual ICollection<QuestionComment> QuestionComments
        {
            get { return this.questionComments; }
            set { this.questionComments = value; }
        }

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}
