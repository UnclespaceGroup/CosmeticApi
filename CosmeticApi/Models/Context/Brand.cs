using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticApi.Models.Context
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public string Image { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
    }
}