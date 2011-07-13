﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Models
{


    [MetadataType(typeof(SubscribersValidation))]
    public partial class Subscriber
    {
        public static bool IsSubscribed
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["subscribe"] != null)
                {
                    return true;

                }
                return false;
            }
        }
    }

    public class SubscribersValidation
    {
        [Required(ErrorMessage = "* Введите адрес электронной почты")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Неверно введен адрес почты. Формат: name@domain.com")]
        public string Email { get; set; }
    }




}