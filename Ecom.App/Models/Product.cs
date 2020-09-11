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
        [MaxLength(150)]
        [Display(Name = "Product")]
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public int DisplayOrder { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        [ForeignKey("Writer")]
        public int WriterId { get; set; }

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
        public ICollection<ProductPublisher> ProductPublishers { get; set; }
        public Category Category { get; set; }
        public Language Language { get; set; }
        public Writer Writer { get; set; }

        #endregion

        public Product()
        {
            ProductNotes = new Collection<ProductNote>();
            ProductPublishers = new Collection<ProductPublisher>();
            //Photos = new Collection<Photo>();
        }
    }
}
