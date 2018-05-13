using System;
using System.Collections.Generic;
using System.Data;
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
        TimeSheet timeSheet = new TimeSheet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    timeSheet = timeEntry.GetTimeSheetById(id);
                    ViewState.Add("TimeSheet", timeSheet);

                    gvTimeSheet.DataSource = timeSheet.TimeSheetLineItem;
                    gvTimeSheet.DataBind();

                    txtDescription.Text = timeSheet.Description;
                    txtDescription.Enabled = false;
                    txtRate.Text = timeSheet.Rate.ToString();
                    txtRate.Enabled = false;
                    CalculateTime(timeSheet.TimeSheetLineItem.ToList());
                    txtTotalCost.Text = timeSheet.Cost.ToString();
                    btnSave.Visible = false;
                }
                else
                {
                    lblUserDetail.Text = "Welcome " + Session["user"];

                    timeSheet.TimeSheetLineItem = new List<TimeSheetLineItem>();

                    TimeSheetLineItem timeSheetLineItem = new TimeSheetLineItem();

                    timeSheet.TimeSheetLineItem.Add(timeSheetLineItem);

                    gvTimeSheet.EditIndex = timeSheet.TimeSheetLineItem.Count - 1;

                    ViewState.Add("TimeSheet", timeSheet);

                    gvTimeSheet.DataSource = timeSheet.TimeSheetLineItem;
                    gvTimeSheet.DataBind();

                    ((TextBox)gvTimeSheet.Rows[timeSheet.TimeSheetLineItem.Count - 1].FindControl("txtTimeSheetDate")).Text = "";
                    ((TextBox)gvTimeSheet.Rows[timeSheet.TimeSheetLineItem.Count - 1].FindControl("txtWorkTime")).Text = "";
                }

            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TimeSheetList.aspx");
        }

        protected void gvTimeSheet_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TimeSheet ts = (TimeSheet)ViewState["TimeSheet"];
            var dt = e.NewValues[0];
            var worktime = e.NewValues[1];

            ts.TimeSheetLineItem.ToList()[e.RowIndex].TimeSheetDate = DateTime.Parse(dt.ToString());
            ts.TimeSheetLineItem.ToList()[e.RowIndex].WorkTime = int.Parse(worktime.ToString());

            TimeSheetLineItem timeSheetLineItem = new TimeSheetLineItem();

            ts.TimeSheetLineItem.Add(timeSheetLineItem);

            gvTimeSheet.EditIndex = ts.TimeSheetLineItem.Count - 1;

            ViewState.Add("TimeSheet", ts);

            CalculateTime(ts.TimeSheetLineItem.ToList());

            gvTimeSheet.DataSource = ts.TimeSheetLineItem;
            gvTimeSheet.DataBind();

            ((TextBox)gvTimeSheet.Rows[ts.TimeSheetLineItem.Count - 1].FindControl("txtTimeSheetDate")).Text = "";
            ((TextBox)gvTimeSheet.Rows[ts.TimeSheetLineItem.Count - 1].FindControl("txtWorkTime")).Text = "";
        }

        private void CalculateTime(IList<TimeSheetLineItem> lineItems)
        {

            float TotalTime = 0;
            foreach (var lineitem in lineItems)
            {
                TotalTime += lineitem.WorkTime;
            }
            txtTotalTime.Text = (TotalTime / 60).ToString();
        }

        protected void gvTimeSheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var lbl2 = (Label)e.Row.Cells[1].FindControl("lblWorkTime");
                if (lbl2 != null)
                {
                    if (lbl2.Text != "0")
                    {
                        var lbl1 = (Label)e.Row.Cells[1].FindControl("lblTimeSheetDate");

                        if (lbl1 != null)
                            lbl1.Text = Convert.ToDateTime(lbl1.Text).ToShortDateString();
                    }
                }
            }
        }

        protected void TextBoxRate_TextChanged(object sender, EventArgs e)
        {
            float rate;
            float totaltime;
            float totalcost;

            rate = float.Parse(txtRate.Text);

            totaltime = float.Parse(txtTotalTime.Text);

            totalcost = totaltime * rate;

            txtTotalCost.Text = totalcost.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TimeSheet ts = (TimeSheet)ViewState["TimeSheet"];

            ts.Rate = float.Parse(txtRate.Text);
            ts.Description = txtDescription.Text;
            ts.Cost = float.Parse(txtTotalCost.Text);
            ts.LastUpdateDate = DateTime.Now;
            ts.UserID = Session["user"].ToString();

            timeEntry.InsertTimeSheet(ts);

            Response.Redirect("TimeSheetList.aspx");
        }
    }
}