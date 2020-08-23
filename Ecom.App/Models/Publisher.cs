using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [MaxLength(250)]
        public string Address { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPublished { get; set; }
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


        #region Navigation Properties
        public ICollection<Product> Products { get; set; }
        #endregion
        public Publisher()
        {
            Products = new Collection<Product>();
        }
    }
}
