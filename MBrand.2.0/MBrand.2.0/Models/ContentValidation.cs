using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MBrand.Models
{
     [MetadataType(typeof(ContentValidation))]
    public partial class Content
    {
         
    }

    [Bind(Exclude = "Id")]
    public class ContentValidation
    {
        [DisplayName("Веб-имя страницы")]
        [Required]
        [Remote("IsNameAvailable", "Validation")]
        public string Name { get; set; }

        [DisplayName("Заголовок")]
        public string Title { get; set; }

        [DisplayName("Содержимое страницы")]
        public string Text { get; set; }
       
        [DisplayName("Краткое описание")]
        public string Description { get; set; }
        
        [DisplayName("Ключевые слова этой страницы")]
        public string SeoKeywords { get; set; }

        [DisplayName("Описание страницы")]
        public string SeoDescription { get; set; }
    }

    [MetadataType(typeof(WorkValidation))]
    public partial class Work
    {

    }

    [Bind(Exclude = "Id")]
    public class WorkValidation : ContentValidation
    {
        [DisplayName("Превьюшка")]
        public string Image { get; set; }

        [DisplayName("Картинка снизу")]
        public string BottomImage { get; set; }

        [DisplayName("№ по-порядку")]
        public int SortOrder { get; set; }

        [DisplayName("Текст слева")]
        public string SideBarText { get; set; }
    }
    //[MetadataType(typeof(WorkGroupValidation))]
    //public partial class WorkGroup
    //{

    //}

    //[Bind(Exclude = "Id")]
    //public class WorkGroupValidation
    //{

    //}

}