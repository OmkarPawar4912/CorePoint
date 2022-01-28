using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePoint.DAL.Models
{
    public class IncidentStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("StatusType")]
        public int StatusID { get; set; }
        public StatusType StatusType { get; set; }
        [ForeignKey("Incident")]
        public int IncidentID { get; set; }
        public Incident Incident { get; set; }
        public string Remark { get; set; }
        public string CreateBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

    }
}
