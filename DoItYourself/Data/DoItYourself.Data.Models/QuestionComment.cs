namespace DoItYourself.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using Contracts;
    using DoItYourself.Common;

    public class QuestionComment : BaseModel<int>, IComment
    {
        [Required]
        [StringLength(DataModelConstants.QuestionCommentContentMaxLength)]
        [MinLength(DataModelConstants.QuestionCommentContentMinLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
