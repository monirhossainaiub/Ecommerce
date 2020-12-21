using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.Resources.DTOs
{
    public class SliderDto
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public string Photo { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
