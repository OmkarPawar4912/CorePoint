using System.ComponentModel.DataAnnotations;

namespace CorePoint.Service.ViewModel
{
    public class ViewModelCity
    {
        public int Id { get; set; }
        [Display(Name = "City")]
        public string Name { get; set; }
        public int StateId { get; set; }
        [Display(Name = "State")]
        public string StateName { get; set; }
        [Display(Name = "Country")]
        public string CountryName { get; set; }

    }
}
