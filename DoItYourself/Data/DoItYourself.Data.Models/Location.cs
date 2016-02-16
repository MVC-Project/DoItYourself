namespace DoItYourself.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using DoItYourself.Common;

    public class Location : BaseModel<int>
    {
        [Required]
        [StringLength(DataModelConstants.CityNameMaxLength)]
        [MinLength(DataModelConstants.CityNameMinLength)]
        public string City { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
