using forexapi.Context;
//using forexapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forexapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ForexDbContext _context;
        public RegistrationController(ForexDbContext context)
        {
            _context = context;
        }

        // GET: api/<RegistrationController>
        [HttpGet]
        public IEnumerable<Register> Get()
        {
            var registersList = (IEnumerable<Register>)_context.Registers.ToList();

            return registersList;
        }

        // GET: api/<RegistrationController>
        [HttpGet]
        public string GetUser(string userId,string password)
        {
            var userList = _context.Registers.Where(x=>x.UserName == userId && x.Password== password).FirstOrDefault();

            if (userList != null)
            {
                string json1 = JsonConvert.SerializeObject(new
                { role = userList.Userrole == "admin", loginSuccess = true });
                return json1;
            }
            return JsonConvert.SerializeObject(new { role = false, loginSuccess = false });
        }



        // POST api/<RegistrationController>
        [HttpPost]
        public string Post([FromBody] Register register)
        {
            if (register != null)
            {
                //registers.Status = "Sent";
                _context.Registers.Add(register);
                _context.SaveChanges();
            }
            return "Registered successfully";
        }
        // DELETE api/<RegistrationController>
        //[HttpDelete("{id}")]
        //public bool Delete(int id)
        //{
        //    //var currencyToDelete = _context.Currencies.Where(x => x.CurrencyId == id).FirstOrDefault();
        //    //var result = _context.Currencies.Remove(currencyToDelete);
        //    var result = _context.Registers.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
        //    if(result != null)
        //    {
        //        result.IsDeleted = true;
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //Delete api/<RegistrationController>
        [HttpDelete]
        public bool Delete(int id)
        {
            var result = _context.Registers.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _context.Registers.Remove(result);
                _context.SaveChanges();
                return true;
            }            
            return false;            
        }
    }
}
