using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamShop.Models
{
    public static class MyAlerts
    {
        public const string SUCCESS = "success";
        public const string WARNING = "warning";
        public const string DANGER = "danger";
        public const string INFORMATION = "info";

        public static string[] ALL
        {
            get
            {
                return new[]
                           {
                           SUCCESS,
                           WARNING,
                           INFORMATION,
                           DANGER
                       };
            }
        }

    }
}