using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularExpenseApp.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool isActive { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class RegisterModel
    {
        public string RegisterUserName { get; set; }
        public string RegisterPassword { get; set; }
    }

    public class LoginModel
    {
        public string LoginUserName { get; set; }
        public string LoginPassword { get; set; }
    }
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int UserID { get; set; }
    }

    public class ExpenseRecordModel
    {
        public int ExpenseRecordID { get; set; }
        public int Amount { get; set; }
        public string Details { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
    }


    public class ErrorModel
    {
        public string Message { get; set; }
    }

}