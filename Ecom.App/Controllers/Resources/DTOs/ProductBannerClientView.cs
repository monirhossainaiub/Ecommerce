using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.Resources.DTOs
{
    public class ProductBannerClientView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int BannerId { get; set; }
        public int ProductPublisherId { get; set; }
        public string BannerTitle { get; set; }
        public string Writer { get; set; }
        public int WriterId { get; set; }
        public string Publisher { get; set; }
        public int PublisherId { get; set; }
    }
}
