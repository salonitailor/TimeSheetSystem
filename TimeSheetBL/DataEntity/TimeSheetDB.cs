using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

namespace TimeSheetBL.DataEntity
{
    class TimeSheetDB : DbContext
    {
        public TimeSheetDB() : base(ConfigurationManager.ConnectionStrings["TimeSheetDB"].ToString())
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<TimeSheetLineItem> TimeSheetLineItems {get;set;}

    }
}
