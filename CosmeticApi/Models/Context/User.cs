using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticApi.Models.Context
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}