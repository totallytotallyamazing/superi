﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{

    public class SiteSettings
    {
        //[DisplayName("Курс евро")]
        //[Required(ErrorMessage="*")]
        //[DataType(DataType.Currency)]
        //public float EuroRate { get; set; }
        //[Required(ErrorMessage = "*")]
        //[DisplayName("Курс доллара")]
        //[DataType(DataType.Currency)]
        //public float DollarRate { get; set; }
        //[Required(ErrorMessage = "*")]
        //[DisplayName("Курс рубля")]
        //[DataType(DataType.Currency)]
        //public float RubleRate { get; set; }
        [Required(ErrorMessage = "*")]
        [Editable(false)][DisplayName("Почтовый ящик администратора")]
        public string ReceiverMail { get; set; }
        [DisplayName("Размер страницы")]
        [Required(ErrorMessage = "*")]
        public int PageSize { get; set; }
    }
}