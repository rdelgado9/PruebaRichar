using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class loginRequest
    {
        public string usuario { get; set; }
        public string password { get; set; }
    }
}