using System;

namespace CorePoint.Service.ViewModel
{
    public class ViewModelIncidentStatus
    {
        public int vmId { get; set; }
        public int vmStatusID { get; set; }
        public string vmLateststatus { get; set; }
        public string vmServertiy { get; set; }
        public string vmCrewEmail { get; set; }
        public string vmSupervisorName { get; set; }
        public string vmIncidentType { get; set; }
        public DateTime vmIncidentDate { get; set; }
        public DateTime vmIncidentReportDate { get; set; }
    }
}