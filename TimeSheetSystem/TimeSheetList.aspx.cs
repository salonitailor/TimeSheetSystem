using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeSheetBL.Business;
using TimeSheetBL.DataEntity;

namespace TimeSheetSystem
{
    public partial class TimeSheetList : System.Web.UI.Page
    {
        TimeEntry timeEntry = new TimeEntry();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserDetail.Text = "Welcome" + Session["user"];

            IList<TimeSheet> timeSheets = timeEntry.GetAllTimeSheets();
            
            gvTimeSheet.DataSource = timeSheets;
            gvTimeSheet.DataBind();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}