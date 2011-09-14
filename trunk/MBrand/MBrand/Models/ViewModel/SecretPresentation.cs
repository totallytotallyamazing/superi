using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBrand.Models.ViewModel
{
    public class SecretPresentation
    {
        public MBrand.Models2.Text SecretText { get; set; }
        public IEnumerable<MBrand.Models2.SecretImages> Imageses { get; set; }
    }
}