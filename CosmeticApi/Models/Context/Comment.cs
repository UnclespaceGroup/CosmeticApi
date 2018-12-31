using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticApi.Models.Context
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}