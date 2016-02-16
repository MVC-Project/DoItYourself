namespace DoItYourself.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using DoItYourself.Common;

    public class Question : BaseModel<int>
    {
        private ICollection<QuestionComment> comments;

        public Question()
        {
            this.comments = new HashSet<QuestionComment>();
        }

        [Required]
        [StringLength(DataModelConstants.QuestionTitleMaxLength)]
        [MinLength(DataModelConstants.QuestionTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DataModelConstants.QuestionContentMaxLength)]
        [MinLength(DataModelConstants.QuestionContentMinLength)]
        public string Content { get; set; }

        public bool IsApproved { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<QuestionComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
