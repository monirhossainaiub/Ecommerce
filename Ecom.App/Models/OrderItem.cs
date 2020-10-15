using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Models
{
    [Table("OrderItems")]
    public class OrderItem
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductPublisherId { get; set; }

        public double Quantity { get; set; }
        public double UnitPrice { get; set; }

        public Order Order { get; set; }
        public ProductPublisher ProductPublisher { get; set; }
    }
}
