using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalWalletApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWalletApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var transactions = _transactionService.GetAll();
            return Ok(transactions);
        }
    }
}