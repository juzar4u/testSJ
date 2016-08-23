﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AngularExpenseApp.Helper
{
    public class ApplicationConstants
    {
        public static int ListCacheTimeInSec
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["LIST_CACHE_TIME_IN_SEC"]);
            }
        }
        public static string CON_SSOCookieName
        {
            get
            {
                return ConfigurationManager.AppSettings["SSOCookieName"];
            }
        }
        public static string CON_SessionCookieDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["SessionCookieDomain"];
            }
        }

        public static string CON_SSOCookieKeySalt
        {
            get
            {
                return ConfigurationManager.AppSettings["SSOCookieKeySalt"];
            }
        }
        public static bool UseDomainlessCookie
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["UseDomainlessCookie"]);
            }
        }

        public static string CON_SSOCookieDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["SSOCookieDomain"];
            }
        }

        public static string SESSION_USER
        {
            get
            {
                return ConfigurationManager.AppSettings["SESSION_USER"];
            }
        }
    }
}