using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBrand.Models.ViewModel
{
    public class SecretPresentation
    {
        public Text SecretText { get; set; }
        public IEnumerable<SecretImages> Imageses { get; set; }
    }
}