namespace DoItYourself.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Rating : BaseModel<int>
    {
        [Required]
        public int Value { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
