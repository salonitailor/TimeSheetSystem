using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetBL.DataEntity;

namespace TimeSheetSystem
{
    public class LoginCheck
    {
        TimeSheetDB dB = new TimeSheetDB();

        public bool IsValidLogin(string UserName, string Password)
        {
            User user = GetUserByName(UserName);

            if (user.Password == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User GetUserByName(string UserName)
        {
            return dB.Users.Where(u => u.UserID == UserName).FirstOrDefault();
        }

    }
}