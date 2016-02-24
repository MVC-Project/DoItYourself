namespace DoItYourself.Web.ViewModels.Questions
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class QuestionCreateViewModel
    {
        [Required]
        [StringLength(100)]
        [MinLength(15)]
        [RegularExpression(@"([a-zA-Z])\w+", ErrorMessage = "There is an invalid characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        [MinLength(75)]
        [RegularExpression(@"([a-zA-Z])\w+", ErrorMessage = "There is an invalid characters")]
        public string Content { get; set; }

        public bool IsApproved { get; set; }

        public string UserId { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
