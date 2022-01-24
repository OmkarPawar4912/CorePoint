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
        public string FullName { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public int Gender { get; set; }
        public DateTime DOB { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [MaxLength(6)]
        public int Pincode { get; set; }
        public Blood Blood { get; set; }
        [ForeignKey("Crew")]
        public int CrewId { get; set; }
        public Crew Crew { get; set; }
        public DateTime HireDate { get; set; }
        public Boolean IsActive { get; set; } = false;
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
