using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxControl.Core.Models.Management
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        // [Required(ErrorMessage = "The field 'Pay Method' is required")]
        public string PayMethod { get; set; }

        public string CardDigits { get; set; }

        public int SubTotal { get; set; }


        // ForeingKey Service
        [NotMapped]
        public int ServiceId { get; set; }
         [NotMapped]
        public Service Service { get; set; }

        // ForeignKey Item
        [NotMapped]
        public int ItemId { get; set; }
         [NotMapped]
        public Item Item { get; set; }

        // ForeignKey ClientSale
        public int ClientSaleId { get; set; }
        public ClientSale ClientSales { get; set; }
    }
}