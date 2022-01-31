using CorePoint.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CorePoint.Service.ViewModel
{
    public class ViewModelIncidentStatus
    {
        [Display(Name = "Id")]
        public int vmId { get; set; }
        [Display(Name = "Incident ID")]
        public int vmIncidentId { get; set; }
        [Display(Name = "Status")]
        public int vmStatusID { get; set; }
        [Display(Name = "Status")]
        public string vmLateststatus { get; set; }
        [Display(Name = "Sevearity")]
        public string vmServertiy { get; set; }
        [Display(Name = "Employee")]
        public string vmCrew { get; set; }
        public string Remark { get; set; }
        [Display(Name = "Supervisor Name")]
        public string vmSupervisorName { get; set; }
        [Display(Name = "Employee Name")]
        public string vmFile { get; set; }
        public string vmEmployeeName { get; set; }
        [Display(Name = "Type")]
        public string vmIncidentType { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Incident Date")]
        public DateTime vmIncidentDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime vwStatusDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Report Date")]
        public DateTime vmIncidentReportDate { get; set; }
        public virtual StatusType viewStatus { get; set; }
        [Display(Name = "Description")]
        public string viewIncidentDes { get; set; }
        [Display(Name = "Area")]
        public string vmArea { get; set; }
    }
}