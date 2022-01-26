using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePoint.DAL.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "String Length under 50")]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string AddressLine { get; set; }
        [Display(Name = "City")]
        public int CityId { get; set; }
        [Display(Name = "State")]
        public int StateId { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [Display(Name = "Zip Code")]
        [RegularExpression("^[1-9]{1}[0-9]{2}[0-9]{3}$", ErrorMessage = "Not valid ZipCode")]
        public int ZipCode { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}

