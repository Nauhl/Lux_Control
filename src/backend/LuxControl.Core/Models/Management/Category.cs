using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxControl.Core.Models.Management
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field 'Category Type' is required")]
        [StringLength(60, ErrorMessage = "The field 'Category Type' must have max length of 60 characters")]
        public String CategoryType { get; set; }

        [Required(ErrorMessage = "The field 'Description' is required")]
        [StringLength(100, ErrorMessage = "The field 'Description' must have max length of 60 characters")]
        public String Description { get; set; }

        // Collections
        public ICollection<Item> Items { get; set; }
    }
}