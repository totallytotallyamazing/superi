using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;


namespace Shop.Models
{

        [MetadataType(typeof(DesignerRoomValidation))]
        public partial class DesignerRoom
        {

        }

        [Bind(Exclude = "Id")]
        public class DesignerRoomValidation
        {
            [Required(ErrorMessage = "Введите название")]
            [DisplayName("Название")]
            public string Name { get; set; }
        }
   
}