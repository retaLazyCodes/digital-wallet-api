using System;

namespace DigitalWalletApi.Domain
{
    public class Transaction
    {
        public int Id {get; set;}
        public string Description {get; set;}
        public decimal Price {get; set;}
        public Category Category { get; set; }
        public DateTime Date {get; set;}

    }
}