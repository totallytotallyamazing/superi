using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Shop.Helpers.Validation;

namespace MBrand.Models
{
    namespace MBrand.Models
    {
        public class FeedbackFormModel
        {
            [Required(ErrorMessage = "Обязательно!")]
            [DisplayName("Ваше имя")]
            public string Name { get; set; }
            [DisplayName("Электропочта")]
            [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Неверно введен адрес почты. Формат: name@domain.com")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Обязательно!")]
            [DisplayName("Ваш вопрос")]
            public string Text { get; set; }
            [Captcha("ValidateCaptcha", "Captcha", ErrorMessage = "Неправильные символы!")]
            [Required(ErrorMessage = "Обязательно!")]
            [DisplayName("Антиспам-проверка: если вы не робот, введите символы с картинки")]
            public string Captcha { get; set; }
        }
    }
}