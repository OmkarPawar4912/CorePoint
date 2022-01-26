using CorePoint.DAL.Enums;
using CorePoint.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CorePoint.Service.ViewModel
{
    public class ViewModelEmployee
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter your Emergency Phone Number")]
        [Display(Name = "Emergency Phone Number")]
        public string EmergencyPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password does not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public int Gender { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Birth of Date")]
        public DateTime DOB { get; set; }
        public Address Address { get; set; }
        [Display(Name = "Country")]
        public string CountryName { get; set; }
        [Display(Name = "State")]
        public string StateName { get; set; }
        [Display(Name = "City")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Select Blood Type")]
        [Display(Name = "Blood Type")]
        public Blood Blood { get; set; }
        [Display(Name = "Crew")]
        public int CrewId { get; set; }
        public string CrewName { get; set; }
        [Display(Name = "Is Supervisior")]
        public bool IsSupervisior { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        [Display(Name = "Is Active")]
        public Boolean IsActive { get; set; } = false;
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
