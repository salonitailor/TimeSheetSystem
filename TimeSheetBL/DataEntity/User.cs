using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetBL.DataEntity
{
    public class User
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime LastAccessedDate { get; set; }
    }
}
