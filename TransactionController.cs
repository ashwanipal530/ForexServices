//using forexapi.Models;
using forexapi.Context;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace forexapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ForexDbContext _context;
        public TransactionController(ForexDbContext context)
        {
            _context = context;
        }

        // GET: api/<TransactionController>
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            var transactionList = (IEnumerable<Transaction>)_context.Transactions.ToList();

            return transactionList;
        }

        
        // POST api/<TransactionController>
        [HttpPost]
        public string Post([FromBody] Transaction transaction)
        {
            if (transaction != null)
            {
                transaction.Status = "Sent";
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
            }
            return "transactions successfully";
        }
        //DELETE api/<TransactionController>
        [HttpDelete]
        public bool Delete(int id)
        {
            var result = _context.Transactions.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _context.Transactions.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
