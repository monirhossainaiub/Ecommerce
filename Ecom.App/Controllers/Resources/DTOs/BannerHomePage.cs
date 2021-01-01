using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.Resources.DTOs
{
    public class BannerHomePage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        public List<ProductBannerHomePage> Products { get; set; }
    }
}
