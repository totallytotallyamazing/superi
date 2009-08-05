using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zamov.Models
{
    public enum Statuses
    {
        New = 0,
        Accepted = 1,
        Complited = 2,
        Canceled = 3
    }

    public static class Status
    {
        public static string[] status ={"новый","принятый","выполненный","отклонённый"};
    }
}
