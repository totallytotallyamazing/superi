using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Shop.Models
{
    [MetadataType(typeof(ProductAttributeValidation))]
    public partial class ProductAttribute
    {
    }

    public class ProductAttributeValidation
    {
        [Required(ErrorMessage = "Укажите порядок")]
        [DisplayName("Номер по порядку")]
        public int SortOrder { get; set; }

        [Required(ErrorMessage = "Укажите значение")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Тип значения не указан")]
        [DisplayName("Тип значения")]
        public string ValueType { get; set; }
    }

}