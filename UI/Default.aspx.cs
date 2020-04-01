using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        tbl_User U = new tbl_User();
        U.UserName_Email = txtUserName.Text;
        U.Password = txtPassword.Text;
        UserBusiness UB = new UserBusiness();
        bool flag = UB.ValidateUser(U);
        if (flag == true)
        {
            Session.Add("UserId", U.UserId);
            Session.Add("RoleId", U.RoleId);
            Session.Add("UserName_Email",U.UserName_Email);
            //Session.Add("User",U);

            if (U.RoleId == 1)
            {
                Clear();
                Response.Redirect("~/Admin/Home.aspx");
            }
            else if (U.RoleId == 3)
            {
                Clear();
                Response.Redirect("~/Student/Home.aspx");
            }
        }
        else
        {
            System.Threading.Thread.Sleep(3000);
            lblMessage.Text = "UserName or Password Invalid!!";
        }
    }

    private void Clear()
    {

        txtUserName.Text = "";
        txtPassword.Text = "";
    }
}