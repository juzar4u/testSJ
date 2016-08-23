using AngularExpenseApp.Helper;
using AngularExpenseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AngularExpenseApp.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            UserModel user = Services.Services.GetInstance.GetUserByCredentials(model.LoginUserName, model.LoginPassword);
            if (user != null)
            { 
                AuthHelper.AddSSOCookieIfNotExits(user);
            }
            else
            {
                ErrorModel err = new ErrorModel();
                err.Message = "Wrong UserName or Password";
                return PartialView("~/Views/Shared/PartialPopUpView.cshtml", err);
            }

           return Redirect("/");
        }

        public ActionResult Register(RegisterModel model)
        {
            Users user = new Users();
            user.UserName = model.RegisterUserName;
            user.Password = model.RegisterPassword;
            user.isActive = true;
            user.CreatedOn = DateTime.Now;
            HttpPostedFile postedFile = System.Web.HttpContext.Current.Request.Files[0];
            user.UserID = Services.Services.GetInstance.InsertUser(user);
            if (postedFile.ContentLength > 0)
                ValidateAndUploadImage(postedFile, user.UserID);

            UserModel usermodel = Services.Services.GetInstance.GetUserModelByUserID(user.UserID);

            AuthHelper.AddSSOCookieIfNotExits(usermodel);
            return Redirect("/");
        }

        public string ValidateAndUploadImage(HttpPostedFile postedFile, int userId)
        {
            string profileImageUrl = "";

            if (postedFile.ContentLength > 0)
            {
                WebImage img = new WebImage(postedFile.InputStream);
                if (postedFile != null)
                {
                    if ((postedFile.ContentType.Contains("image")))
                    {
                        Users _user = Services.Services.GetInstance.GetUserByUserID(userId);
                        if (img.Width > 300 & img.Height > 300)
                        {
                            img.Resize(300, 300);
                            img.Save(HttpContext.Server.MapPath("~/Images/Profile/") + postedFile.FileName);
                            profileImageUrl = "/Images/Profile/" + postedFile.FileName;
                        }
                        else
                        {
                            img.Save(HttpContext.Server.MapPath("~/Images/Profile/") + postedFile.FileName);
                            profileImageUrl = "/Images/Profile/" + postedFile.FileName;
                        }
                        _user.ProfilePictureUrl = profileImageUrl;
                        Services.Services.GetInstance.UpdateUser(_user);
                    }
                }
                else
                {
                    profileImageUrl = null;
                }
            }
            else
            {
                profileImageUrl = null;
            }
            return profileImageUrl;
        }

        public bool validationUserName(string username)
        {
            bool isValid = false;
            UserModel user = Services.Services.GetInstance.GetUserByUserName(username);
            if (user != null)
                isValid = true;
            return isValid;
        }

        public bool validationForLogin(string username, string password)
        {
            bool isValid = false;
            UserModel user = Services.Services.GetInstance.GetUserByCredentials(username, password);
            if (user != null)
                isValid = true;
            return isValid;
        }

    }
}
