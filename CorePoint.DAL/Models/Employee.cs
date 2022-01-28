using CorePoint.DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePoint.DAL.Models
{
    public class Employee : IdentityUser
    {
        [StringLength(30)]
        [RegularExpression("^[A-Z][a-z]*(\\s[A-Z][a-z]*)+$", ErrorMessage = "Each part of a name must start from capital letter and at least 2 parts separate")]
        public string FullName { get; set; }
        [RegularExpression("^([7-9]{1})([0-9]{9})$", ErrorMessage = "Start with 7-9 and Only 10 digit no")]
        public string EmergencyPhoneNumber { get; set; }
        public int Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
        [Required(ErrorMessage = "Select Blood Type")]
        public Blood Blood { get; set; }
        [ForeignKey("Crew")]
        public int CrewId { get; set; }
        [ForeignKey("CrewId")]
        public Crew Crew { get; set; }
        public bool IsSupervisior { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
        public Boolean IsActive { get; set; } = false;
        public string CreateBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }
    }
}
