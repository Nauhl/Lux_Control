using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxControl.Core.Models.Management
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field 'Service Name' is required")]
        [StringLength(60, ErrorMessage = "The field 'Service Name' must have max length of 60 characters")]
        public String ServiceName { get; set; }

        [Required(ErrorMessage = "The field 'Price' is required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "The field 'Description' is required")]
        [StringLength(100, ErrorMessage = "The field 'Description' must have max length of 60 characters")]
        public String Description { get; set; }


        // Collections
        public ICollection<Sale> Sales { get; set; }
    }
}