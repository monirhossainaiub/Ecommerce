using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Models
{
    public class Banner
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }

        public ICollection<ProductPublisher> ProductPublishers { get; set; }

        public Banner()
        {
            ProductPublishers = new Collection<ProductPublisher>();
        }
    }
}
