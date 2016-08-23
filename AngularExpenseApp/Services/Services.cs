using AngularExpenseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularExpenseApp.Services
{
    public class Services
    {
        private static Services _instace;

        public static Services GetInstance
        {
            get
            {
                if (_instace == null)
                {
                    _instace = new Services();
                }

                return _instace;
            }
        }

        public int InsertUser(Users user)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return (int)context.Insert(user);
            }
        }

        public int UpdateUser(Users user)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return (int)context.Update(user);
            }
        }

        public UserModel GetUserByUserName(string username)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<UserModel>("select * from users where username = @0", username).FirstOrDefault();
            }
        }

        public UserModel GetUserByCredentials(string username, string password)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<UserModel>("select * from users where username = @0 and Password = @1", username, password).FirstOrDefault();
            }
        }
        

        public Users GetUserByUserID(int userid)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<Users>("select * from users where UserID = @0", userid).FirstOrDefault();
            }
        }

        public UserModel GetUserModelByUserID(int userid)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<UserModel>("select * from users where UserID = @0", userid).FirstOrDefault();
            }
        }

    }
}