using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxControl.Core.Models.HybridApp
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field 'Name' is required")]
        [StringLength(60, ErrorMessage = "The field 'Name' must have max length of 60 characters")]
        public String Name { get; set; }

        [Required(ErrorMessage = "The field 'Email' is required")]
        [StringLength(60, ErrorMessage = "The field 'Email' must have max length of 60 characters")]
        
        public String Email { get; set; }

        [Required(ErrorMessage = "The field 'Password' is required")]
        [StringLength(60, ErrorMessage = "The field 'Password' must have max length of 60 characters")]
        public String Password { get; set; }

        


        // ForeignKey
        // public int DeviceId { get; set; }
        // public Device Device { get; set; }

    }
}