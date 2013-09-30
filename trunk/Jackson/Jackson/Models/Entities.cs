using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jackson.Models
{
    [Table("Group")]
    public class Group
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }

    [Table("Item")]
    public class Item
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int SortOrder { get; set; }
        public int Group_Id { get; set; }
        public string ThumbnailUrl { get; set; }
        [ForeignKey("Group_Id")]
        public virtual Group Group { get; set; }
    }
}