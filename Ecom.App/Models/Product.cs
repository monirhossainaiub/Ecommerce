using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Models
{
    [Table("Products")]
    public class Product
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string SKU { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "Product")]
        public string Name { get; set; }

        public string Title { get; set; }

        [Required]
        public string ISBN { get; set; }
        public double NumberOfPage { get; set; }
        public string Edition { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }

        public string Description { get; set; }

       

        //[Display(Name = "Display Order")]
        //[Range(0, 500)]
        public int DisplayOrder { get; set; }


        [Required]
        [Display(Name = "Selling Price")]
        public double Price { get; set; }

        [Display(Name = "Old Price")]
        public double OldPrice { get; set; }

        [Display(Name = "Cost Price")]
        public double CostPrice { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }


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

        #endregion

        #region Common Properties
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string PublishedBy { get; set; }
        public string IPAddress { get; set; }
        #endregion

        #region Navigation Property
        public ICollection<ProductNote> ProductNotes { get; set; }
        //public ICollection<Photo> Photos { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        #endregion

        public Product()
        {
            ProductNotes = new Collection<ProductNote>();
            //Photos = new Collection<Photo>();
        }
    }
}
