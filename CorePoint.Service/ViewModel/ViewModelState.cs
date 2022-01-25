using CorePoint.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CorePoint.Service.ViewModel
{
    public class ViewModelState
    {
        public int Id { get; set; }
        [Display(Name = "State")]
        public string Name { get; set; }
        public int CountryId { get; set; }
        [Display(Name= "Country")]
        public string CountryName { get; set; }
    }
}
