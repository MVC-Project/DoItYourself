namespace DoItYourself.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using Contracts;
    using DoItYourself.Common.Constants;

    public class ProjectComment : BaseModel<int>, IComment
    {
        [Required]
        [StringLength(DataModelConstants.ProjectCommentContentMaxLength)]
        [MinLength(DataModelConstants.ProjectCommentContentMinLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
