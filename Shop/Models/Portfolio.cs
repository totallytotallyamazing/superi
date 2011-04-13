using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace Shop.Models
{
    [MetadataType(typeof(PortfolioValidation))]
    public partial class Portfolio
    {

    }

    [Bind(Exclude = "Id")]
    public class PortfolioValidation
    {
        [Required(ErrorMessage = "Введите имя")]
        [DisplayName("Имя")]
        public string UserName { get; set; }
    }
}