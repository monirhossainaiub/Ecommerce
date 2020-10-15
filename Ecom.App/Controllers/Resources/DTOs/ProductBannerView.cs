using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.Resources.DTOs
{
    public class ProductBannerView
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Publisher { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int BannerId { get; set; }
        public bool IsRegisterToBanner { get; set; }
    }
}
