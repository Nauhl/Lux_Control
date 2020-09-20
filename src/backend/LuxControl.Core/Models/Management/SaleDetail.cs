using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxControl.Core.Models.Management
{
    public class SaleDetail
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "The field 'Total' is required")]
        public int Total { get; set; }

        // ForeingKey Sale
        public int SaleId { get; set; }
        public Sale Sale {get; set; }


    }
}