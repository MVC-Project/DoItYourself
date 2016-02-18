namespace DoItYourself.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using DoItYourself.Common.Constants;

    public class Project : BaseModel<int>
    {
        private ICollection<ProjectComment> projectComments;
        private ICollection<Video> videos;
        private ICollection<Rating> ratings;

        public Project()
        {
            this.projectComments = new HashSet<ProjectComment>();
            this.videos = new HashSet<Video>();
            this.ratings = new HashSet<Rating>();
        }

        [Required]
        [StringLength(DataModelConstants.ProjectTitleMaxLength)]
        [MinLength(DataModelConstants.ProjectTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DataModelConstants.ProjectContentMaxLength)]
        [MinLength(DataModelConstants.ProjectContentMinLength)]
        public string Content { get; set; }

        public bool IsApproved { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<ProjectComment> ProjectComments
        {
            get { return this.projectComments; }
            set { this.projectComments = value; }
        }

        public virtual ICollection<Video> Videos
        {
            get { return this.videos; }
            set { this.videos = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
