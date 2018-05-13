using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetBL.DataEntity;

namespace TimeSheetBL.Business
{
    [Serializable]
    public class TimeEntry
    {
        TimeSheetDB dB = new TimeSheetDB();
        public IList<TimeSheet> GetAllTimeSheets()
        {

            return dB.TimeSheets.Include(t => t.User).ToList();
        }

        public int InsertTimeSheet(TimeSheet timeSheet)
        {
            TimeSheet ts = dB.TimeSheets.Create();

            ts.LastUpdateDate = timeSheet.LastUpdateDate;
            ts.Rate = timeSheet.Rate;
            ts.UserID = timeSheet.UserID;
            ts.Cost = timeSheet.Cost;
            ts.Description = timeSheet.Description;
            ts.TimeSheetLineItem = new List<TimeSheetLineItem>();

            foreach (var li in timeSheet.TimeSheetLineItem)
            {
                if (li.WorkTime != 0)
                {
                    TimeSheetLineItem timeSheetLineItem = dB.TimeSheetLineItems.Create();
                    timeSheetLineItem.LastUpdateDate = DateTime.Now;
                    timeSheetLineItem.WorkTime = li.WorkTime;
                    timeSheetLineItem.TimeSheetDate = li.TimeSheetDate;
                    timeSheetLineItem.TimeSheet = ts;
                    ts.TimeSheetLineItem.Add(timeSheetLineItem);
                }
            }
            dB.TimeSheets.Add(ts);

            return dB.SaveChanges();
        }

        public int UpdateTimeSheet(TimeSheet timeSheet)
        {
            TimeSheet ts = dB.TimeSheets.Where(t => t.Id == timeSheet.Id).FirstOrDefault();

            ts.LastUpdateDate = timeSheet.LastUpdateDate;
            ts.Rate = timeSheet.Rate;

            ts.UserID = timeSheet.UserID;
            ts.Cost = timeSheet.Cost;
            ts.Description = timeSheet.Description;

            dB.TimeSheets.Attach(ts);
            dB.Entry(ts).State = EntityState.Modified;

            return dB.SaveChanges();
        }

        public TimeSheet GetTimeSheetById(int id)
        {
            TimeSheet ts = dB.TimeSheets.Include(t => t.TimeSheetLineItem).Where(t => t.Id == id).FirstOrDefault();
            return ts;
        }

        public IList<TimeSheet> GetTimeSheetByUserName(string username)
        {
            return dB.TimeSheets.Where(t => t.UserID == username).ToList();
        }
    }
}
