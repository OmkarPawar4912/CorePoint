using CorePoint.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePoint.DAL.Models
{
    public class Incident
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SupervisorId { get; set; }
        public int CrewId { get; set; }
        public string IncidentType { get; set; }
        public string Area { get; set; }
        public string FilePath { get; set; }
        public Servertiy Severity { get; set; }
        public Boolean IsConfidence { get; set; } = false;
        public DateTime IncidentDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
