using Ecom.App.Data.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.Resources.DTOs
{
    public class ProductViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Category { get; set; }
        //public string Language { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public string Country { get; set; }
        
        public int CategoryId { get; set; }
        //public int LanguageId { get; set; }
        public int WriterId { get; set; }
        
        //public string Description { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string PublishedBy { get; set; }
        public string IPAddress { get; set; }
        public int PublisherId { get; set; }


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
        public int NotifyForMinimumQuantityBellow { get; set; }
        public bool IsNewProduct { get; set; }
        public bool IsPublished { get; set; }
        public bool IsAproved { get; set; }
        public bool IsReturnAble { get; set; }
        public bool IsShippingChargeApplicable { get; set; }
        public bool IsLimitedToStore { get; set; }
        public int ProductPublisherId { get; set; }
        public string Photo { get; set; }

    }
}
