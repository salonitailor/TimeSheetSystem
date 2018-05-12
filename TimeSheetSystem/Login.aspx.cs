using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeSheetBL.DataEntity;
using TimeSheetBL.Business;

namespace TimeSheetSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLoginInvalid.Visible = false;
        }

        protected void Button_Login_Click(object sender, EventArgs e)
        {
            LoginCheck login = new LoginCheck();
            string user = TextBoxUserName.Text.Trim();
            
            if (login.IsValidLogin("", ""))
            {
                Session["user"] = user;
                Response.Redirect("TimeSheetList.aspx");
            }
            else
            {
                lblLoginInvalid.Visible = true;


            }

        }
    }
}