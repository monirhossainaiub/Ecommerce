using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.Resources.DTOs
{
    public class ProductClientView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public string Image { get; set; }
        public string Writer { get; set; }
        public int WriterId { get; set; }
        public string Publisher { get; set; }
        public int PublisherId { get; set; }

        public string Category { get; set; }
        public int CategoryId { get; set; }
    }
}
