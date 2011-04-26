using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace Shop.Models
{
    [MetadataType(typeof(DesignerValidation))]
    public partial class Designer
    {

    }

    [Bind(Exclude = "Id")]
    public class DesignerValidation
    {
        [Required(ErrorMessage = "Введите имя")]
        [DisplayName("Имя:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите имя в поле \"Портфолио дизайнера\"")]
        [DisplayName("Портфолио дизайнера:")]
        public string NameF { get; set; }

        [Required(ErrorMessage = "Введите адрес ссылки дизайнера (должен быть уникальным)")]
        [DisplayName("Имя в строке адреса браузера:")]
        public string Url { get; set; }

        [DisplayName("Фото:")]
        public string Logo { get; set; }

        [DisplayName("Описание:")]
        public string Summary { get; set; }

    }
}