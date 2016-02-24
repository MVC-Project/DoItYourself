namespace DoItYourself.Web.ViewModels.Projects
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class ProjectCreateViewModel
    {
        [Required]
        [StringLength(150)]
        [MinLength(15)]
        [RegularExpression(@"([a-zA-Z])\w+", ErrorMessage = "There is an invalid characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(3500)]
        [MinLength(750)]
        [RegularExpression(@"([a-zA-Z])\w+", ErrorMessage = "There is an invalid characters")]
        public string Content { get; set; }

        public bool IsApproved { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Image")]
        public HttpPostedFileBase Image { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
