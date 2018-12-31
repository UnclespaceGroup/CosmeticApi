using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticApi.Models.Context
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Data { get; set; }
        public bool Active { get; set; }
        
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public Review()
        {
            Comments = new List<Comment>();
        }
    }
}