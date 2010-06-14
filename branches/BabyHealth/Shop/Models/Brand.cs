using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace Shop.Models
{
    [MetadataType(typeof(BrandValidation))]
    public partial class Brand
    {
    }

    [Bind(Exclude="Id")]
    public class BrandValidation
    {
        [DisplayName("Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage="Введите название")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Keywords")]
        public string SeoKeywords { get; set; }

        [DisplayName("Description")]
        public string SeoDescription { get; set; }

        [DisplayName("Лого")]
        public string Logo { get; set; }
    }
}
