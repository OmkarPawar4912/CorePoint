﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CorePoint.DAL.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
    }
}
