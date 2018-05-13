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
            if (!Page.IsPostBack)
            {
                lblLoginInvalid.Visible = false;

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginCheck login = new LoginCheck();
            string user = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            int userId = login.IsValidLogin(user, password);

            if (userId != 0)
            {
                Session["user"] = user;
                Session["userid"] = userId;
                Response.Redirect("TimeSheetList.aspx");
            }
            else
            {
                lblLoginInvalid.Visible = true;
            }
        }
    }
}