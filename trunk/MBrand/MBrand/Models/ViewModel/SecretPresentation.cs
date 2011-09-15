using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBrand.Models.ViewModel
{
    public class SecretPresentation
    {
        public MBrand.Models.Text SecretText { get; set; }
        public IEnumerable<MBrand.Models.SecretImages> Imageses { get; set; }
    }
}