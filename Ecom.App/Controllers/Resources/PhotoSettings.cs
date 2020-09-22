using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.Resources
{
    public class PhotoSettings
    {
        public int MaxBytes { get; set; }
        public string [] AcceptedFileTypes { get; set; }
        public bool IsSupported(string fileName)
        {
            return AcceptedFileTypes.Any(x => x == Path.GetExtension(fileName).ToLower());
        }
    }
}
