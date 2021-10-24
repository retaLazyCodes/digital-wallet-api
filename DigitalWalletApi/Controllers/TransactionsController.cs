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
        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var transaction = _transactionService.FindById(id);
            return Ok(transaction);
        }
        
        [HttpGet("{name}")]
        public IActionResult  GetByName(string name)
        {
            name = name.ToLower();
            return Ok(_transactionService.FindByName(name));
        }
        
        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            var result = _transactionService.Add(transaction);
            if (result) {
                return Ok(transaction);
            }
            else {
                return BadRequest();
            }
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _transactionService.Delete(id);
            if (result) {
                return Ok(new { Message = "Deleted Successful"});
            }
            else {
                return BadRequest(new { Message = "The transaction with that id does not exist "});
            }
        }
    }
}