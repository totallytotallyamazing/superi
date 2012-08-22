using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{

    public class SiteSettings
    {
        [Required(ErrorMessage = "*")]
        [Editable(false)][DisplayName("Почтовый ящик администратора")]
        public string ReceiverMail { get; set; }
        [DisplayName("Размер страницы")]
        [Required(ErrorMessage = "*")]
        public int PageSize { get; set; }
        [DisplayName("Языки")]
        public string Languages { get; set; }
        [Required(ErrorMessage = "*")]
        [Editable(false)]
        [DisplayName("Почтовый ящик администратора")]
        public string ReceiverMail2 { get; set; }
    }
}
