using System.ComponentModel.DataAnnotations;

namespace CorePoint.Service.ViewModel
{
    public class ViewModelState
    {
        public int Id { get; set; }
        [Display(Name = "State")]
        public string Name { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [Display(Name = "Country")]
        public string CountryName { get; set; }
    }
}
