using System.ComponentModel.DataAnnotations;

namespace CorePoint.DAL.Enums
{
    public enum IncidentType
    {
        [Display(Name = "Near Miss")]
        NearMiss = 1,
        Spill,
        Injury,
        Other
    }
}