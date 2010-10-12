using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace Shop.Models
{
    [MetadataType(typeof(ArticleValidation))]
    public partial class Article
    { 
        
    }

    [Bind(Exclude = "Id")]
    public class ArticleValidation
    {
        [Required(ErrorMessage="*")]
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage="*")]
        [DisplayName("Дата")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Текст")]
        public DateTime Text { get; set; }
    }
}