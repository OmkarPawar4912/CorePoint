using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CorePoint.DAL.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        [MaxLength(6)]
        public int ZipCode { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}

