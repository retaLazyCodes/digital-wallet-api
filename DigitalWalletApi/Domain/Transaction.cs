using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWalletApi.Domain
{
    public class Transaction
    {
        public int Id {get; set;}
        
        [Required, StringLength(80)]
        public string Description {get; set;}
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price {get; set;}
        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public DateTime Date {get; set;}

        public bool IsIncome { get; set; }

    }
}