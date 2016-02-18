namespace DoItYourself.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using DoItYourself.Common.Constants;

    public class Category : BaseModel<int>
    {
        [Required]
        [StringLength(DataModelConstants.CategoryNameMaxLength)]
        [MinLength(DataModelConstants.CategoryNameMinLength)]
        public string Name { get; set; }
    }
}
