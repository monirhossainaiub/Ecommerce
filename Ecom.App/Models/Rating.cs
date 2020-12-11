using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Models
{
    [Table("Ratings")]
    public class Rating
    {
        public int Id { get; set; }
        public double RatingValue { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("ProductPublisher")]
        public int ProductPublisherId { get; set; }
        public ProductPublisher ProductPublisher { get; set; }

    }
}
