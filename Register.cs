using System;
using System.Collections.Generic;

#nullable disable

namespace forexapi.Context
{
    public partial class Register
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Userrole { get; set; }
        public string Password { get; set; }
    }
}
