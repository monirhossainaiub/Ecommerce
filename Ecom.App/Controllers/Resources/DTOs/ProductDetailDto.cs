using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.Resources.DTOs
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Photos { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int WriterId { get; set; }
        public string Writer { get; set; }
        public int PublisherId { get; set; }
        public string Publisher { get; set; }
        public string Country { get; set; }
        public int LanguageId { get; set; }
       
        public string Description { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }

        public string Sku { get; set; }
        public string Isbn { get; set; }
        public double NumberOfPage { get; set; }
        public string Edition { get; set; }
        public int StockQuantity { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public double CostPrice { get; set; }
        public int OrderMinimumQuantity { get; set; }
        public int OrderMaximumQuantity { get; set; }
        public bool IsNewProduct { get; set; }
        public bool IsPublished { get; set; }
        public bool IsAproved { get; set; }
        public bool IsReturnAble { get; set; }
        public bool IsShippingChargeApplicable { get; set; }
        public bool IsLimitedToStore { get; set; }
        public int ProductPublisherId { get; set; }
    }
}
