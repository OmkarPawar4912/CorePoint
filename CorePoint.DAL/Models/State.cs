using System.ComponentModel.DataAnnotations;

namespace CorePoint.DAL.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
    }
}

