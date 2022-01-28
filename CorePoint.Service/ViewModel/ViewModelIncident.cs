using CorePoint.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CorePoint.Service.ViewModel
{
    public class ViewModelIncident
    {
        public int Id { get; set; }
        [Required]
        public int SupervisorId { get; set; }
        [Required]
        public int CrewId { get; set; }
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
        public Boolean IsConfidence { get; set; } = false;
        [Required]
        [Display(Name = "Incident Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime IncidentDate { get; set; }
        public string CreateBy { get; set; }
        [Display(Name = "Reporting Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        public string UpdateBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }
    }
}