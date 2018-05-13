using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TimeSheetBL.DataEntity
{
    [Serializable]
    public class TimeSheetLineItem
    {
        public int Id { get; set; }
        
        public DateTime TimeSheetDate { get; set; }
        public int WorkTime { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public TimeSheet TimeSheet { get; set; }

    }
}
