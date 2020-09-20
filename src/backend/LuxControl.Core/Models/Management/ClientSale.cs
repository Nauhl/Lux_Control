using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxControl.Core.Models.Management
{
    public class ClientSale
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field 'Name' is required")]
        [StringLength(60, ErrorMessage = "The field 'Name' must have max length of 60 characters")]
        public String Name { get; set; }

        [Required(ErrorMessage = "The field 'Email' is required")]
        [StringLength(60, ErrorMessage = "The field 'Email' must have max length of 60 characters")]
        
        public String Email { get; set; }

       
        // Collections
        public ICollection<Sale> Sales { get; set; }
    }
}