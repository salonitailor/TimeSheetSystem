using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetBL.DataEntity;

namespace TimeSheetSystem
{
    [Serializable]
    public class LoginCheck
    {
        TimeSheetDB dB = new TimeSheetDB();

        public int IsValidLogin(string UserName, string Password)
        {
            User user = GetUserByName(UserName);

            if (user.Password == Password)
            {
                return user.Id;
            }
            else
            {
                return 0;
            }
        }

        public User GetUserByName(string UserName)
        {
            return dB.Users.Where(u => u.UserID == UserName).FirstOrDefault();
        }

    }
}