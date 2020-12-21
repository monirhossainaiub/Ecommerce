using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public Photo Photo { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
