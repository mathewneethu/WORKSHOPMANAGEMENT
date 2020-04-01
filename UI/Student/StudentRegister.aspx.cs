using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BOL;

public partial class Student_StudentRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        int WorkShopId = Int16.Parse(HttpContext.Current.Request.QueryString["WorkShopId"].ToString());
        string email = txtEmail.Text;
        tbl_User U = new tbl_User() { UserName_Email = email };
        UserBusiness UB = new UserBusiness();
        if (UB.CreateUserRequestCurrentUser(U, WorkShopId))
        {
            Response.Write("Registration Successfull");
            Response.Redirect("~/Student/WorkShop.aspx");
        }
    }
}