using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NandosoAPI.Models
{
    public class Admin
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public Admin() { }
        public Admin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}