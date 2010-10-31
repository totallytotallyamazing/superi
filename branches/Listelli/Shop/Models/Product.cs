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
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Наименование товара")]
        public string Name { get; set; }

        [DisplayName("Артикул")]
        public string PartNumber { get; set; }

        [DisplayName("Ключевые слова страницы")]
        public string SeoKeywords { get; set; }

        [DisplayName("Описание страницы")]
        public string SeoDescription { get; set; }

        [DisplayName("Цена")]
//        [Required(ErrorMessage = "*")]
        public float Price { get; set; }

        [DisplayName("Старая цена")]
        public float OldPrice { get; set; }

        [DisplayName("Цвет")]
        [StringLength(100, ErrorMessage = "Максимум 100 символов.")]
        public string Color { get; set; }

        [DisplayName("Новинка")]
        public bool IsNew { get; set; }

        [DisplayName("Номер по порядку")]
        [RegularExpression(@"\d+", ErrorMessage = "Введите число")]
        [Required(ErrorMessage = "*")]
        public int SortOrder { get; set; }

        [DisplayName("Показывать на сайте")]
        public bool Published { get; set; }

        [DisplayName("Включить товар в афиши")]
        [DefaultValue(true)]
        public bool ShowInRoot { get; set; }
    }

}
