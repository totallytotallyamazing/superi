using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zamov.Models
{
    public class StorageContext:Zamov.Models.ZamovStorage
    {
        private static readonly StorageContext instanse = new StorageContext();

        static StorageContext() { }

        protected StorageContext() { }

        public static StorageContext Instanse
        {
            get { return instanse; }
        }
    }
}
