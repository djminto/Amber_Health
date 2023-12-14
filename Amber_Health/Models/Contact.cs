﻿using System.ComponentModel.DataAnnotations;

namespace Amber_HealthAPI.Models
{
    public class Contact
    {
       
        public int Id { get; set; }
        [Required]
        public string EmergencyContactor { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
