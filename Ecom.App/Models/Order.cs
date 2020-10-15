using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string ShippingAddress { get; set; }
        public DateTime? CreatedAt { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }

        public double OrderDiscount { get; set; }
        public double OrderTotal { get; set; }
        public double RefundAmount { get; set; }

        #region Navigation Properties
        public Customer Customer { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        #endregion

        public Order()
        {
            OrderItems = new Collection<OrderItem>();
        }
    }
}
