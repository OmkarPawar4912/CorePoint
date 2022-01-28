using System;
using System.ComponentModel.DataAnnotations;

namespace CorePoint.Service.ViewModel
{
    public class ViewModelCrews
    {
        public int ID { get; set; }
        [Display(Name = "Crews")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Sitecode { get; set; }
        public string CreateBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
