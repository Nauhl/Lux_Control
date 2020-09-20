using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxControl.Core.Models.HybridApp
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field 'Device Name' is required")]
        [StringLength(60, ErrorMessage = "The field 'Device Name' must have max length of 60 characters")]
        public String DeviceName { get; set; }

        // Colections
        // public ICollection<Client> Clients { get;set; }

    }
}