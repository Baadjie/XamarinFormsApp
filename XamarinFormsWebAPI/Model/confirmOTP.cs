using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{
    public class confirmOTP
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string NewEmail { get; set; }
        public string OTP { get; set; }
    }
}