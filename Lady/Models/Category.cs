using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace Lady.Models
{
    [MetadataType(typeof(CategoryValidation))]
    public partial class Category
    {
    }

    [Bind(Exclude = "Id")]
    public class CategoryValidation
    {
        [Required(ErrorMessage = "Введите название")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Keywords")]
        public string SeoKeywords { get; set; }

        [DisplayName("Description")]
        public string SeoDescription { get; set; }
    }
}
