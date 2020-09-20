using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxControl.Core.Models.Management
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field 'Role Type' is required")]
        [StringLength(60, ErrorMessage = "The field 'Role Type' must have max length of 60 characters")]
        public String RoleType { get; set; }

        // Collections
        public ICollection<User> Users { get; set; }
    }
}