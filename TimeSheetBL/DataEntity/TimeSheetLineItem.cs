using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetBL.DataEntity
{
    public class TimeSheetLineItem
    {
        public int Id { get; set; }
        public DateTime TimeSheetDate { get; set; }
        public int WorkTime { get; set; }
        public int LastUpdateDate { get; set; }
        public TimeSheet TimeSheet { get; set; }

    }
}
