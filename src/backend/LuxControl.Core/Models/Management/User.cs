using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxControl.Core.Models.Management
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field 'Username' is required")]
        [StringLength(60, ErrorMessage = "The field 'Username' must have max length of 60 characters")]
        public String Username { get; set; }

        [Required(ErrorMessage = "The field 'Password' is required")]
        [StringLength(60, ErrorMessage = "The field 'Password' must have max length of 60 characters")]
        public String Password { get; set; }

        // ForeignKey
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}