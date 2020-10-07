using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string StateProvidiant { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }

    }
}
