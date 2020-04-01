using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using BLL;

public partial class Common_Register : System.Web.UI.Page
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
        if (UB.CreateUserRequest(U, WorkShopId))
        {
            lblMessage.Text = "Registration Successfull";
            ClearData();
           
        }
    }

    private void ClearData()
    {
        txtEmail.Text = "";
    }
}