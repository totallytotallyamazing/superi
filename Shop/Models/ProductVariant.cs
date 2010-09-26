using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Shop.Models
{
    [MetadataType(typeof(ProductVariantValidation))]
    public partial class ProductVariant
    {
    }

    [Bind(Exclude = "Id")]
    public class ProductVariantValidation
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Картинко")]
        public string Image { get; set; }

        [DisplayName("Цена")]
        [Required(ErrorMessage = "*")]
        public float Price { get; set; }

        [DisplayName("Старая цена")]
        public float OldPrice { get; set; }

        [DisplayName("Номер по порядку")]
        [RegularExpression(@"\d+", ErrorMessage = "Введите число")]
        public int SortOrder { get; set; }

        [DisplayName("Показывать на сайте")]
        public bool Published { get; set; }
    }

}