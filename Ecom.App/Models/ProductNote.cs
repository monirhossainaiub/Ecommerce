using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Models
{
    public class ProductNote
    {
        public int Id { get; set; }
        public string Note { get; set; }

        #region Common
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string IPAddress { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        #endregion

        #region Navigation Properties
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        #endregion
    }
}
