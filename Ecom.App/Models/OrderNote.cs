using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Models
{
    [Table("OrderNotes")]
    public class OrderNote
    {
        [Key]
        public int Id { get; set; }
        public string Note { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

    }
}
