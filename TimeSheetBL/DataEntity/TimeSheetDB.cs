using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TimeSheetBL.DataEntity
{
    class TimeSheetDB : DbContext
    {
        public TimeSheetDB() : base("TimeSheetDB")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<TimeSheetLineItem> TimeSheetLineItems {get;set;}

    }
}
