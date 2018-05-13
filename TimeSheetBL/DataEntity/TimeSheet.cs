using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetBL.DataEntity
{
    [Serializable]
    public class TimeSheet
    {

        public int Id { get; set; }
        
        public string Description { get; set; }
        public float  Rate { get; set; }
        public float Cost { get; set; }
        public string UserID{ get; set; }
        public DateTime LastUpdateDate { get; set; }

        public User User { get; set; }

        public ICollection<TimeSheetLineItem> TimeSheetLineItem { get; set; }
    }
}
