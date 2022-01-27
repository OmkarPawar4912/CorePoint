using CorePoint.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePoint.DAL.Models
{
    public class Incident
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Employee")]
        public string EmailId { get; set; }
        [Display(Name = "Supervisor")]
        public string SupervisorUserName { get; set; }
        [Required]
        [Display(Name = "Shift")]
        public Shift Shift { get; set; }
        [Required]
        [Display(Name = "Incident Type")]
        public string IncidentType { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        [Display(Name = "Uploade File")]
        public string FilePath { get; set; }
        public Servertiy Severity { get; set; }
        [Required]
        [Display(Name = "Incident Date")]
        public DateTime IncidentDate { get; set; }
        public string CreateBy { get; set; }
        [Display(Name = "Reporting Date")]
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
