﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeSheetBL.Business;
using TimeSheetBL.DataEntity;

namespace TimeSheetSystem
{
    public partial class LineItem : System.Web.UI.Page
    {
        TimeEntry timeEntry = new TimeEntry();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            lblUserDetail1.Text = "Welcome " + Session["user"];

            if (!Page.IsPostBack)
            {
                

                IList<TimeSheet> timeSheets = timeEntry.GetTimeSheetByUserName(Session["user"].ToString());

                gvDetails.DataSource = timeSheets;
                gvDetails.DataBind();
            }
        }

        protected void btnAddTimeSheet_Click(object sender, EventArgs e)
        {
            Response.Redirect("TimeSheetEntry.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}