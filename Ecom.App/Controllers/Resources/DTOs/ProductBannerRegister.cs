using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.Resources.DTOs
{
    public class ProductBannerRegister
    {
        public int BannerId { get; set; }
        public List<int> ProductIds { get; set; }

    }
}
