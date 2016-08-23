using AngularExpenseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularExpenseApp.Helper
{
    public static class SessionManager
    {
        private static string SESSION_USER = "SESSION_Expense_USER_OBJ";
        private const string CURRENT_PAGE_URL = "CURRENT_PAGE_URL";
        private const string SELECTED_LEAGUE_GROUP = "SELECTED_LEAGUE_GROUP";

        public static UserModel SessionUserObject
        {
            get
            {
                return CookieHelper.GetObjectFromCookie<UserModel>(SESSION_USER);
            }
            set
            {
                CookieHelper.SetObjectToCookie(SESSION_USER, value);
            }

        }

        public static int? SelectedLeagueGroup
        {
            get
            {
                return CookieHelper.GetObjectFromCookie<int?>(SELECTED_LEAGUE_GROUP);
            }
            set
            {
                CookieHelper.SetObjectToCookie(SELECTED_LEAGUE_GROUP, value);
            }

        }

        public static UserModel SetSessionUserObject
        {
            get
            {
                UserModel retVal = null;
                if (HttpContext.Current.Session[SESSION_USER] != null)
                {
                    retVal = (UserModel)HttpContext.Current.Session[SESSION_USER];
                }
                return retVal;
            }
            set
            {
                HttpContext.Current.Session[SESSION_USER] = value;
            }

        }
    }
}