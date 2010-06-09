using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace Shop.Models
{
    [MetadataType(typeof(ProductValidation))]
    public partial class Product
    {
    }

    [Bind(Exclude = "Id")]
    public class ProductValidation
    {
        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Краткое описание")]
        public string ShortDescription{ get; set; }

        [Required(ErrorMessage = "Введите название")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Keywords")]
        public string SeoKeywords { get; set; }

        [DisplayName("Description")]
        public string SeoDescription { get; set; }

        [DisplayName("Цена")]
        public float Price { get; set; }

        [DisplayName("Старая цена")]
        public float OldPrice { get; set; }
    }

}
