using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.Resources.DTOs
{
    public class ProductBannerHomePage
    {
        public int ProductPublisherId { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
        public string ProductTitle { get; set; }
        public int StockQuantity { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }

        public int PublisherId { get; set; }
        public string Publisher { get; set; }

        public int WriterId { get; set; }
        public string Writer { get; set; }
    }
}
