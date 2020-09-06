﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Models
{
    [Table("ProductPublishers")]
    public class ProductPublisher
    {
        public int ProductId { get; set; }
        public int PublisherId { get; set; }

        public Product Product { get; set; }
        public Publisher Publisher { get; set; }


        [Required]
        [MaxLength(15)]
        public string SKU { get; set; }

        [Required]
        [MaxLength(150)]
        public string ISBN { get; set; }

        public int countryId { get; set; }

        public double NumberOfPage { get; set; }

        public string Edition { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }

        [Required]
        [Display(Name = "Selling Price")]
        public double Price { get; set; }

        [Display(Name = "Old Price")]
        public double OldPrice { get; set; }

        [Display(Name = "Cost Price")]
        public double CostPrice { get; set; }

        [Display(Name = "Order Min Qnt")]
        public int OrderMinimumQuantity { get; set; }

        [Display(Name = "Order Max Qnt")]
        public int OrderMaximumQuantity { get; set; }

        [Display(Name = "Notify Bellow Qnt")]
        public int NotifyForMinimumQuantityBellow { get; set; }


        public bool IsNewProduct { get; set; }
        public bool IsPublished { get; set; }
        public bool IsAproved { get; set; }
        public bool IsReturnAble { get; set; }
        public bool IsShippingChargeApplicable { get; set; }
        public bool IsLimitedToStore { get; set; }

    }
}