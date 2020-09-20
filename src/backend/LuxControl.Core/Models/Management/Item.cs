using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxControl.Core.Models.Management
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field 'ItemName' is required")]
        [StringLength(60, ErrorMessage = "The field 'ItemName' must have max length of 60 characters")]
        public String ItemName { get; set; }

        [Required(ErrorMessage = "The field 'Price' is required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "The field 'Quantity' is required")]
        public int Quantity { get; set; }

        // [Required(ErrorMessage = "The field 'Status' is required")]
        // public Boolean Status { get; set; }

        // ForeignKey
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}