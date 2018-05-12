using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetBL.DataEntity;

namespace TimeSheetBL.Business
{
    public class LineItemEntry
    {
        TimeSheetDB dB = new TimeSheetDB();

        public IList<TimeSheetLineItem> GetAllLineItems()
        {
            return dB.TimeSheetLineItems.ToList();
        }

        public int InsertLineItem(TimeSheetLineItem lineItem)
        {
            TimeSheetLineItem tl = dB.TimeSheetLineItems.Create();
            tl.TimeSheetDate = lineItem.TimeSheetDate;
            tl.WorkTime = lineItem.WorkTime;
            tl.LastUpdateDate = lineItem.LastUpdateDate;
            tl.TimeSheet = lineItem.TimeSheet;

            dB.TimeSheetLineItems.Add(tl);

            return dB.SaveChanges();

        }

        public int UpdateTimeSheet(TimeSheetLineItem lineItem)
        {
            TimeSheetLineItem tl = dB.TimeSheetLineItems.Where(t => t.Id == lineItem.Id).FirstOrDefault();

            tl.TimeSheetDate = lineItem.TimeSheetDate;
            tl.WorkTime = lineItem.WorkTime;
            tl.LastUpdateDate = lineItem.LastUpdateDate;
            tl.TimeSheet = lineItem.TimeSheet;



            dB.TimeSheetLineItems.Attach(tl);
            return dB.SaveChanges();
        }

        public TimeSheetLineItem GetTimeSheetById(int id)
        {
            return dB.TimeSheetLineItems.Where(t => t.Id == id).FirstOrDefault();
        }

    }
}
