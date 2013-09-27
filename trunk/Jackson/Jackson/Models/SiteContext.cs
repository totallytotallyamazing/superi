using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jackson.Models
{
    public class SiteContext : DbContext
    {
        public SiteContext() : base("DefaultConnection")
        {

        }

        public DbSet<Group> Groups{ get; set; }
        public DbSet<Item> Items { get; set; }
    }
}