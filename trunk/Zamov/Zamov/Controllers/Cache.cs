using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Threading;

namespace Zamov.Controllers
{
    public class Cache : Hashtable, IDisposable
    {

        class Expirations : Dictionary<string, List<object>>
        {
            // Private constructor
            Expirations() { }

            // Nested class for lazy instantiation
            class ExpirationsCreator
            {
                static ExpirationsCreator() { }
                // Private object instantiated with private constructor
                internal static readonly
                 Expirations uniqueInstance = new Expirations();
            }

            // Public static property to get the object
            public static Expirations UniqueInstance
            {
                get { return ExpirationsCreator.uniqueInstance; }
            }
        }

        //private long expireIn = 20;

        Thread thread;
        static readonly Dictionary<string, List<object>> expirations = Expirations.UniqueInstance;
        // Private constructor
        Cache() 
        {
            thread = new Thread(ExpireCache);
           // thread.Start();
        }

        public void Dispose()
        {
            thread.Abort();
            ExpireAll();
        }

        private void ExpireCache()
        {
            while (true)
            {
                string expireKey = DateTime.Now.ToString("yyyyMMdd HH:mm");
                if (expirations.Keys.Contains(expireKey))
                {
                    foreach (var item in expirations[expireKey])
                    {
                        Expire(item);
                    }
                }
                Thread.Sleep(1000*59);
            }
        }

        // Nested class for lazy instantiation
        class CacheCreator
        {
            static CacheCreator() { }
            // Private object instantiated with private constructor
            internal static readonly
             Cache uniqueInstance = new Cache();
        }

        // Public static property to get the object
        public static Cache UniqueInstance
        {
            get { return CacheCreator.uniqueInstance; }
        }

        public void Expire(object key)
        {
            this[key] = null;
            this.Remove(key);
        }

        public void ExpireAll()
        {
            List<object> keys = new List<object>();
            foreach (var item in this.Keys)
                keys.Add(item);
            foreach (var item in keys)
                this.Remove(item);
        }

        public override object this[object key]
        {
            get
            {
                return base[key];
            }
            set
            {
                base[key] = value;
                string expireKey = DateTime.Now.ToString("yyyyMMdd HH:mm");
                if (!expirations.Keys.Contains(expireKey))
                    expirations[expireKey] = new List<object>();
                expirations[expireKey].Add(key);

            }
        }
    }
}
