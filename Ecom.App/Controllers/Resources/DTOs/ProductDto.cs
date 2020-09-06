using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.Resources.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Product")]
        public string Name { get; set; }

        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Language { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }
        public int CategoryId { get; set; }

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


    }
}
