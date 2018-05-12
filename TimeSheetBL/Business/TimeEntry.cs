using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetBL.DataEntity;

namespace TimeSheetBL.Business
{
    public class TimeEntry
    {
        TimeSheetDB dB = new TimeSheetDB();
        public IList<TimeSheet> GetAllTimeSheets()
        {

            return dB.TimeSheets.ToList();
        }

        public int InsertTimeSheet(TimeSheet timeSheet)
        {
            TimeSheet ts = dB.TimeSheets.Create();

            ts.LastUpdateDate = timeSheet.LastUpdateDate;
            ts.Rate = timeSheet.Rate;
           
            ts.UserID = timeSheet.UserID;
            ts.Cost = timeSheet.Cost;
            ts.Description = timeSheet.Description;

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
            return dB.TimeSheets.Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
