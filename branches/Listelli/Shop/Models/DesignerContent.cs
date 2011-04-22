using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Models
{
    [MetadataType(typeof(DesignerContentValidation))]
    public partial class DesignerContent
    {

    }

    [Bind(Exclude = "Id")]
    public class DesignerContentValidation
    {
        [Required(ErrorMessage = "Введите название")]
        [DisplayName("Название")]
        public string RoomName { get; set; }

        [Required(ErrorMessage = "Выберите тип помещения")]
        [DisplayName("Тип помещения")]
        public string RoomType { get; set; }
    }
}