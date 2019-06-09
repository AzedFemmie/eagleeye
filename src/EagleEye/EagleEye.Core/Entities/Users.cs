using System;
using System.Collections.Generic;
using System.Text;

namespace EagleEye.Core.Entities
{
   public class Users
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string AuthType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
