namespace DoItYourself.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using DoItYourself.Common.Constants;

    public class Country : BaseModel<int>
    {
        [Required]
        [StringLength(DataModelConstants.CountryNameMaxLenght)]
        [MinLength(DataModelConstants.CountryNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DataModelConstants.CountryAbbreviationLength)]
        public string Abbreviation { get; set; }
    }
}
